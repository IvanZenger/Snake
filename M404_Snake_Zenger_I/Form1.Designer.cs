namespace M404_Snake_Zenger_I
{
    partial class Form1
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlSpiel = new System.Windows.Forms.Panel();
            this.picSnake = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblPunkte = new System.Windows.Forms.Label();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.tmrSnake = new System.Windows.Forms.Timer(this.components);
            this.tmrCountdown = new System.Windows.Forms.Timer(this.components);
            this.txtPunkte = new System.Windows.Forms.TextBox();
            this.txtCountdown = new System.Windows.Forms.TextBox();
            this.lblPunktelisteTitel = new System.Windows.Forms.Label();
            this.btnPunkteEintragen = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblPunkteliste = new System.Windows.Forms.Label();
            this.pnlSpiel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.picSnake)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSpiel
            // 
            this.pnlSpiel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pnlSpiel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSpiel.Controls.Add(this.picSnake);
            this.pnlSpiel.Location = new System.Drawing.Point(53, 61);
            this.pnlSpiel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.pnlSpiel.Name = "pnlSpiel";
            this.pnlSpiel.Size = new System.Drawing.Size(900, 660);
            this.pnlSpiel.TabIndex = 0;
            // 
            // picSnake
            // 
            this.picSnake.BackColor = System.Drawing.Color.DarkGreen;
            this.picSnake.Location = new System.Drawing.Point(440, 300);
            this.picSnake.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.picSnake.Name = "picSnake";
            this.picSnake.Size = new System.Drawing.Size(30, 30);
            this.picSnake.TabIndex = 0;
            this.picSnake.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Maroon;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(53, 746);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(168, 78);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Maroon;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(229, 746);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(184, 78);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblPunkte
            // 
            this.lblPunkte.AutoSize = true;
            this.lblPunkte.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblPunkte.ForeColor = System.Drawing.Color.White;
            this.lblPunkte.Location = new System.Drawing.Point(1073, 61);
            this.lblPunkte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPunkte.Name = "lblPunkte";
            this.lblPunkte.Size = new System.Drawing.Size(77, 25);
            this.lblPunkte.TabIndex = 3;
            this.lblPunkte.Text = "Punkte:";
            // 
            // lblCountdown
            // 
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCountdown.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblCountdown.ForeColor = System.Drawing.Color.White;
            this.lblCountdown.Location = new System.Drawing.Point(1042, 118);
            this.lblCountdown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(115, 25);
            this.lblCountdown.TabIndex = 4;
            this.lblCountdown.Text = "Countdown:";
            this.lblCountdown.Click += new System.EventHandler(this.lblCountdown_Click);
            // 
            // tmrSnake
            // 
            this.tmrSnake.Tick += new System.EventHandler(this.tmrSnake_Tick);
            // 
            // tmrCountdown
            // 
            this.tmrCountdown.Interval = 1000;
            this.tmrCountdown.Tick += new System.EventHandler(this.tmrCountdown_Tick);
            // 
            // txtPunkte
            // 
            this.txtPunkte.BackColor = System.Drawing.Color.DarkSlateGray;
            this.txtPunkte.Enabled = false;
            this.txtPunkte.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtPunkte.ForeColor = System.Drawing.Color.White;
            this.txtPunkte.Location = new System.Drawing.Point(1176, 61);
            this.txtPunkte.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtPunkte.Name = "txtPunkte";
            this.txtPunkte.Size = new System.Drawing.Size(108, 31);
            this.txtPunkte.TabIndex = 5;
            this.txtPunkte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCountdown
            // 
            this.txtCountdown.BackColor = System.Drawing.Color.DarkSlateGray;
            this.txtCountdown.Enabled = false;
            this.txtCountdown.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtCountdown.ForeColor = System.Drawing.Color.White;
            this.txtCountdown.Location = new System.Drawing.Point(1176, 111);
            this.txtCountdown.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtCountdown.Name = "txtCountdown";
            this.txtCountdown.Size = new System.Drawing.Size(108, 31);
            this.txtCountdown.TabIndex = 6;
            this.txtCountdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPunktelisteTitel
            // 
            this.lblPunktelisteTitel.AutoSize = true;
            this.lblPunktelisteTitel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblPunktelisteTitel.ForeColor = System.Drawing.Color.White;
            this.lblPunktelisteTitel.Location = new System.Drawing.Point(1011, 196);
            this.lblPunktelisteTitel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPunktelisteTitel.Name = "lblPunktelisteTitel";
            this.lblPunktelisteTitel.Size = new System.Drawing.Size(117, 25);
            this.lblPunktelisteTitel.TabIndex = 7;
            this.lblPunktelisteTitel.Text = "Punkteliste: ";
            // 
            // btnPunkteEintragen
            // 
            this.btnPunkteEintragen.BackColor = System.Drawing.Color.Maroon;
            this.btnPunkteEintragen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnPunkteEintragen.ForeColor = System.Drawing.Color.White;
            this.btnPunkteEintragen.Location = new System.Drawing.Point(1011, 656);
            this.btnPunkteEintragen.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPunkteEintragen.Name = "btnPunkteEintragen";
            this.btnPunkteEintragen.Size = new System.Drawing.Size(289, 65);
            this.btnPunkteEintragen.TabIndex = 9;
            this.btnPunkteEintragen.Text = "Punkte in Liste Eintragen";
            this.btnPunkteEintragen.UseVisualStyleBackColor = false;
            this.btnPunkteEintragen.Click += new System.EventHandler(this.btnPunkteEintragen_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(53, 9);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(84, 38);
            this.lblInfo.TabIndex = 10;
            this.lblInfo.Text = "INFO";
            // 
            // lblPunkteliste
            // 
            this.lblPunkteliste.BackColor = System.Drawing.Color.DarkSlateGray;
            this.lblPunkteliste.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPunkteliste.Enabled = false;
            this.lblPunkteliste.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblPunkteliste.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblPunkteliste.Location = new System.Drawing.Point(1011, 230);
            this.lblPunkteliste.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPunkteliste.Name = "lblPunkteliste";
            this.lblPunkteliste.Size = new System.Drawing.Size(289, 408);
            this.lblPunkteliste.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1337, 850);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnPunkteEintragen);
            this.Controls.Add(this.lblPunkteliste);
            this.Controls.Add(this.lblPunktelisteTitel);
            this.Controls.Add(this.txtCountdown);
            this.Controls.Add(this.txtPunkte);
            this.Controls.Add(this.lblCountdown);
            this.Controls.Add(this.lblPunkte);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pnlSpiel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(22, 22);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Snake";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlSpiel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.picSnake)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlSpiel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblPunkte;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.PictureBox picSnake;
        private System.Windows.Forms.Timer tmrSnake;
        private System.Windows.Forms.TextBox txtPunkte;
        private System.Windows.Forms.TextBox txtCountdown;
        private System.Windows.Forms.Label lblPunktelisteTitel;
        private System.Windows.Forms.Button btnPunkteEintragen;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblPunkteliste;
        private System.Windows.Forms.Timer tmrCountdown;
    }
}

