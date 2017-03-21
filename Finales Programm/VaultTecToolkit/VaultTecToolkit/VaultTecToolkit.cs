using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace VaultTecToolkit
{
    public class VaultTecToolkit
    {
        
    }
    public class SQL
    {
        private readonly OleDbConnection con =
          new OleDbConnection("Provider= Microsoft.ACE.OLEDB.12.0; Data Source = Datenbankentwurf.accdb");
        public void CloseCon()
        {
            con.Close();
        }
        public DataTable loadData(String command, DataTable dt)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand cmd = new OleDbCommand(command, con);
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            return dt;

        }
        public void OpenCon()
        {
            con.Open();
        }

        public void execeutenonquery(string select)
        {
            OleDbCommand executeCommand = new OleDbCommand(select,con);
            executeCommand.ExecuteNonQuery();
        }

        public List<Object> dataReader(String select, int numberAttributes, string[] datatypes)
        {
            List<Object> dataList = new List<Object>();
            OleDbDataReader dataReader = readFromTable(select);
            while (dataReader.Read())
            {
                for (int i = 0; i < numberAttributes; i++)
                {
                    switch (datatypes[i])
                    {
                        case "Int32":
                            dataList.Add(dataReader.GetInt32(i));
                            break;
                        case "Decimal":
                            dataList.Add(dataReader.GetDecimal(i));
                            break;
                        case "String":
                            dataList.Add(dataReader.GetString(i));
                            break;
                    }
                }
            }
            return dataList;  
        }
        public OleDbDataReader readFromTable(string sqlcommand)
        {
            return new OleDbCommand(sqlcommand, con).ExecuteReader();
        }
    }
   
    public class myRenderer : ToolStripProfessionalRenderer
    {
        public myRenderer(ProfessionalColorTable pct)
            : base(pct)
        {
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs myMenu)
        {
            if (!myMenu.Item.Selected)
            {
                base.OnRenderMenuItemBackground(myMenu);
            }
            else
            {
                var menuRectangle = new Rectangle(Point.Empty, myMenu.Item.Size);
                myMenu.Graphics.FillRectangle(Brushes.Transparent, menuRectangle);
                myMenu.Graphics.DrawRectangle(Pens.Transparent, 1, 0, menuRectangle.Width - 2, menuRectangle.Height - 1);
            }
        }
    }

    public class CustomColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.DarkSlateGray; }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return Color.DarkSlateGray; }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return Color.DarkSlateGray; }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return Color.DarkSlateGray; }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return Color.DarkSlateGray; }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.DarkSlateGray; }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.DarkSlateGray; }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.DarkSlateGray; }
        }

        public override Color MenuItemPressedGradientMiddle
        {
            get { return Color.DarkSlateGray; }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.DarkSlateGray; }
        }

        public override Color MenuItemBorder
        {
            get { return Color.DarkSlateGray; }
        }
    }
}
