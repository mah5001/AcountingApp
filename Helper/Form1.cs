using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Helper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string datasoure = "";
            string ic = "";
            string ise =  "";
            string username = "";
            string pass = "";
            string connectionString = @"Data Source="+ ";Initial Catalog=" + ";Integrated Security=" + "User Id="+ "Password="+";MultipleActiveResultSets=True;";
            string file = Application.StartupPath + "AcountingAPP.exe.config";
            XmlDocument xml = new XmlDocument();
            xml.Load(file);
            XmlNoede n = xml.SelectSingleNode("/configuration/connectionStrings/add");
            XmlAttribute attr = n.Attributes["connectionString"].Value = connectionString;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
