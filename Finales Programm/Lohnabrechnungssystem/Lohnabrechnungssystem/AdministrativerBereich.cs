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
    public partial class AdministrativerBereich : Form
    {
      
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dt5 = new DataTable();
        int PW;
        bool Hided;
        DataTable AbteilungenDT = new DataTable();
        DataTable ArbeitsstundenDT = new DataTable();
        DataTable BonuszahlungDT = new DataTable(); 
        DataTable LohngruppenDT = new DataTable();
        DataTable ÜberstundenDT = new DataTable();
        private SQL sql = null;
        public AdministrativerBereich()
        {
            InitializeComponent();
            
            
            }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
         (
             int nLeftRect, 
             int nTopRect, 
             int nRightRect, 
             int nBottomRect,
             int nWidthEllipse, 
             int nHeightEllipse 
         );

        
        private void AdministrativerBereich_Load(object sender, EventArgs e)
        {
            
            System.Threading.Thread.Sleep(10);
            Meldung mld = new Meldung();
            mld.Show();
            mld.Close();
            PW = panel1.Height;
            panel1.Height = 0;
            Hided = true;
            sql = new SQL();
            sql.OpenCon();
            dt1.Clear();
            dt2.Clear();
            dt3.Clear();
            dt4.Clear();
            dt5.Clear();
            button2.FlatAppearance.BorderColor = Color.DarkSlateGray;
        
            button10.FlatAppearance.BorderColor = Color.DarkSlateGray;
            pictureBox2.Visible = false;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, 591, 510, 20, 20));
            var cst = new CustomColorTable();
            menuStrip1.Renderer = new myRenderer(cst);
            tabControl1.Appearance = TabAppearance.Buttons;
            tabControl1.SizeMode = TabSizeMode.Fixed;
            dt1 = sql.loadData("Select * from Abteilung", AbteilungenDT);
            dt2 = sql.loadData("Select * from Arbeitsstunden", ArbeitsstundenDT);
            dt3 = sql.loadData("Select * from Bonuszahlung", BonuszahlungDT);
            dt4 = sql.loadData("Select * from Lohngruppe", LohngruppenDT);
            dt5 = sql.loadData("Select * from Überstundenkennung", ÜberstundenDT);
            dataGridView1.DataSource = dt1;
            dataGridView2.DataSource = dt2;
            dataGridView3.DataSource = dt3;
            dataGridView4.DataSource = dt4;
            dataGridView5.DataSource = dt5;
            dataGridView2.Columns[0].ReadOnly = true;
            dataGridView2.Columns[1].ReadOnly = true;
            dataGridView3.Columns[0].ReadOnly = true;
            dataGridView3.Columns[1].ReadOnly = true;
            dataGridView4.Columns[0].ReadOnly = true;
            dataGridView4.Columns[1].ReadOnly = true;
            dataGridView4.Columns[2].ReadOnly = true;
            dataGridView5.Columns[0].ReadOnly = true;
            dataGridView5.Columns[1].ReadOnly = true;
            dataGridView1.Columns[1].Width = 360;
            dataGridView5.Columns[1].Width = 142;
            dataGridView5.Columns[0].Width = 140;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
            {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Blue, 4);
            g.DrawRectangle(p, this.tabPage1.Bounds);
            }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
            {
            }

        private void dataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
            {
           }

        private void dataGridView3_CurrentCellDirtyStateChanged(object sender, EventArgs e)
            {
           }

        private void dataGridView4_CurrentCellDirtyStateChanged(object sender, EventArgs e)
            {
            }

        private void dataGridView5_CurrentCellDirtyStateChanged(object sender, EventArgs e)
            {
            }

        private void technischerSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Meldung VaultTecService = new Meldung();
            VaultTecService.Informationstring = "Sie können Vault-Tec-Service \nunter 1-888-4-82858-832 erreichen";
            VaultTecService.ShowDialog();
            }

        private void button3_Click(object sender, EventArgs e)
            {
            sql.CloseCon();
            Close();
            }

        private void weitereAdministrativeMöglichkeitenToolStripMenuItem_Click(object sender, EventArgs e)
            {
            if (Hided)
                weitereAdministrativeMöglichkeitenToolStripMenuItem.Text.Replace("Anzeigen", "Verstecken");
            else weitereAdministrativeMöglichkeitenToolStripMenuItem.Text.Replace("Verstecken", "Anzeigen");
            timer1.Start();
         
            }

        private void timer1_Tick(object sender, EventArgs e)
            {
            if (Hided)
                {
                panel1.Height = panel1.Height + 6;
                if (panel1.Height >= PW)
                    {
                    timer1.Stop();
                    Hided = false;
                    this.Refresh();
                    }
                }
            else
                {

                panel1.Height = panel1.Height - 6;
                if (panel1.Height <= 0)
                    {
                    timer1.Stop();
                    Hided = true;
                    this.Refresh();
                    }
                }
            }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
            {

            }

        private void lohnabrechnungssystemZurücksetzenToolStripMenuItem_Click(object sender, EventArgs e)
            {
            pictureBox2.Size = new Size(590, 497);
            pictureBox2.Visible = true;
            Meldung mld1 = new Meldung();
            mld1.Informationstring = "Die Datenbank wird zurückgesetzt!";
            mld1.ShowDialog();
            DialogResult result = MessageBox.Show(
                "Alle Ihre Einträge werden gelöscht \n\nFortfahren?", "WARNUNG", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    String[] Tabellennamen =
                    {
                        "Abrechnung", "Lohngruppe", "Arbeitsstunden", "Bonuszahlung", "Überstunden",
                        "Überstundenkennung", "Mitarbeiter", "Abteilung"
                    };
                    for (int i = 0; i < Tabellennamen.Length; i++)
                    {
                        sql.execeutenonquery(String.Format("Delete FROM {0}", Tabellennamen[i]));
                    }
                    Controls.Clear();
                    InitializeComponent();
                    AdministrativerBereich_Load(e, e);
                    pictureBox2.Size = new Size(590, 497);
                   
                    Meldung mld = new Meldung();
                    mld.Informationstring = "Die Datenbank wurde zurückgesetzt!";
                    mld.ShowDialog();
                }
                else
                {
                    pictureBox2.Visible = false;
                }
            Close();
            }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminHinzufügen AH = new AdminHinzufügen();
            AH.headline = Abteilungen.Text;
            AH.s1 = dataGridView1.Columns[0].HeaderText;
            AH.s2 = dataGridView1.Columns[1].HeaderText;
            AH.visible3 = false;
        
            AH.ShowDialog();
            
            Controls.Clear();
            InitializeComponent();
            AdministrativerBereich_Load(e, e);
            }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminHinzufügen AH = new AdminHinzufügen();
            AH.headline = tabPage2.Text;
            AH.s1 = dataGridView2.Columns[0].HeaderText;
            AH.s2 = dataGridView2.Columns[1].HeaderText;
            AH.visible3 = false;
           
            AH.ShowDialog();
           
            Controls.Clear();
            InitializeComponent();
            AdministrativerBereich_Load(e, e);
            }

        private void button6_Click(object sender, EventArgs e)
            {
            AdminHinzufügen AH = new AdminHinzufügen();
            AH.headline = Bonuszahlung.Text;
            AH.s1 = dataGridView3.Columns[0].HeaderText;
            AH.s2 = dataGridView3.Columns[1].HeaderText;
            AH.visible3 = false;
            
            AH.ShowDialog();
           
            Controls.Clear();
            InitializeComponent();
            AdministrativerBereich_Load(e, e);
            }

        private void button7_Click(object sender, EventArgs e)
            {
            AdminHinzufügen AH = new AdminHinzufügen();
            AH.headline = tabPage1.Text;
            AH.s1 = dataGridView4.Columns[0].HeaderText;
            AH.s2 = dataGridView4.Columns[1].HeaderText;
                AH.s3 = dataGridView4.Columns[2].HeaderText;

            AH.ShowDialog();
           
            Controls.Clear();
            InitializeComponent();
            AdministrativerBereich_Load(e, e);
            }

        private void button8_Click(object sender, EventArgs e)
            {
            AdminHinzufügen AH = new AdminHinzufügen();
            AH.headline = tabPage3.Text;
            AH.s1 = dataGridView5.Columns[0].HeaderText;
            AH.s2 = dataGridView5.Columns[1].HeaderText;
                AH.s3 = dataGridView5.Columns[2].HeaderText;

            AH.ShowDialog();
           
            Controls.Clear();
            InitializeComponent();
            AdministrativerBereich_Load(e, e);
            }
        Point _controllerMousePosition;
        Point _globalMousePosition;

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

        private void menuStrip3_MouseDown(object sender, MouseEventArgs e)
            {
            base.OnMouseDown(e);

            //Absolute Position zum Bildschirmrand
            _globalMousePosition = Control.MousePosition;

            //Absolute Position zum Controllerrand
            _controllerMousePosition = e.Location;
            }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
            {
            Close();
            }

        private void button15_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);

            //Absolute Position zum Bildschirmrand
            _globalMousePosition = Control.MousePosition;

            //Absolute Position zum Controllerrand
            _controllerMousePosition = e.Location;
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button11_Click(object sender, EventArgs e)
        {try
            {
                for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                {
                    var sql2 = String.Format("update Arbeitsstunden set [Aktiv] = {0} where ArbeitsstundenNR = {1}", dataGridView2.Rows[i].Cells[2].Value, dataGridView2.Rows[i].Cells[0].Value);

                    sql.execeutenonquery(sql2);
                }
            }
            catch (Exception) { }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                {
                    var sql2 = String.Format("update Bonuszahlung set [Aktiv] = {0} where BonuszahlungID = {1}", dataGridView3.Rows[i].Cells[2].Value, dataGridView3.Rows[i].Cells[0].Value);
                    sql.execeutenonquery(sql2);
                }
            }
            catch (Exception) { }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView4.RowCount - 1; i++)
                {
                    var sql2 = String.Format("update Lohngruppe set [Aktiv] = {0} where Lohngruppenummer = {1}", dataGridView4.Rows[i].Cells[3].Value, dataGridView4.Rows[i].Cells[0].Value);
                    sql.execeutenonquery(sql2);
                }
            }
            catch (Exception) { }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView5.RowCount - 1; i++)
            {
                var sql2 = String.Format("update Überstundenkennung set [Aktiv] = {0} where Überstundenkennung = '{1}'", dataGridView5.Rows[i].Cells[3].Value, dataGridView5.Rows[i].Cells[0].Value);
                sql.execeutenonquery(sql2);
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
        }

