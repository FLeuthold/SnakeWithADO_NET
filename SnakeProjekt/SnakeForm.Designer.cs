//INF2018c, Fabio Leuthold, 26.05.2019

namespace Snake
{
    partial class FrmSpiel
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label punkteLabel;
            this.pnlSpiel = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.txtCountdown = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.tmrSpiel = new System.Windows.Forms.Timer(this.components);
            this.tmrCountdown = new System.Windows.Forms.Timer(this.components);
            this.dgvPunkte = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPunkte = new System.Windows.Forms.TextBox();
            this.btnPunkte = new System.Windows.Forms.Button();
            punkteLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPunkte)).BeginInit();
            this.SuspendLayout();
            // 
            // punkteLabel
            // 
            punkteLabel.AutoSize = true;
            punkteLabel.Location = new System.Drawing.Point(659, 166);
            punkteLabel.Name = "punkteLabel";
            punkteLabel.Size = new System.Drawing.Size(56, 17);
            punkteLabel.TabIndex = 12;
            punkteLabel.Text = "Punkte:";
            // 
            // pnlSpiel
            // 
            this.pnlSpiel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.pnlSpiel.Location = new System.Drawing.Point(16, 89);
            this.pnlSpiel.Name = "pnlSpiel";
            this.pnlSpiel.Size = new System.Drawing.Size(576, 381);
            this.pnlSpiel.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(16, 507);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(88, 41);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // lblCountdown
            // 
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.Location = new System.Drawing.Point(604, 65);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(82, 17);
            this.lblCountdown.TabIndex = 6;
            this.lblCountdown.Text = "Countdown:";
            // 
            // txtCountdown
            // 
            this.txtCountdown.Enabled = false;
            this.txtCountdown.Location = new System.Drawing.Point(696, 62);
            this.txtCountdown.Name = "txtCountdown";
            this.txtCountdown.Size = new System.Drawing.Size(82, 22);
            this.txtCountdown.TabIndex = 7;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(130, 509);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 38);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Enabled = false;
            this.txtInfo.Location = new System.Drawing.Point(16, 46);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(574, 22);
            this.txtInfo.TabIndex = 11;
            this.txtInfo.Text = "Hallo";
            // 
            // tmrSpiel
            // 
            this.tmrSpiel.Tick += new System.EventHandler(this.TmrSpiel_Tick);
            // 
            // tmrCountdown
            // 
            this.tmrCountdown.Tick += new System.EventHandler(this.TmrCountdown_Tick);
            // 
            // dgvPunkte
            // 
            this.dgvPunkte.AllowUserToDeleteRows = false;
            this.dgvPunkte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPunkte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dgvPunkte.Location = new System.Drawing.Point(670, 209);
            this.dgvPunkte.Name = "dgvPunkte";
            this.dgvPunkte.ReadOnly = true;
            this.dgvPunkte.RowHeadersWidth = 51;
            this.dgvPunkte.RowTemplate.Height = 24;
            this.dgvPunkte.Size = new System.Drawing.Size(193, 230);
            this.dgvPunkte.TabIndex = 13;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Punkte";
            this.dataGridViewTextBoxColumn1.HeaderText = "Punkte";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // txtPunkte
            // 
            this.txtPunkte.Enabled = false;
            this.txtPunkte.Location = new System.Drawing.Point(739, 161);
            this.txtPunkte.Name = "txtPunkte";
            this.txtPunkte.Size = new System.Drawing.Size(124, 22);
            this.txtPunkte.TabIndex = 14;
            // 
            // btnPunkte
            // 
            this.btnPunkte.Location = new System.Drawing.Point(660, 476);
            this.btnPunkte.Name = "btnPunkte";
            this.btnPunkte.Size = new System.Drawing.Size(202, 33);
            this.btnPunkte.TabIndex = 15;
            this.btnPunkte.Text = "Punkte eintragen";
            this.btnPunkte.UseVisualStyleBackColor = true;
            this.btnPunkte.Click += new System.EventHandler(this.BtnPunkte_Click);
            // 
            // FrmSpiel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 572);
            this.Controls.Add(this.btnPunkte);
            this.Controls.Add(this.txtPunkte);
            this.Controls.Add(this.dgvPunkte);
            this.Controls.Add(punkteLabel);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtCountdown);
            this.Controls.Add(this.lblCountdown);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pnlSpiel);
            this.KeyPreview = true;
            this.Name = "FrmSpiel";
            this.Text = "Snake";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPunkte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlSpiel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.TextBox txtCountdown;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Timer tmrSpiel;
        private System.Windows.Forms.Timer tmrCountdown;
        private System.Windows.Forms.DataGridView dgvPunkte;
        private System.Windows.Forms.TextBox txtPunkte;
        private System.Windows.Forms.Button btnPunkte;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}

