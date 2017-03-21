using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lohnabrechnungssystem
    {
    public partial class Meldung : Form
    {
        public String Informationstring = "";
        public Meldung()
            {
            InitializeComponent();
            }

        private void label1_Click(object sender, EventArgs e)
            {

            }

        private void Erfolgreich_Load(object sender, EventArgs e)
        {
            label1.Text = Informationstring;
        }

        private void button10_Click(object sender, EventArgs e)
            {
            Close();
            }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
            {
            Close();
            }
        }
    }
