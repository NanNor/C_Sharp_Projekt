using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaultTecToolkit;

namespace Lohnabrechnungssystem
    {
    public partial class AdminHinzufügen : Form
    {
        private Boolean reload = false;
        public String table = "";
        public Boolean Hinzufügen = false;
        SQL sql = new SQL();
        public String headline = "";
        public String s1 = "";
        public String s2 = "";
        public String s3 = "";
        public Boolean visible1 = true;
        public Boolean visible2 = true;
        public Boolean visible3 = true;
    
        public AdminHinzufügen()
            {
            InitializeComponent();
            sql.OpenCon();
            }

        private void AdminHinzufügen_Load(object sender, EventArgs e)
        {
            textBox1.Visible = visible1;
            textBox2.Visible = visible2;
            textBox3.Visible = visible3;
           
            label1.Text = s1;
            label2.Text = s2;
            label3.Text = s3;
            label4.Text = headline;
          
            }

        private void button2_Click(object sender, EventArgs e)
        {
            try
           {
                switch (headline)
                {
                    case "Abteilung":

                        sql.execeutenonquery(
                            String.Format("insert into Abteilung(Abteilungnummer, Abteilungsname) values ({0},'{1}')",
                                textBox1.Text, textBox2.Text));
                        break;
                    case "Arbeitsstunden":
                        sql.execeutenonquery(String.Format("insert into Arbeitsstunden(ArbeitsstundenNR, Arbeitsstunden, Aktiv) values ({0},{1},true)", textBox1.Text, textBox2.Text));
                        break;
                    case "Bonuszahlung":
                        sql.execeutenonquery(String.Format("insert into Bonuszahlung(BonuszahlungID, Prozentsatz, Aktiv) values ({0},{1},true)", textBox1.Text, textBox2.Text));
                        break;
                    case "Lohngruppe":
                        sql.execeutenonquery(String.Format("insert into Lohngruppe(Lohngruppenummer, Lohngruppenname, Stundensatz, Aktiv) values ({0},'{1}',{2},true)", textBox1.Text, textBox2.Text, textBox3.Text));
                        break;
                    case "Überstunden":
                        sql.execeutenonquery(String.Format(
                            "insert into Überstundenkennung(Überstundenkennung, Überstundenbezeichnung, Überstundenbonus,Aktiv) values ('{0}','{1}',{2},true)", textBox1.Text, textBox2.Text, textBox3.Text));
                        break;
                }
                reload = true;
                Meldung mlMeldung = new Meldung();
                mlMeldung.Informationstring = "Attribut erfolgreich hinzugefügt!";
                mlMeldung.ShowDialog();
                Close();
            }
            catch(OleDbException)
            {
                Meldung mld = new Meldung();
                mld.Informationstring = "Fehler!\nAttribut konnte nicht hinzugefügt werden";
                mld.ShowDialog();
            }
            
           
            }

        private void button1_Click(object sender, EventArgs e)
            {
            Close();
            }
        }
    }
