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
    // Mit Rahmen -> Besser erkennbar wenn es sich öffnet und ist ein reines Bestätigungsfeld 
    public partial class LohnabrechnungHinzufügen : Form
    {
        public Boolean Hinzufügen = false;
        public LohnabrechnungHinzufügen()
            {
            InitializeComponent();
            }

        private void LohnabrechnungHinzufügen_Load(object sender, EventArgs e)
            {

            }

        private void button1_Click(object sender, EventArgs e)
        {
            Hinzufügen = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        }
    }
