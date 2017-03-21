using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaultTecToolkit;
namespace Lohnabrechnungssystem
{
    public partial class AlleLohnabrechnungen : Form
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        SQL sql = new SQL();
        public AlleLohnabrechnungen()
        {
            InitializeComponent();
        }

        private void AlleLohnabrechnungen_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sql.loadData("Select * from Abrechnung", dt);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
