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
    public partial class Form_QLSV : Form
    {
        string id_lop;
        string id_tk;
        string fileName = @"D:\Soure_Code\Window\QLSV_XML\QLSV_XML\SinhVien.xml";
        XmlDocument doc = new XmlDocument();
        XmlElement ql_sv;
        public Form_QLSV(string id_lop, string id_tk)
        {
            InitializeComponent();
            this.id_lop = id_lop;
            this.id_tk = id_tk;
        }

        private void Form_QLSV_Load(object sender, EventArgs e)
        {


            show(dgv_QL_sv);




        }


        void show(DataGridView dgv)
        {
            doc.Load(fileName);
            ql_sv = doc.DocumentElement;


            XmlNodeList ds_sv = ql_sv.SelectNodes("SinhVien");

            int sd = 0;

            foreach (XmlNode node in ds_sv)
            {

                if (node.SelectSingleNode("Id_Lop").InnerText == this.id_lop)
                {
                    dgv.Rows.Add();
                    dgv.Rows[sd].Cells[0].Value = node.SelectSingleNode("HoTen").InnerText;
                    dgv.Rows[sd].Cells[1].Value = node.SelectSingleNode("NgaySinh").InnerText;
                    dgv.Rows[sd].Cells[2].Value = node.SelectSingleNode("GioiTinh").InnerText;
                    dgv.Rows[sd].Cells[2].Value = node.SelectSingleNode("DiaChi").InnerText;
                    dgv.Rows[sd].Cells[2].Value = node.SelectSingleNode("SDT").InnerText;
                    dgv.Rows[sd].Cells[2].Value = node.SelectSingleNode("GPA").InnerText;
                    sd++;

                }
            }



            }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1(this.id_tk);
            form1.ShowDialog();
        }
    }
}
