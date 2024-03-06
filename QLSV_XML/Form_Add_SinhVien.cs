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
    public partial class Form_Add_SinhVien : Form
    {
        string id_lop;
        string fileName = @"D:\zKiemlongJr\XML\QLSV\QLSV_XML\SinhVien.xml";
        XmlDocument doc = new XmlDocument();
        XmlElement ql_sinhvien;
        string id_tk;
        

        public Form_Add_SinhVien(string id_lop, string id_tk)
        {
            InitializeComponent();
            this.id_lop = id_lop;
            this.id_tk = id_tk;
        }



        void show(DataGridView dgv)
        {
            doc.Load(fileName);
            ql_sinhvien = doc.DocumentElement;


            XmlNodeList ds_sv = ql_sinhvien.SelectNodes("SinhVien");

            int sd = 0;

            foreach (XmlNode node in ds_sv)
            {

                if (node.SelectSingleNode("Id_Lop").InnerText == this.id_lop)
                {
                    dgv.Rows.Add();
                    dgv.Rows[sd].Cells[0].Value = node.SelectSingleNode("@Id_SinhVien").Value;
                    dgv.Rows[sd].Cells[1].Value = node.SelectSingleNode("HoTen").InnerText;
                    dgv.Rows[sd].Cells[2].Value = node.SelectSingleNode("HoTen").InnerText;
                    dgv.Rows[sd].Cells[3].Value = node.SelectSingleNode("NgaySinh").InnerText;
                    dgv.Rows[sd].Cells[4].Value = node.SelectSingleNode("GioiTinh").InnerText;
                    dgv.Rows[sd].Cells[5].Value = node.SelectSingleNode("DiaChi").InnerText;
                    dgv.Rows[sd].Cells[6].Value = node.SelectSingleNode("SDT").InnerText;
                    dgv.Rows[sd].Cells[7].Value = node.SelectSingleNode("GPA").InnerText;
                    sd++;

                }
            }



        }


        private void Form_Add_SinhVien_Load(object sender, EventArgs e)
        {
            

        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

    

        private void button1_Click_1(object sender, EventArgs e)
        {
            doc.Load(fileName);

            ql_sinhvien = doc.DocumentElement;

            XmlNode SinhVien = doc.CreateElement("SinhVien");

            XmlAttribute Id_sinhvien = doc.CreateAttribute("Id_SinhVien");
            Id_sinhvien.Value = txt_id_sinhvien.Text;

            SinhVien.Attributes.Append(Id_sinhvien);


            XmlElement Id_Lop = doc.CreateElement("Id_Lop");
            Id_Lop.InnerText = id_lop;
            SinhVien.AppendChild(Id_Lop);


            XmlElement HoTen = doc.CreateElement("HoTen");
            HoTen.InnerText = txt_hoten.Text;

            SinhVien.AppendChild(HoTen);

            XmlElement NgaySinh = doc.CreateElement("NgaySinh");
            NgaySinh.InnerText = txt_ngaysinh.Text;
            SinhVien.AppendChild(NgaySinh);

            XmlElement GioiTinh = doc.CreateElement("GioiTinh");
            GioiTinh.InnerText = txt_gioitinh.Text;
            SinhVien.AppendChild(GioiTinh);

            XmlElement DiaChi = doc.CreateElement("DiaChi");
            DiaChi.InnerText = txt_diachi.Text;
            SinhVien.AppendChild(DiaChi);

            XmlElement SDT = doc.CreateElement("SDT");
            SDT.InnerText = txt_dienthoai.Text;
            SinhVien.AppendChild(SDT);

            XmlElement GPA = doc.CreateElement("GPA");
            GPA.InnerText = txt_gpa.Text;

            SinhVien.AppendChild(GPA);

            ql_sinhvien.AppendChild(SinhVien);

            doc.Save(fileName);
            this.Hide();
            
            Form_QLSV showql = new Form_QLSV(this.id_lop, this.id_tk);
            showql.ShowDialog();
        }
    }
}
