//INF2018c, Fabio Leuthold, 26.05.2019
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace Snake
{
    public partial class FrmSpiel : Form
    {
        Queue<PictureBox> schlange;
        PictureBox kopf;
        int dx, dy;
        int wachsenCount;        
        List<PictureBox> aepfel;
        
        int countdown;

        int punkte;
        readonly String connStr = ConfigurationManager.ConnectionStrings["SnakeDB"].ConnectionString;

        public FrmSpiel()
        {
            InitializeComponent();

        }

        private void Init()
        {
            countdown = 20;
            punkte = 0;
            schlange = new Queue<PictureBox>(10 * 6);
            aepfel = new List<PictureBox>(10);
            kopf = new PictureBox
            {
                BackColor = Color.Lime,
                Location = new Point(pnlSpiel.Width / 2, pnlSpiel.Height / 2),
                Size = new Size(20, 20)
            };
            dx = kopf.Size.Width;
            dy = 0;
            //schlange.Add(kopf);
            pnlSpiel.Controls.Add(kopf);
            wachsenCount = 0;
            Random rand = new Random();
            ResourceManager rm = Snake.Properties.Resources.ResourceManager;
            for (int i = 0; i < 10; i++)
            {

                PictureBox apfel = new PictureBox
                {
                    Tag = rand.Next(2, 10),
                    BackColor = Color.Red
                };

                int seite = 40;
                apfel.Size = new Size(seite, seite);
                apfel.Location = new Point(rand.Next(0, pnlSpiel.Width - seite), rand.Next(0, pnlSpiel.Height - seite));
                
                aepfel.Add(apfel);
                pnlSpiel.Controls.Add(apfel);
                apfel.Image = new Bitmap((Image)rm.GetObject("Apfel" + apfel.Tag), new Size(seite, seite));
            }

            tmrSpiel.Interval = 200;
            tmrCountdown.Interval = 1000;
            txtInfo.Text = "Viel Spass!";
            
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {

            int dx, dy; //lokale Variablen zum Zwischenspeichern
            dx = kopf.Width;
            dy = 0;
            switch (keyData)
            {
                case Keys.Left:
                    dy = 0;
                    dx = -kopf.Width;
                    break;
                case Keys.Right:
                    dy = 0;
                    dx = kopf.Width;
                    break;
                case Keys.Up:
                    dx = 0;
                    dy = -kopf.Width;
                    break;
                case Keys.Down:
                    dx = 0;
                    dy = kopf.Width;
                    break;

                //default: return base.ProcessDialogKey(keyData);

            }
            if (dx != this.dx && dy != this.dy)
            {
                this.dx = dx;
                this.dy = dy;
                return true;
            }

            return base.ProcessDialogKey(keyData); // ein zweites Mal
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvPunkte.AutoGenerateColumns = false;
            // TODO: Diese Codezeile lädt Daten in die Tabelle "snakeDBDataSet.Spiel". Sie können sie bei Bedarf verschieben oder entfernen.
            DgvPunkte_Refresh();
            Init();
        }

        private void DgvPunkte_Refresh()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand sqlcmd = new SqlCommand())
                {
                    sqlcmd.Connection = conn;
                    sqlcmd.CommandText = "SELECT Punkte FROM dbo.Spiel;";
                    SqlDataReader rd = sqlcmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    dgvPunkte.DataSource = dt;
                    rd.Close();
                }
            }
        }

        private void TmrSpiel_Tick(object sender, EventArgs e)
        {

            //Schlange bewegt sich weiter
            //Zwei verschiedene Algorithmen:
            //1. Kopf bewegt sich nach dx und dy
            //2. letztes Element kommt an alte Kopfposition
            Point posAlt = kopf.Location;
            kopf.Location = new Point(kopf.Location.X + dx, kopf.Location.Y + dy);           
            if(schlange.Count > 0)
            {
                var letzte = schlange.Dequeue();
                
                letzte.Location = posAlt;

                schlange.Enqueue(letzte);
            }
                
            /*foreach (var element in schlange)
            {
                Point posNeu = element.Location;
                element.Location = posAlt;
                posAlt = posNeu;
            }*/

            pnlSpiel.Refresh();

            if (kopf.Location.X < 0 || 
                kopf.Location.Y < 0 || 
                kopf.Location.X > pnlSpiel.Width - kopf.Width || 
                kopf.Location.Y > pnlSpiel.Height - kopf.Height)
            {
                tmrSpiel.Stop();
                tmrCountdown.Stop();
                txtInfo.Text = "Kollision mit Rand!";

            }
            foreach(PictureBox element in schlange)
            {
                if (kopf.Bounds.IntersectsWith(element.Bounds))
                {
                    tmrCountdown.Stop();
                    tmrSpiel.Stop();
                    txtInfo.Text = "Kollision mit sich selbst!";
                }
            }
            foreach(PictureBox apfel in aepfel)
            {
                if (apfel.Bounds.IntersectsWith(kopf.Bounds))
                {
                    //Essen
                    //Apfel verschwindet
                    aepfel.Remove(apfel);
                    pnlSpiel.Controls.Remove(apfel);
                    //Hat um "Tag" zusätzlich zu wachsen IN DER ZUKUNFT, ein Element pro Durchlauf!                        
                    wachsenCount += (int) apfel.Tag;
                    punkte += (int)apfel.Tag;
                    txtPunkte.Text = "" + punkte;
                    txtInfo.Text = "Mampf";
                    if(aepfel.Count <= 0)
                    {
                        tmrCountdown.Stop();
                        tmrSpiel.Stop();
                        txtInfo.Text = "Gewonnen bzw. fertig!";
                    }
                    //bewegen
                    break;
                }
            }

            
            
            if(wachsenCount > 0)
            {
                PictureBox element = new PictureBox
                {
                    BackColor = Color.Green,
                    Location = posAlt
                };
                //element.Location = new Point(50, 50);
                element.Size = new Size(20, 20);
                schlange.Enqueue(item: element);
                pnlSpiel.Controls.Add(element);
                wachsenCount--;
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            tmrSpiel.Start();
            tmrCountdown.Start();
            pnlSpiel.Focus();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            pnlSpiel.Controls.Clear();
            Init();
        }

        private void TmrCountdown_Tick(object sender, EventArgs e)
        {
            if(countdown > 0)
            {
                countdown--;
                txtCountdown.Text = ""+countdown;
            }
            else
            {
                tmrCountdown.Stop();
                tmrSpiel.Stop();                
            }
            
        }




        private void BtnPunkte_Click(object sender, EventArgs e)
        {
            int punkt = Int32.Parse(txtPunkte.Text);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand sqlcmd = new SqlCommand())
                {
                    sqlcmd.Connection = conn;
                    sqlcmd.CommandText = $"INSERT INTO dbo.Spiel VALUES( { punkt } );";
                    sqlcmd.ExecuteReader();

                }

                
            }

            DgvPunkte_Refresh();
            //Form1_Load(sender, e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int dx, dy;
            dx = 1;
            dy = 0;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    dy = 0;
                    dx = -kopf.Width;
                    break;
                case Keys.Right:
                    dy = 0;
                    dx = kopf.Width;
                    break;
                case Keys.Up:
                    dx = 0;
                    dy = -kopf.Width;
                    break;
                case Keys.Down:
                    dx = 0;
                    dy = kopf.Width;
                    break;
            }
            if(dx != this.dx && dy != this.dy)
            {
                this.dx = dx;
                this.dy = dy;
            }

        }
    }
}
