using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Form
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void OptionsMenu_Load(object sender, EventArgs e)
        {
            txtXSymbol.Text = Properties.Settings.Default.player1;
            txtOSymbol.Text = Properties.Settings.Default.player2;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.player1 = txtXSymbol.Text;
            Properties.Settings.Default.player2 = txtOSymbol.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtXSymbol_TextChanged(object sender, EventArgs e)
        {
            statusBar.Visible = true;
            statusBar.Text = "Restart Required for Changes";
        }

    }
}
