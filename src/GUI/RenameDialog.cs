using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw.src.GUI
{
    public partial class RenameDialog : Form
    {
        public string ShapeName { get; private set; }

        public RenameDialog(string currentName)
        {
            InitializeComponent();
            textBox1.Text = currentName;
        }

        private void RenameDialog_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ShapeName = textBox1.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
