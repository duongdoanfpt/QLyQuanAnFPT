namespace GUI_DingDoong
{
    partial class FrmReconnectDataBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReconnectDataBase));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserNam = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAuthentication = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bttest = new System.Windows.Forms.Button();
            this.btok = new System.Windows.Forms.Button();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(82, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(82, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "User Name:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtPassword.Location = new System.Drawing.Point(212, 199);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(281, 23);
            this.txtPassword.TabIndex = 19;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUserNam
            // 
            this.txtUserNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtUserNam.Location = new System.Drawing.Point(212, 155);
            this.txtUserNam.Name = "txtUserNam";
            this.txtUserNam.Size = new System.Drawing.Size(281, 23);
            this.txtUserNam.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(82, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Authentication:";
            // 
            // cmbAuthentication
            // 
            this.cmbAuthentication.BackColor = System.Drawing.Color.White;
            this.cmbAuthentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuthentication.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbAuthentication.FormattingEnabled = true;
            this.cmbAuthentication.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.cmbAuthentication.Location = new System.Drawing.Point(212, 111);
            this.cmbAuthentication.Name = "cmbAuthentication";
            this.cmbAuthentication.Size = new System.Drawing.Size(281, 24);
            this.cmbAuthentication.TabIndex = 16;
            this.cmbAuthentication.SelectedIndexChanged += new System.EventHandler(this.cmbAuthentication_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(257, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "CONNECT DATABASE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Server Name:";
            // 
            // bttest
            // 
            this.bttest.BackColor = System.Drawing.Color.White;
            this.bttest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttest.Location = new System.Drawing.Point(406, 234);
            this.bttest.Name = "bttest";
            this.bttest.Size = new System.Drawing.Size(87, 30);
            this.bttest.TabIndex = 24;
            this.bttest.Text = "Test Connect";
            this.bttest.UseVisualStyleBackColor = false;
            this.bttest.Click += new System.EventHandler(this.bttest_Click);
            // 
            // btok
            // 
            this.btok.BackColor = System.Drawing.Color.White;
            this.btok.Enabled = false;
            this.btok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btok.Location = new System.Drawing.Point(272, 234);
            this.btok.Name = "btok";
            this.btok.Size = new System.Drawing.Size(84, 30);
            this.btok.TabIndex = 23;
            this.btok.Text = "OK";
            this.btok.UseVisualStyleBackColor = false;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(212, 65);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(281, 20);
            this.txtServer.TabIndex = 25;
            // 
            // FrmReconnectDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(628, 276);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.bttest);
            this.Controls.Add(this.btok);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserNam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbAuthentication);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReconnectDataBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết nối CSDL";
            this.Load += new System.EventHandler(this.FrmReconnectDataBase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserNam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAuthentication;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttest;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.TextBox txtServer;
    }
}