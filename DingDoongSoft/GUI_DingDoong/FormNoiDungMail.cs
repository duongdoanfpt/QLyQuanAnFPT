﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_DingDoong
{
    public partial class FormNoiDungMail : Form
    {
        public FormNoiDungMail()
        {
            InitializeComponent();
            txtNoiDung.Text = noidungMail;
        }

        public static string noidungMail;


    }
}
