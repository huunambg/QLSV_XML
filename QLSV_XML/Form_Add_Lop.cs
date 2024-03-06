using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace QLSV_XML
{
    public partial class Form_Add_Lop : Form
    {
        String id_TK;

        string fileName = @"D:\Soure_Code\Window\QLSV_XML\QLSV_XML\Lop.xml";
        XmlDocument doc = new XmlDocument();
        XmlElement ql_lop;
        public Form_Add_Lop(string id_TK)
        {
            InitializeComponent();
            this.id_TK = id_TK; 
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form_Add_Lop_Load(object sender, EventArgs e)
        {

        }

        private void btn_themlop_Click(object sender, EventArgs e)
        {

            doc.Load(fileName);

            ql_lop = doc.DocumentElement;

            XmlNode Lop = doc.CreateElement("Lop");

            XmlNodeList ds_tk = ql_lop.SelectNodes("Lop");

            int id= ds_tk.Count+1;

            XmlAttribute id_lop = doc.CreateAttribute("Id_Lop");

            id_lop.Value = id.ToString();

            Lop.Attributes.Append(id_lop);

            XmlElement tenlop = doc.CreateElement("TenLop");
            tenlop.InnerText = txt_tenlop.Text;

            Lop.AppendChild(tenlop);

            XmlElement siso = doc.CreateElement("SiSo");
            siso.InnerText = txt_siso.Text; 
            Lop.AppendChild (siso);

            XmlElement id_tk = doc.CreateElement ("Id_TaiKhoan");

            id_tk.InnerText = this.id_TK;

            Lop.AppendChild(id_tk);


            ql_lop.AppendChild(Lop);

            doc.Save(fileName);

            this.Hide();

            Form1 form1 = new Form1(this.id_TK);
            form1.ShowDialog();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
