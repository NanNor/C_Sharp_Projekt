using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaultTecToolkit;

namespace Lohnabrechnungssystem
    {
    public partial class LohnabrechnungenAnzeigen : Form 
    {
        List<object> LohnAbrechnung = new List<object>();
        List<object> Lohngruppe = new List<object>();
        List<object> Arbeitsstunden = new List<object>();
        List<object> Überstunden = new List<object>();
        List<object> AlleÜberstunden = new List<object>();
        DataTable dt = new DataTable();
        SQL sql = new SQL();
        public List<String> lr = new List<String>();
        public List<int> lr2 = new List<int>();
        DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
        public LohnabrechnungenAnzeigen(List<String> namesList , List<int> abrnrList) : this()
        {
            lr = namesList;
            lr2 = abrnrList;
        }
        public LohnabrechnungenAnzeigen()
            {
            InitializeComponent();
            sql.OpenCon();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, 638, 600, 20, 20));
            var cst = new CustomColorTable();
            menuStrip1.Renderer = new myRenderer(cst);
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
        private void LohnabrechnungenAnzeigen_Load(object sender, EventArgs e)
        {
            
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, 728, 555, 20, 20));
            var cst = new CustomColorTable();
            menuStrip1.Renderer = new myRenderer(cst);

            foreach (string t in lr)
            {
                MitarbeiterAuswählen.Items.Add(t);
            }
           
            button2.FlatAppearance.BorderColor = Color.DarkSlateGray;
            button10.FlatAppearance.BorderColor = Color.DarkSlateGray;
            combo.HeaderText = "Überstundenkennung";
            combo.FlatStyle = FlatStyle.Flat;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns.Add(combo);
            dataGridView1.Columns.Add("Überstundensatz", "Überstundensatz");
            dataGridView1.Columns.Add("Überstundenanzahl", "Überstundenanzahl");
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 120;
         }



        private void button10_Click_1(object sender, EventArgs e)
            {
            Close();
            sql.CloseCon();
            }

       

        private void button2_Click(object sender, EventArgs e)
            {
            WindowState = FormWindowState.Minimized;
            }
        
        public void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                TextBox[] textObjects = { textBox6, textBox7, textBox8, textBox5, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14 };
                for (int i = 0; i < textObjects.Length; i++)
                {
                    textObjects[i].Text = "";
                }
                DataGridView1_Clear();
                listBox1.Items.Clear();
                OleDbDataReader Mitarbeiterinformationen =
                    sql.readFromTable(String.Format("Select * from Mitarbeiter where MA_Abrechnungsnummer = {0}",
                        lr2[MitarbeiterAuswählen.SelectedIndex]));
                Mitarbeiterinformationen.Read();
                textBox2.Text = Mitarbeiterinformationen.GetInt32(0).ToString();
                textBox4.Text = Mitarbeiterinformationen.GetInt32(3).ToString();
                OleDbDataReader Abteilung =
                    sql.readFromTable(String.Format("Select Abteilungsname from Abteilung where Abteilungnummer = {0}",
                        textBox4.Text));
                Abteilung.Read();
                textBox3.Text = Abteilung.GetString(0);
                OleDbDataReader Abrechnung =
                    sql.readFromTable(String.Format("Select Abrechnungsdatum from Abrechnung where Abrechnungsnummer = {0}",
                        lr2[MitarbeiterAuswählen.SelectedIndex]));


                try
                {
                    while (Abrechnung.Read())
                    {
                        listBox1.Items.Add((Abrechnung.GetString(0)));
                    }
                }
                catch (InvalidOperationException)
                {

                }
            }
            catch (Exception)
            {

            }
            }

        private void dataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
            {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            row.DefaultCellStyle.BackColor = Color.DarkSlateGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Silver;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.Silver;
            }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
            {

            }

        public void DataGridView1_Clear()
        {
            dataGridView1.Rows[0].Cells[0].Selected = false;
            dataGridView1.Rows[0].Cells[0].Value = " ";
            dataGridView1.Rows[0].Cells[1].Value = " ";
            dataGridView1.Rows[0].Cells[2].Value = " ";
            combo.Items.Clear();
            dt.Clear();
            }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        { try {
                TextBox[] textObjects = { textBox6, textBox7, textBox8, textBox5 };
                LohnAbrechnung = sql.dataReader(
                   String.Format("Select * from Abrechnung where Abrechnungsnummer = {0}  and Abrechnungsdatum = '{1}'",
                       lr2[MitarbeiterAuswählen.SelectedIndex], listBox1.SelectedItem), 5, new string[] { "Int32", "String", "Int32", "Int32", "Int32" });
                Lohngruppe = sql.dataReader(String.Format("Select * from Lohngruppe where Lohngruppenummer = {0}",
                    LohnAbrechnung[3]), 3, new string[] { "Int32", "String", "Decimal" });
                Arbeitsstunden = sql.dataReader(String.Format("Select Arbeitsstunden from Arbeitsstunden where ArbeitsstundenNR = {0}",
                            LohnAbrechnung[4]), 1, new string[] { "Int32", "Int32" });
                String[] dataBaseStrings = Lohngruppe.Concat(Arbeitsstunden).ToList().Select(i => i.ToString()).ToArray();
                for (int i = 0; i < textObjects.Length; i++)
                {
                    textObjects[i].Text = dataBaseStrings[i];
                }

                AlleÜberstunden = sql.dataReader(
                    String.Format("Select Überstundensatz, Überstundenanzahl from Überstunden where Abrechnungsnummer = {0} and Abrechnungsdatum = '{1}' ",
                                    lr2[MitarbeiterAuswählen.SelectedIndex], listBox1.SelectedItem), 2, new string[] { "Decimal", "Int32" });
                DataGridView1_Clear();
                dt = sql.loadData(String.Format("SELECT * From Überstunden WHERE Abrechnungsnummer = {0} and Abrechnungsdatum = '{1}'", lr2[MitarbeiterAuswählen.SelectedIndex], listBox1.SelectedItem), dt);
                ArrayList row = new ArrayList();
                foreach (DataRow dr in dt.Rows)
                {
                    row.Add(dr["Überstundenkennung"].ToString());
                }
                combo.Items.AddRange(row.ToArray());


                // Rechenfelder zuweisen

                textBox9.Text = Convert.ToString(Convert.ToInt32(textBox5.Text) * Convert.ToDouble(textBox8.Text.Replace("€", "")));
                Double summeÜberstunden = 0;
                for (int i = 0; i < AlleÜberstunden.Count; i += 2)
                {
                    summeÜberstunden += Convert.ToDouble(AlleÜberstunden[i]) * Convert.ToDouble(AlleÜberstunden[i + 1]);
                }
                textBox10.Text = summeÜberstunden.ToString();
                textBox11.Text = Convert.ToString(summeÜberstunden + Convert.ToDouble(textBox9.Text));
                List<Object> Bonuszahlung = sql.dataReader(
                String.Format("Select Prozentsatz from Bonuszahlung where BonuszahlungID = {0} ",
                    LohnAbrechnung[2]), 1, new string[] { "Int32" });
                textBox14.Text = String.Format("Zuschlag von {0}%", Bonuszahlung[0]);
                textBox12.Text = Convert.ToString(Convert.ToDouble(textBox11.Text) * Convert.ToDouble(Bonuszahlung[0]) / 100);
                textBox13.Text = Convert.ToString(Convert.ToDouble(textBox12.Text) + Convert.ToDouble(textBox11.Text));
            }
            catch(Exception fck) { }
            
            }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex == 0 && dataGridView1.Rows[0].Cells[0].Value != " ")
                {
                Überstunden = sql.dataReader(
                String.Format(
                                "Select Überstundensatz, Überstundenanzahl from Überstunden where Abrechnungsnummer = {0} and Abrechnungsdatum = '{1}' and Überstundenkennung = '{2}'",
                                lr2[MitarbeiterAuswählen.SelectedIndex], listBox1.SelectedItem,
                                dataGridView1.Rows[0].Cells[0].Value), 2, new string[] { "Decimal", "Int32" });
                    dataGridView1.Rows[0].Cells[1].Value = Überstunden[0] + "€";
                    dataGridView1.Rows[0].Cells[2].Value = Überstunden[1];
                }
            }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
            {
            var grid = sender as DataGridView;
            grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dataGridView1.AllowUserToAddRows = false;
            }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
            {

            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

        private void button3_Click(object sender, EventArgs e)
            {
            this.Close();
            sql.CloseCon();
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

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
            {
            Close();
            }

        private void technischerSupportToolStripMenuItem_Click(object sender, EventArgs e)
            {
            Meldung VaultTecService = new Meldung();
            VaultTecService.Informationstring = "Sie können Vault-Tec-Service \nunter 1-888-4-82858-832 erreichen";
            VaultTecService.ShowDialog();
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
    }
    }
