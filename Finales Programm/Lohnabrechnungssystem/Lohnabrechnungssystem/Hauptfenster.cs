using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VaultTecToolkit;

namespace Lohnabrechnungssystem
{
    public partial class Hauptfenster : Form
    {
    
        private readonly List<int> abrechnungsnummernAnzeigeList = new List<int>();
        private readonly List<int> collectionnumbers = new List<int>();
        private readonly AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
        private readonly List<int> MA_Abrechnungsnummer = new List<int>();
       
        private readonly SQL sql = new SQL();
        private OleDbDataReader dataReader;
        public int FormScaleFactor = 1;

        public Hauptfenster()
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

        private void Hauptfenster_Load(object sender, EventArgs e)
        {
            collectionnumbers.Clear();
            collection.Clear();
            abrechnungsnummernAnzeigeList.Clear();
            MA_Abrechnungsnummer.Clear();
            StartPosition = FormStartPosition.CenterScreen;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, 456, 473, 20, 20));
            var cst = new CustomColorTable();
            menuStrip1.Renderer = new myRenderer(cst);
            SearchText.AutoCompleteMode = AutoCompleteMode.Suggest;
            SearchText.AutoCompleteSource = AutoCompleteSource.CustomSource;
            toolTip1.SetToolTip(button4,
                "Diese Funktion dient zur schnelleren Bearbeitung oder Anzeige von Mitarbeitern");
            toolTip1.SetToolTip(SearchText,
                "Anmerkung: Autovervollständigung vorhanden");
            toolTip1.SetToolTip(listBox1,
               "Hier werden Ihre ausgewählten Mitarbeiter zwischengespeichert. Sie können ein oder mehr Mitarbeiter auswählen.");
            
            button2.FlatAppearance.BorderColor = Color.DarkSlateGray;
            button10.FlatAppearance.BorderColor = Color.DarkSlateGray;
            sql.OpenCon();
            dataReader =
                sql.readFromTable(
                    "Select MA_Abrechnungsnummer, Mitarbeitervorname, Mitarbeiternachname from Mitarbeiter where Aktiv = true order by Mitarbeitervorname");
            var counter = 0;
            while (dataReader.Read())
            {
                MA_Abrechnungsnummer.Add(dataReader.GetInt32(0));
                collection.Add(string.Format("{0}  {1}  ", dataReader.GetString(1), dataReader.GetString(2)));
                collectionnumbers.Add(dataReader.GetInt32(0));
                treeView1.Nodes.Add(dataReader.GetString(1) + " " + dataReader.GetString(2));
                treeView1.Nodes[counter].Nodes.Add("Abrechnungsnummer: " + MA_Abrechnungsnummer[counter]);
                counter++;
            }
            SearchText.AutoCompleteCustomSource = collection;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            var names = new List<string>();
            if (tabControl1.SelectedTab.Name == "Suchfunktion")
                foreach (string namesOfListBox in listBox1.Items)
                    names.Add(namesOfListBox);
            else if (tabControl1.SelectedTab.Name == "Auflistung")
            {
                try
                {
                    abrechnungsnummernAnzeigeList.Clear();
                    var node = treeView1.Nodes[treeView1.SelectedNode.Index].Nodes[0].Text;
                    node = node.Replace("Abrechnungsnummer:", "");
                    abrechnungsnummernAnzeigeList.Add(Convert.ToInt32(node));
                    names.Add(treeView1.SelectedNode.Text);
                }
                catch (NullReferenceException nullReferenceException)
                { }
                   
            }
            if (names.Count > 0)
            {
                var lr = new LohnabrechnungenAnzeigen(names, abrechnungsnummernAnzeigeList);
                lr.ShowDialog();
            }
            else
            {
                Meldung Meldung = new Meldung();
                Meldung.Informationstring = "Sie haben kein Mitarbeiter ausgewählt";
                Meldung.ShowDialog();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "Auflistung")
            {
                try
                {
                    LohnabrechnungErstellen lr = new LohnabrechnungErstellen();
                    var node = treeView1.Nodes[treeView1.SelectedNode.Index].Nodes[0].Text;
                    node = node.Replace("Abrechnungsnummer:", "");
                    lr.Abrechnungsnummern.Add(Convert.ToInt32(node));
                    lr.MitarbeiterAusHauptfenster.Add(treeView1.SelectedNode.Text);
                    lr.ShowDialog();
                }
                catch(NullReferenceException )
                {
                    Meldung mld = new Meldung();
                    mld.Informationstring = "Sie haben kein Mitarbeiter ausgewählt";
                    mld.ShowDialog();
                }
            }
            else if (tabControl1.SelectedTab.Name == "Suchfunktion")
            {
                if (listBox1.Items.Count > 0 && listBox1.Items[0] != "Es wurde kein Mitarbeiter ausgewählt")
                {
                    LohnabrechnungErstellen lrErstellen = new LohnabrechnungErstellen();
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        lrErstellen.Abrechnungsnummern.Add(abrechnungsnummernAnzeigeList[i]);
                        lrErstellen.MitarbeiterAusHauptfenster.Add(listBox1.Items[i].ToString());
                    }
                    lrErstellen.ShowDialog();
                }
                else
                {
                    Meldung Meldung = new Meldung();
                    Meldung.Informationstring = "Sie haben kein Mitarbeiter ausgewählt";
                    Meldung.ShowDialog();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (SearchText.Text.Length > 0 && collection.Contains(SearchText.Text))
            {
                var addstring = SearchText.Text;
                if (listBox1.Items.Count >= 10)
                {
                    MessageBox.Show("Sie können nicht mehr als 10 Mitarbeiter auswählen");
                }
                else
                {
                    if (!listBox1.Items.Contains(addstring))
                    {
                        abrechnungsnummernAnzeigeList.Add(collectionnumbers[collection.IndexOf(addstring)]);
                       listBox1.Items.Add(addstring);
                    }
                }
            }
            else
            {
                Meldung mld = new Meldung();
                mld.Informationstring = "Mitarbeiter konnte nicht hinzugefügt \nwerden";
                mld.Show();
                SearchText.SelectAll();
            }
        }

