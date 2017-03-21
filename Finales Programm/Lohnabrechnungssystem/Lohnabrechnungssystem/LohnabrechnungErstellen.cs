using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaultTecToolkit;

namespace Lohnabrechnungssystem
    {
    public partial class LohnabrechnungErstellen : Form
        {
        public List<String> AusgewählteÜberstunden = new List<string>();
        public List<String> ÜberstundenAnzahl = new List<string>();
        public  List<String> MitarbeiterAusHauptfenster = new List<string>();
        public List<int> Abrechnungsnummern = new List<Int32>();
        List<Object> Lohngruppen = new List<object>();
            List<Object> Arbeitsstunden = new List<object>();
        List<Object> Bonuszahlung = new List<object>();
        List<Object> Überstunden = new List<object>();
        List<int> Überstundensätze = new List<int>();
            SQL sql = new SQL();
        public LohnabrechnungErstellen()
            {
            InitializeComponent();
            sql.OpenCon();
            }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbDataReader databasecontainabrechung =
                    sql.readFromTable(
                        String.Format(
                            "Select * FROM Abrechnung where Abrechnungsnummer = {0} and Abrechnungsdatum like '%{1}.{2}%'",
                            textBox2.Text, dateTimePicker1.Value.Month, dateTimePicker1.Value.Year));
                databasecontainabrechung.Read();
           
            if (!databasecontainabrechung.HasRows)
            {
                LohnabrechnungHinzufügen lrHinzufügen = new LohnabrechnungHinzufügen();
                lrHinzufügen.ShowDialog();
                if (lrHinzufügen.Hinzufügen == true)
                {
                        try
                        {
                            sql.execeutenonquery(
                                String.Format(
                                    "insert into Abrechnung (Abrechnungsnummer, Abrechnungsdatum, Bonuszahlung, Lohngruppennummer, Arbeitsstundennummer) values ({0},'{1}',{2},{3},{4})",
                                    textBox2.Text, dateTimePicker1.Value.ToString("dd.MM.yyyy"),
                                    Bonuszahlung[comboBox1.SelectedIndex * 2], Lohngruppen[comboBox2.SelectedIndex * 3],
                                    Arbeitsstunden[comboBox3.SelectedIndex * 2]));
                            Meldung mld = new Meldung();
                            mld.Informationstring = "Lohnabrechnung erstellt";
                            mld.ShowDialog();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Sie haben nicht alle Felder ausgefüllt");
                        }
                    for (int i = 0; i < Überstundensätze.Count; i++)
                    {
 
                        sql.execeutenonquery(
                            String.Format("insert into Überstunden (Abrechnungsnummer, Abrechnungsdatum,Überstundenkennung, Überstundensatz, Überstundenanzahl) values ({0},'{1}','{2}','{3}',{4})",textBox2.Text, dateTimePicker1.Value.ToString("dd.MM.yyyy"), AusgewählteÜberstunden[i],Überstundensätze[i],ÜberstundenAnzahl[i]));
                        }
                }
                    
            }
            else
            {
                Meldung meldung = new Meldung();
                meldung.Informationstring = "Für diesen Monat wurde eine Abrechnung\nfür "+MitarbeiterAuswählen.SelectedItem+" erstellt";
                meldung.ShowDialog();
                }
            }
            catch (OleDbException)
            {
                MessageBox.Show("Sie haben kein Mitarbeiter ausgewählt\nWählen Sie bitte ein Mitarbeiter aus");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
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
        private void LohnabrechnungErstellen_Load(object sender, EventArgs e)
            {
            button1.FlatAppearance.BorderColor = Color.DarkSlateGray;
            button2.FlatAppearance.BorderColor = Color.DarkSlateGray;
            button10.FlatAppearance.BorderColor = Color.DarkSlateGray;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, 603, 657, 20, 20));
            var cst = new CustomColorTable();
            menuStrip1.Renderer = new myRenderer(cst);
                Lohngruppen = sql.dataReader("Select Lohngruppenummer, Lohngruppenname, Stundensatz FROM Lohngruppe where Aktiv = true", 3,
                    new string[] {"Int32", "String", "Decimal"});
            Arbeitsstunden = sql.dataReader("Select ArbeitsstundenNr,Arbeitsstunden FROM Arbeitsstunden where Aktiv = true", 2,
                   new string[] { "Int32", "Int32" });
             Bonuszahlung = sql.dataReader("Select BonuszahlungID, Prozentsatz FROM Bonuszahlung where Aktiv = true", 2,
                   new string[] { "Int32", "Int32" });
            Überstunden = sql.dataReader("Select Überstundenkennung, Überstundenbezeichnung, Überstundenbonus FROM Überstundenkennung where Aktiv = true", 3,
                   new string[] { "String", "String","Decimal" });
            groupBox2.Enabled = false;
            for (int i = 1; i < Lohngruppen.Count; i+=3)
                {
                    comboBox2.Items.Add(Lohngruppen[i]);
                }
                for (int i = 1; i < Arbeitsstunden.Count; i += 2)
                {
                comboBox3.Items.Add(Arbeitsstunden[i]);
               
                }
                for (int i = 1; i < Bonuszahlung.Count; i += 2)
                {
                    comboBox1.Items.Add(Bonuszahlung[i]);
                }
                for (int i = 1; i < Überstunden.Count; i += 3)
                {
                    comboBox4.Items.Add(Überstunden[i]);
                }
                for (int i = 0; i < MitarbeiterAusHauptfenster.Count; i++)
                {
                    MitarbeiterAuswählen.Items.Add(MitarbeiterAusHauptfenster[i]);
                }
                for(int i = 0; i < 24; i++)
            {
                comboBox5.Items.Add(i);
            }
            }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!AusgewählteÜberstunden.Contains(Überstunden[(comboBox4.SelectedIndex * 3)])){
                try
                {
                    ÜberstundenAnzahl.Add(comboBox5.SelectedItem.ToString());
                    Überstundensätze.Add(Convert.ToInt32(Überstunden[comboBox4.SelectedIndex * 3 + 2]) +
                                         Convert.ToInt32(Lohngruppen[comboBox2.SelectedIndex * 3 + 2]));
                    AusgewählteÜberstunden.Add(Überstunden[(comboBox4.SelectedIndex * 3)].ToString());
                    listBox1.Items.Add(comboBox5.SelectedItem.ToString() + " Stunden " + Überstunden[(comboBox4.SelectedIndex * 3) + 1]);
                    comboBox4.SelectedItem = null;
                    textBox1.Text = "";
                    comboBox5.SelectedItem = null;
                }
                catch (Exception) { }
            }
            else
            {
                MessageBox.Show("Die Überstundenart ist bereits enthalten");
            }

        }

        private void button6_Click(object sender, EventArgs e)
            {
            AusgewählteÜberstunden.Clear();
            ÜberstundenAnzahl.Clear();
           listBox1.Items.Clear();
            }

        private void button1_Click(object sender, EventArgs e)
            {
            if (WindowState == FormWindowState.Normal)
            {
                Region = null;
                button1.Text = "▣";
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, 603, 657, 20, 20));
                button1.Text = "▇";
                WindowState = FormWindowState.Normal;
            }
        }

            private void MitarbeiterAuswählen_SelectedIndexChanged(object sender, EventArgs e)
            {
            try
            {
                textBox2.Text = Abrechnungsnummern[MitarbeiterAuswählen.SelectedIndex].ToString();
                OleDbDataReader abteilungsnummer = sql.readFromTable(
                     String.Format("Select Abteilungsnummer from Mitarbeiter where MA_Abrechnungsnummer = {0}",
                         textBox2.Text));
                abteilungsnummer.Read();
                int abteilungsnum = abteilungsnummer.GetInt32(0);
                textBox4.Text = abteilungsnum.ToString();
                OleDbDataReader abteilungsname = sql.readFromTable(
                    String.Format("Select Abteilungsname from Abteilung where Abteilungnummer = {0}",
                        abteilungsnum));
                abteilungsname.Read();
                textBox3.Text = abteilungsname.GetString(0);
            }
            catch (Exception) { }
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            comboBox4.SelectedItem = null;
            groupBox2.Enabled = true;
            comboBox4.Enabled = true;
            comboBox5.SelectedItem = null;
        }

            private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (comboBox4.SelectedItem != null)
                {
                    
                    textBox1.Text =
                        Convert.ToString(Convert.ToInt32(Überstunden[comboBox4.SelectedIndex * 3 + 2]) +
                                         Convert.ToInt32(Lohngruppen[comboBox2.SelectedIndex * 3 + 2])) + " €";
                }
                else
                {
                    textBox1.Text = "";
                comboBox5.SelectedItem = null;
                }
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
        
    }
