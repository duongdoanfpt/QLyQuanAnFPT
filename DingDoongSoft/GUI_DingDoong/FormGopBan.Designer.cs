
namespace GUI_DingDoong
{
    partial class FormGopBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGopBan));
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.cbBan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTenBan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.Location = new System.Drawing.Point(298, 306);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(83, 28);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btOK
            // 
            this.btOK.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.Location = new System.Drawing.Point(201, 306);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(83, 28);
            this.btOK.TabIndex = 6;
            this.btOK.Text = "OK ";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // cbBan
            // 
            this.cbBan.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBan.FormattingEnabled = true;
            this.cbBan.Location = new System.Drawing.Point(181, 174);
            this.cbBan.Name = "cbBan";
            this.cbBan.Size = new System.Drawing.Size(233, 33);
            this.cbBan.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Gộp vào bàn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Bàn đã chọn";
            // 
            // lbTenBan
            // 
            this.lbTenBan.AutoSize = true;
            this.lbTenBan.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenBan.ForeColor = System.Drawing.Color.Red;
            this.lbTenBan.Location = new System.Drawing.Point(176, 125);
            this.lbTenBan.Name = "lbTenBan";
            this.lbTenBan.Size = new System.Drawing.Size(127, 25);
            this.lbTenBan.TabIndex = 9;
            this.lbTenBan.Text = "Bàn Đã Chọn";
            this.lbTenBan.Click += new System.EventHandler(this.label3_Click);
            // 
            // FormGopBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(415, 355);
            this.Controls.Add(this.lbTenBan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.cbBan);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGopBan";
            this.Text = "Gộp bàn";
            this.Load += new System.EventHandler(this.FormGopBan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.ComboBox cbBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTenBan;
    }
}