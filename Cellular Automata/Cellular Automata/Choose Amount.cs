using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cellular_Automata
{
    public partial class Choose_Amount : Form
    {
        public Choose_Amount()
        {
            InitializeComponent();
        }
        public string EnteredText
        {
            get
            {
                return Input.Text;
            }
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(this.Input.Text) >= 0)
                    this.Input.BackColor = Color.White;
                else
                    this.Input.BackColor = Color.Red;
            }
            catch (Exception)
            {
                this.Input.BackColor = Color.Red;
            }
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Input.BackColor != Color.Red)
                this.Close();
        }
    }
}
