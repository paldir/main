﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZI
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void btSampleData_Click(object sender, EventArgs e)
        {
            SampleDataConfig.GenerateDataBase();
        }

        private void btClearDataBase_Click(object sender, EventArgs e)
        {
            SampleDataConfig.ClearDataBase();
        }
    }
}