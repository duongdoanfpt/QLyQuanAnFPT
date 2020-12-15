
namespace GUI_DingDoong
{
    partial class FormKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKhachHang));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbThongKe = new System.Windows.Forms.PictureBox();
            this.pbBan = new System.Windows.Forms.PictureBox();
            this.pbKhachHang = new System.Windows.Forms.PictureBox();
            this.pbNhanVien = new System.Windows.Forms.PictureBox();
            this.pbHome = new System.Windows.Forms.PictureBox();
            this.lblUsers = new System.Windows.Forms.Label();
            this.pbThucDon = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btThoat = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.btCapNhat = new System.Windows.Forms.Button();
            this.btBoQua = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.rdNu = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThucDon)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 972F));
            this.tableLayoutPanel1.Controls.Add(this.pbThongKe, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbBan, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbKhachHang, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbNhanVien, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbHome, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUsers, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbThucDon, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1262, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pbThongKe
            // 
            this.pbThongKe.Image = global::GUI_DingDoong.Properties.Resources.Fasticon_Database_Table_edit1;
            this.pbThongKe.Location = new System.Drawing.Point(218, 6);
            this.pbThongKe.Name = "pbThongKe";
            this.pbThongKe.Size = new System.Drawing.Size(44, 38);
            this.pbThongKe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbThongKe.TabIndex = 5;
            this.pbThongKe.TabStop = false;
            this.pbThongKe.Click += new System.EventHandler(this.pbThongKe_Click);
            this.pbThongKe.MouseEnter += new System.EventHandler(this.pbThongKe_MouseEnter);
            this.pbThongKe.MouseLeave += new System.EventHandler(this.pbThongKe_MouseLeave);
            // 
            // pbBan
            // 
            this.pbBan.Image = global::GUI_DingDoong.Properties.Resources.Chrisl21_Minecraft_Crafting_Table2;
            this.pbBan.Location = new System.Drawing.Point(165, 6);
            this.pbBan.Name = "pbBan";
            this.pbBan.Size = new System.Drawing.Size(44, 38);
            this.pbBan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbBan.TabIndex = 4;
            this.pbBan.TabStop = false;
            this.pbBan.Click += new System.EventHandler(this.pbBan_Click);
            this.pbBan.MouseEnter += new System.EventHandler(this.pbBan_MouseEnter);
            this.pbBan.MouseLeave += new System.EventHandler(this.pbBan_MouseLeave);
            // 
            // pbKhachHang
            // 
            this.pbKhachHang.Image = global::GUI_DingDoong.Properties.Resources.Hopstarter_Sleek_Xp_Basic_User_Group2;
            this.pbKhachHang.Location = new System.Drawing.Point(112, 6);
            this.pbKhachHang.Name = "pbKhachHang";
            this.pbKhachHang.Size = new System.Drawing.Size(44, 38);
            this.pbKhachHang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbKhachHang.TabIndex = 3;
            this.pbKhachHang.TabStop = false;
            this.pbKhachHang.Click += new System.EventHandler(this.pbKhachHang_Click);
            this.pbKhachHang.MouseEnter += new System.EventHandler(this.pbKhachHang_MouseEnter);
            this.pbKhachHang.MouseLeave += new System.EventHandler(this.pbKhachHang_MouseLeave);
            // 
            // pbNhanVien
            // 
            this.pbNhanVien.Image = global::GUI_DingDoong.Properties.Resources.Icons_Land_Vista_People_Office_Customer_Male_Light1;
            this.pbNhanVien.Location = new System.Drawing.Point(59, 6);
            this.pbNhanVien.Name = "pbNhanVien";
            this.pbNhanVien.Size = new System.Drawing.Size(44, 38);
            this.pbNhanVien.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbNhanVien.TabIndex = 2;
            this.pbNhanVien.TabStop = false;
            this.pbNhanVien.Click += new System.EventHandler(this.pbNhanVien_Click);
            this.pbNhanVien.MouseEnter += new System.EventHandler(this.pbNhanVien_MouseEnter);
            this.pbNhanVien.MouseLeave += new System.EventHandler(this.pbNhanVien_MouseLeave);
            // 
            // pbHome
            // 
            this.pbHome.Image = global::GUI_DingDoong.Properties.Resources.Apathae_Chakram_2_Home1;
            this.pbHome.Location = new System.Drawing.Point(6, 6);
            this.pbHome.Name = "pbHome";
            this.pbHome.Size = new System.Drawing.Size(44, 38);
            this.pbHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbHome.TabIndex = 1;
            this.pbHome.TabStop = false;
            this.pbHome.Click += new System.EventHandler(this.pbHome_Click);
            this.pbHome.MouseEnter += new System.EventHandler(this.pbHome_MouseEnter);
            this.pbHome.MouseLeave += new System.EventHandler(this.pbHome_MouseLeave);
            // 
            // lblUsers
            // 
            this.lblUsers.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUsers.AutoSize = true;
            this.lblUsers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsers.Location = new System.Drawing.Point(1127, 14);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(162, 21);
            this.lblUsers.TabIndex = 6;
            this.lblUsers.Text = "email123@gmail.com";
            // 
            // pbThucDon
            // 
            this.pbThucDon.Image = global::GUI_DingDoong.Properties.Resources.Flameia_Rabbit_Xp_Apple_menu2;
            this.pbThucDon.Location = new System.Drawing.Point(271, 6);
            this.pbThucDon.Name = "pbThucDon";
            this.pbThucDon.Size = new System.Drawing.Size(43, 38);
            this.pbThucDon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbThucDon.TabIndex = 7;
            this.pbThucDon.TabStop = false;
            this.pbThucDon.Click += new System.EventHandler(this.pbThucDon_Click);
            this.pbThucDon.MouseEnter += new System.EventHandler(this.pbThucDon_MouseEnter);
            this.pbThucDon.MouseLeave += new System.EventHandler(this.pbThucDon_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel5);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.tableLayoutPanel4);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Location = new System.Drawing.Point(1, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1262, 628);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 5;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.99999F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.btThoat, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.btLuu, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btThem, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btCapNhat, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.btBoQua, 3, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(5, 102);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1262, 42);
            this.tableLayoutPanel5.TabIndex = 16;
            // 
            // btThoat
            // 
            this.btThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btThoat.FlatAppearance.BorderSize = 0;
            this.btThoat.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThoat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.Image = global::GUI_DingDoong.Properties.Resources.Custom_Icon_Design_Pretty_Office_11_Logout3;
            this.btThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThoat.Location = new System.Drawing.Point(1082, 3);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(106, 36);
            this.btThoat.TabIndex = 11;
            this.btThoat.Text = "Trở về";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // btLuu
            // 
            this.btLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btLuu.FlatAppearance.BorderSize = 0;
            this.btLuu.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLuu.Image = global::GUI_DingDoong.Properties.Resources.Custom_Icon_Design_Pretty_Office_7_Save3;
            this.btLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLuu.Location = new System.Drawing.Point(323, 3);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(109, 36);
            this.btLuu.TabIndex = 3;
            this.btLuu.Text = "Lưu";
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // btThem
            // 
            this.btThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btThem.FlatAppearance.BorderSize = 0;
            this.btThem.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.Image = global::GUI_DingDoong.Properties.Resources.Hopstarter_Soft_Scraps_Button_Add__1___1_3;
            this.btThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThem.Location = new System.Drawing.Point(75, 3);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(102, 36);
            this.btThem.TabIndex = 1;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // btCapNhat
            // 
            this.btCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btCapNhat.FlatAppearance.BorderSize = 0;
            this.btCapNhat.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCapNhat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCapNhat.Image = global::GUI_DingDoong.Properties.Resources.Oxygen_Icons3;
            this.btCapNhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCapNhat.Location = new System.Drawing.Point(573, 3);
            this.btCapNhat.Name = "btCapNhat";
            this.btCapNhat.Size = new System.Drawing.Size(113, 36);
            this.btCapNhat.TabIndex = 7;
            this.btCapNhat.Text = "Cập nhật";
            this.btCapNhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCapNhat.UseVisualStyleBackColor = true;
            this.btCapNhat.Click += new System.EventHandler(this.btCapNhat_Click);
            // 
            // btBoQua
            // 
            this.btBoQua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btBoQua.FlatAppearance.BorderSize = 0;
            this.btBoQua.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btBoQua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBoQua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBoQua.Image = global::GUI_DingDoong.Properties.Resources.Oxygen_Icons_13;
            this.btBoQua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBoQua.Location = new System.Drawing.Point(827, 3);
            this.btBoQua.Name = "btBoQua";
            this.btBoQua.Size = new System.Drawing.Size(110, 36);
            this.btBoQua.TabIndex = 9;
            this.btBoQua.Text = "Bỏ qua";
            this.btBoQua.UseVisualStyleBackColor = true;
            this.btBoQua.Click += new System.EventHandler(this.btBoQua_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-1, 191);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1254, 423);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Click += new System.EventHandler(this.DgvKhach_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.10501F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.512331F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.5529F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.78282F));
            this.tableLayoutPanel4.Controls.Add(this.btTimKiem, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtTimKiem, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(5, 147);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1253, 44);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // btTimKiem
            // 
            this.btTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btTimKiem.FlatAppearance.BorderSize = 0;
            this.btTimKiem.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTimKiem.Location = new System.Drawing.Point(305, 3);
            this.btTimKiem.Name = "btTimKiem";
            this.btTimKiem.Size = new System.Drawing.Size(100, 38);
            this.btTimKiem.TabIndex = 12;
            this.btTimKiem.Text = "Tìm kiếm";
            this.btTimKiem.UseVisualStyleBackColor = true;
            this.btTimKiem.Click += new System.EventHandler(this.btTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(3, 5);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(296, 33);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.Text = "Nhập tên khách hàng để tìm kiếm";
            this.txtTimKiem.Click += new System.EventHandler(this.txtTimKiem_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.96713F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.73807F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.63664F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.3521F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.29785F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 233F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.dtpNgaySinh, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.rdNu, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtSDT, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtTen, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtEmail, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.rdNam, 5, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1252, 96);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgaySinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(162, 57);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(264, 29);
            this.dtpNgaySinh.TabIndex = 11;
            // 
            // rdNu
            // 
            this.rdNu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rdNu.AutoSize = true;
            this.rdNu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNu.Location = new System.Drawing.Point(1019, 3);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(55, 42);
            this.rdNu.TabIndex = 10;
            this.rdNu.TabStop = true;
            this.rdNu.Text = "Nữ";
            this.rdNu.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(838, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Giới tính : ";
            // 
            // txtSDT
            // 
            this.txtSDT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(569, 7);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(261, 33);
            this.txtSDT.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(432, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 48);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số điện thoại : ";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên khách hàng : ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày sinh : ";
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(162, 7);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(264, 33);
            this.txtTen.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(432, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Email : ";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(569, 55);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(261, 33);
            this.txtEmail.TabIndex = 7;
            // 
            // rdNam
            // 
            this.rdNam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rdNam.AutoSize = true;
            this.rdNam.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNam.Location = new System.Drawing.Point(942, 3);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(70, 42);
            this.rdNam.TabIndex = 9;
            this.rdNam.TabStop = true;
            this.rdNam.Text = "Nam";
            this.rdNam.UseVisualStyleBackColor = true;
            // 
            // FormKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý khách hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormKhachHang_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThucDon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbHome;
        private System.Windows.Forms.PictureBox pbNhanVien;
        private System.Windows.Forms.PictureBox pbKhachHang;
        private System.Windows.Forms.PictureBox pbBan;
        private System.Windows.Forms.PictureBox pbThongKe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton rdNu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btTimKiem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Button btBoQua;
        private System.Windows.Forms.Button btCapNhat;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.PictureBox pbThucDon;
    }
}