using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OfficeValidationLib.Classes.Session;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var sessionBuilder = new SessionBuilder();
            var session = sessionBuilder.Build(@"C:\Projects\OfficeValidation\config.json", new List<IDocument>());
        }
    }
}