        private void SearchText_TextChanged(object sender, EventArgs e)
        {
        }

        private void SearchText_MouseClick(object sender, MouseEventArgs e)
        {
            SearchText.SelectAll();
        }

        private void Hauptfenster_Shown(object sender, EventArgs e)
        {
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new MitarbeiterAnzeigen().ShowDialog();
            sql.CloseCon();
            Controls.Clear();
            InitializeComponent();
            Hauptfenster_Load(e, e);
        }

        private void Suchfunktion_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new AdministrativerBereich().ShowDialog();
        }

        private void technischerSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Meldung VaultTecService = new Meldung();
            VaultTecService.Informationstring = "Sie können Vault-Tec-Service \nunter 1-888-4-82858-832 erreichen";
            VaultTecService.ShowDialog();
        }

        private void vaultBoyVersteckenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vaultBoyVersteckenToolStripMenuItem.Text.Contains("verstecken"))
            {
                pictureBox1.Visible = false;
                button3.Image = null;
                button5.Image = null;
                button6.Image = null;
                button9.Image = null;
                vaultBoyVersteckenToolStripMenuItem.Text = vaultBoyVersteckenToolStripMenuItem.Text.Replace(
                    "verstecken", "anzeigen");
            }
            else if (vaultBoyVersteckenToolStripMenuItem.Text.Contains("anzeigen"))
            {
                sql.CloseCon();
                Controls.Clear();
                InitializeComponent();
                Hauptfenster_Load(e, e);
                // Ist auch möglich -> Application.Restart();
                vaultBoyVersteckenToolStripMenuItem.Text = vaultBoyVersteckenToolStripMenuItem.Text.Replace("anzeigen",
                    "verstecken");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Location.X.ToString() + ", " + this.Location.Y.ToString());
        }
        Point _controllerMousePosition;
        Point _globalMousePosition;

        private void menuStrip3_MouseMove(object sender, MouseEventArgs e)
            {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
                {
                Point newGlobalMousePosition = Control.MousePosition;
                _globalMousePosition.X += (newGlobalMousePosition.X - _globalMousePosition.X) - _controllerMousePosition.X;
                _globalMousePosition.Y += (newGlobalMousePosition.Y - _globalMousePosition.Y) - _controllerMousePosition.Y;
                this.Location = _globalMousePosition;
                }
            }

        private void menuStrip3_MouseDown(object sender, MouseEventArgs e)
            {
            base.OnMouseDown(e);
            _globalMousePosition = Control.MousePosition;
            _controllerMousePosition = e.Location;
            }

        private void button7_Click_1(object sender, EventArgs e)
            {
            listBox1.Items.Clear();
            }

        private void mediaPlayerToolStripMenuItem_Click(object sender, EventArgs e)
            {
             new MP3_Player.Form1().Show();
            }

        private void Info_Click(object sender, EventArgs e)
        {
            new Informationsfenster().ShowDialog();
        }

        private void menuStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
            {

            }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
            {
            Application.Exit();
            }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
            {
                Point newGlobalMousePosition = Control.MousePosition;
                _globalMousePosition.X += (newGlobalMousePosition.X - _globalMousePosition.X) - _controllerMousePosition.X;
                _globalMousePosition.Y += (newGlobalMousePosition.Y - _globalMousePosition.Y) - _controllerMousePosition.Y;
                this.Location = _globalMousePosition;
            }
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _globalMousePosition = Control.MousePosition;
            _controllerMousePosition = e.Location;
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SearchText.Text = "";
            listBox1.Items.Clear();
            abrechnungsnummernAnzeigeList.Clear();

        }

        private void alleAbrechnungenAnzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AlleLohnabrechnungen().ShowDialog();
        }
    }
}