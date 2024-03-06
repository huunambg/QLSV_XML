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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace QLSV_XML
{
    public partial class Form1 : Form
    {

        String id_TK;
        string id_lop;
        string fileName = @"D:\zKiemlongJr\XML\QLSV\QLSV_XML\Lop.xml";
        XmlDocument doc = new XmlDocument();
        XmlElement ql_Lop;
        public Form1(String id_TK)
        {
            this.id_TK = id_TK;
            InitializeComponent();
        }



        void show(DataGridView dgv)
        {

            doc.Load(fileName);
            ql_Lop = doc.DocumentElement;
            XmlNodeList ds_lop = ql_Lop.SelectNodes("Lop");
            int sd = 0;
            foreach (XmlNode node in ds_lop)
            {


                if (node.SelectSingleNode("Id_TaiKhoan").InnerText == this.id_TK){
                    dgv.Rows.Add();
                    dgv.Rows[sd].Cells[0].Value = node.SelectSingleNode("@Id_Lop").Value;
                    dgv.Rows[sd].Cells[1].Value = node.SelectSingleNode("TenLop").InnerText;
                    dgv.Rows[sd].Cells[2].Value = node.SelectSingleNode("SiSo").InnerText;
                    sd++;
                }
                
    

            }


        }


        private void btn_them_lop_Click(object sender, EventArgs e)
        {
            this.Hide();
           Form_Add_Lop form_Add_Lop = new Form_Add_Lop(this.id_TK);
            form_Add_Lop.ShowDialog();


        }

        private void dgv_QL_Lop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            show(dgv_QL_Lop);
        }

        private void dgv_QL_Lop_Click(object sender, EventArgs e)
        {
            int index = dgv_QL_Lop.CurrentCell.RowIndex;


            if (dgv_QL_Lop.Rows[index].Cells[0].Value != null)
            {
                id_lop = dgv_QL_Lop.Rows[index].Cells[0].Value.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_QLSV form_QLSV = new Form_QLSV(this.id_lop,id_TK);
            form_QLSV.ShowDialog();
        }
    }
}
