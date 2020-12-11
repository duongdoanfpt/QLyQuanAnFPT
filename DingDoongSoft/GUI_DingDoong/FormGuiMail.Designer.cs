
namespace GUI_DingDoong
{
    partial class FormGuiMail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btGetMail = new System.Windows.Forms.Button();
            this.btTaoND = new System.Windows.Forms.Button();
            this.btGuiMail = new System.Windows.Forms.Button();
            this.dgvKHMail = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKHMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dgvKHMail);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 402);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(357, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Công cụ gửi mail";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.btGuiMail);
            this.panel3.Controls.Add(this.btTaoND);
            this.panel3.Controls.Add(this.btGetMail);
            this.panel3.Location = new System.Drawing.Point(3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(208, 402);
            this.panel3.TabIndex = 1;
            // 
            // btGetMail
            // 
            this.btGetMail.Location = new System.Drawing.Point(39, 169);
            this.btGetMail.Name = "btGetMail";
            this.btGetMail.Size = new System.Drawing.Size(126, 41);
            this.btGetMail.TabIndex = 0;
            this.btGetMail.Text = "Lấy danh sách Email";
            this.btGetMail.UseVisualStyleBackColor = true;
            this.btGetMail.Click += new System.EventHandler(this.btGetMail_Click);
            // 
            // btTaoND
            // 
            this.btTaoND.Location = new System.Drawing.Point(39, 232);
            this.btTaoND.Name = "btTaoND";
            this.btTaoND.Size = new System.Drawing.Size(126, 41);
            this.btTaoND.TabIndex = 1;
            this.btTaoND.Text = "Tạo nội dung";
            this.btTaoND.UseVisualStyleBackColor = true;
            this.btTaoND.Click += new System.EventHandler(this.btTaoND_Click);
            // 
            // btGuiMail
            // 
            this.btGuiMail.Location = new System.Drawing.Point(39, 297);
            this.btGuiMail.Name = "btGuiMail";
            this.btGuiMail.Size = new System.Drawing.Size(126, 41);
            this.btGuiMail.TabIndex = 2;
            this.btGuiMail.Text = "Gửi Mail ";
            this.btGuiMail.UseVisualStyleBackColor = true;
            this.btGuiMail.Click += new System.EventHandler(this.btGuiMail_Click);
            // 
            // dgvKHMail
            // 
            this.dgvKHMail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKHMail.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvKHMail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKHMail.Location = new System.Drawing.Point(217, 80);
            this.dgvKHMail.Name = "dgvKHMail";
            this.dgvKHMail.Size = new System.Drawing.Size(578, 319);
            this.dgvKHMail.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.BackgroundImage = global::GUI_DingDoong.Properties.Resources._2c4d299dffa30efd57b2_removebg;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(23, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 121);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // FormGuiMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 405);
            this.Controls.Add(this.panel1);
            this.Name = "FormGuiMail";
            this.Text = "Gửi Mail Khuyến Mãi";
            this.Load += new System.EventHandler(this.FormGuiMail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKHMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btGuiMail;
        private System.Windows.Forms.Button btTaoND;
        private System.Windows.Forms.Button btGetMail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvKHMail;
    }
}