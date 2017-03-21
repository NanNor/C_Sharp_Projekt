using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaultTecToolkit;

namespace Lohnabrechnungssystem
    {
    public partial class MitarbeiterAnzeigen : Form
        {
        SQL sql = new SQL();
        List<Object> Mitarbeiterauflisten = new List<Object>();
        List<Object> Abrechnungsnummern = new List<Object>();
        List<Object> Abteilungen = new List<Object>();
        List<Object> Abteilungsnummern = new List<Object>();
        int Attributes = 4;
        Boolean loop = true;
        public MitarbeiterAnzeigen()
            {
            InitializeComponent();
            sql.OpenCon();
            }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect, // x-coordinate of upper-left corner
           int nTopRect, // y-coordinate of upper-left corner
           int nRightRect, // x-coordinate of lower-right corner
           int nBottomRect, // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
       );
        private void MitarbeiterAnzeigen_Load(object sender, EventArgs e)
        {
            button4.FlatAppearance.BorderColor = Color.DarkSlateGray;
          
            button10.FlatAppearance.BorderColor = Color.DarkSlateGray;
            loop = true;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, 455, 409, 20, 20));
            var cst = new CustomColorTable();
            menuStrip1.Renderer = new myRenderer(cst);
            Mitarbeiterauflisten =
                sql.dataReader("Select MA_Abrechnungsnummer,  Mitarbeitervorname, Mitarbeiternachname, Abteilungsnummer from Mitarbeiter where Aktiv = true order by MA_Abrechnungsnummer",
                    Attributes, new string[] {"Int32", "String", "String","Int32"});
           Abrechnungsnummern =  sql.dataReader("Select MA_Abrechnungsnummer from Mitarbeiter order by MA_Abrechnungsnummer",
                    1, new string[] { "Int32"});
            for (int i = 0; i < Mitarbeiterauflisten.Count / Attributes; i++)
            {
                listBox1.Items.Add(Mitarbeiterauflisten[i*Attributes]);
            }
            int nextAbrNr;
            for (int i = 1; loop; i++)
                {
                if (!Abrechnungsnummern.Contains(i))  // Die Liste Abrechnungsnummern enthält alle Nummern, auch die, 
                    //die "entfernt wurden" (Sind in der Datenbank jedoch noch anzutreffen und die Lohnabrechnungen auch)
                    {
                    nextAbrNr = i;
                    textBox6.Text = nextAbrNr.ToString();
                    loop = false;
                    }
                }
            
            
            textBox8.Text = "Vornamen eintragen";
            textBox7.Text = "Nachnamen eintragen";

            Abteilungsnummern = sql.dataReader("Select Abteilungnummer from Abteilung", 1, new string[] { "Int32" });
            Abteilungen = sql.dataReader("Select Abteilungsname from Abteilung", 1, new string[] {"String"});
            for (int i = 0; i < Abteilungen.Count; i++)
            {
                comboBox1.Items.Add(Abteilungen[i].ToString());
                comboBox2.Items.Add(Abteilungen[i].ToString());
            }
            if(comboBox1.Items.Count == 0)
            {
                MessageBox.Show("Keine Abteilung im System, bitte fügen Sie zuerst eine Abteilung hinzu","Fehler",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
             
            }
       

            

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = false;
            loop = true;
            for (int i = 0,j = 0; i < Mitarbeiterauflisten.Count / Attributes && loop; i++,j = (i)*Attributes)
            {
                if (Mitarbeiterauflisten[j] == listBox1.SelectedItem)
                {
                    textBox1.Text = Mitarbeiterauflisten[j+ 1].ToString();
                    textBox2.Text = Mitarbeiterauflisten[j+ 2].ToString();
                    Abteilungen = sql.dataReader(String.Format("Select Abteilungsname from Abteilung where Abteilungnummer = {0}", Mitarbeiterauflisten[j+3]), 1, new string[] { "String" });
                    comboBox2.Text = Abteilungen[0].ToString();
                    loop = false;
                }
            }
            
            }

        private void button10_Click(object sender, EventArgs e)
            {
            sql.CloseCon();
            Close();
            }

        private void button1_Click(object sender, EventArgs e)
            {
            Close();
            }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
            }

        private void textBox8_MouseClick(object sender, MouseEventArgs e)
            {
            textBox8.SelectAll();
            }

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
            {
            textBox7.SelectAll();
            }

        private void Hinzufügen_Click(object sender, EventArgs e)
            {

            }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                
                }
            }

        private void button6_Click(object sender, EventArgs e)
            {
            try
            {
                Abteilungen = sql.dataReader(String.Format("Select Abteilungnummer from Abteilung where Abteilungsname = '{0}'", comboBox1.SelectedItem), 1, new string[] { "Int32" });
                sql.execeutenonquery(string.Format("insert into Mitarbeiter(MA_Abrechnungsnummer, Mitarbeitervorname, Mitarbeiternachname, Abteilungsnummer, Aktiv) values ({0},'{1}','{2}',{3}, true)",
                   textBox6.Text, textBox8.Text, textBox7.Text, Abteilungen[0]));
                listBox1.Items.Clear();
                Mitarbeiterauflisten =
            sql.dataReader("Select MA_Abrechnungsnummer,Mitarbeitervorname, Mitarbeiternachname, Abteilungsnummer from Mitarbeiter",
                Attributes, new string[] { "Int32", "String", "String", "Int32" });
                for (int i = 0; i < Mitarbeiterauflisten.Count / Attributes; i++)
                {
                    listBox1.Items.Add(Mitarbeiterauflisten[i * Attributes]);
                }
                Meldung erf = new Meldung();
                erf.Informationstring = "Mitarbeiter wurde erfolgreich erstellt";
                erf.ShowDialog();
                Controls.Clear();
                InitializeComponent();
                MitarbeiterAnzeigen_Load(e, e);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Sie haben keine Abteilung ausgewählt");
            }
            }

        private void textBox7_TextChanged(object sender, EventArgs e)
            {

            }

            private void button7_Click(object sender, EventArgs e)
            {
            DialogResult dialog = MessageBox.Show("Alle zugehörigen Abrechnungen werden entfernt\nFortfahren?", "Warnung", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                
                    sql.execeutenonquery(String.Format("update Mitarbeiter set Aktiv = false where MA_Abrechnungsnummer = {0}",
                           listBox1.SelectedItem));
                    Meldung erf = new Meldung();
                    erf.Informationstring = "Mitarbeiter wurde entfernt";
                    erf.ShowDialog();
                    Controls.Clear();
                    InitializeComponent();
                    MitarbeiterAnzeigen_Load(e, e);
                }
                
            
            
            }

        private void menuStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
            {

            }
        Point _controllerMousePosition;
        Point _globalMousePosition;

        private void menuStrip3_MouseDown(object sender, MouseEventArgs e)
            {
            base.OnMouseDown(e);

            //Absolute Position zum Bildschirmrand
            _globalMousePosition = Control.MousePosition;

            //Absolute Position zum Controllerrand
            _controllerMousePosition = e.Location;
            }

        private void menuStrip3_MouseMove(object sender, MouseEventArgs e)
            {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
                {
                //Neue absolute Position
                Point newGlobalMousePosition = Control.MousePosition;

                //Alte Position + Dif(Neue Position - Alte Position) - Mausposition im Controller
                _globalMousePosition.X += (newGlobalMousePosition.X - _globalMousePosition.X) - _controllerMousePosition.X;
                _globalMousePosition.Y += (newGlobalMousePosition.Y - _globalMousePosition.Y) - _controllerMousePosition.Y;

                //Setzen der neuen Position
                this.Location = _globalMousePosition;
                }
            }

        private void technischerSupportToolStripMenuItem_Click(object sender, EventArgs e)
            {
            Meldung VaultTecService = new Meldung();
            VaultTecService.Informationstring = "Sie können Vault-Tec-Service \nunter 1-888-4-82858-832 erreichen";
            VaultTecService.ShowDialog();
            }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
            {
                //Neue absolute Position
                Point newGlobalMousePosition = Control.MousePosition;

                //Alte Position + Dif(Neue Position - Alte Position) - Mausposition im Controller
                _globalMousePosition.X += (newGlobalMousePosition.X - _globalMousePosition.X) - _controllerMousePosition.X;
                _globalMousePosition.Y += (newGlobalMousePosition.Y - _globalMousePosition.Y) - _controllerMousePosition.Y;

                //Setzen der neuen Position
                this.Location = _globalMousePosition;
            }
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);

            //Absolute Position zum Bildschirmrand
            _globalMousePosition = Control.MousePosition;

            //Absolute Position zum Controllerrand
            _controllerMousePosition = e.Location;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Region = null;
                button1.Text = "▣";
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, 455, 409, 20, 20));
                button1.Text = "▇";
                WindowState = FormWindowState.Normal;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sql.execeutenonquery(String.Format("update Mitarbeiter set Abteilungsnummer = {0} where MA_Abrechnungsnummer = {1}", Abteilungsnummern[comboBox2.SelectedIndex],
                           listBox1.SelectedItem));
            MessageBox.Show("Abteilung geändert");
            Close();
        }
    }
    }