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
    public partial class Sigup : Form
    {


        string fileName = @"D:\Soure_Code\Window\QLSV_XML\QLSV_XML\TaiKhoan.xml";
        XmlDocument doc = new XmlDocument();
        XmlElement ql_taikhoan;

        public Sigup()
        {
            InitializeComponent();
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
         
        }


        private void btn_dangki_Click(object sender, EventArgs e)
        {
            doc.Load(fileName);

            ql_taikhoan = doc.DocumentElement;
            XmlNode check_tk = ql_taikhoan.SelectSingleNode("TaiKhoan[TaiKhoan ='" +txt_taikhoan.Text+ "']");


            if(txt_taikhoan.Text.Length >5 && txt_matkhau.Text.Length>5 && txt_sdt.Text.Length>5 &&txt_hoten.Text.Length>5  ) {

                if (check_tk == null)
                {
                    XmlNodeList ds_tk = ql_taikhoan.SelectNodes("TaiKhoan");
                    XmlNode TaiKhoan = doc.CreateElement("TaiKhoan");
                    XmlAttribute id_tk = doc.CreateAttribute("id_TaiKhoan");

                    int id = ds_tk.Count + 1;
                    id_tk.Value = id.ToString();
                    TaiKhoan.Attributes.Append(id_tk);
                    XmlElement tk = doc.CreateElement("TaiKhoan");
                    tk.InnerText = txt_taikhoan.Text;
                    TaiKhoan.AppendChild(tk);


                    XmlElement mk = doc.CreateElement("MatKhau");
                    mk.InnerText = txt_matkhau.Text;
                    TaiKhoan.AppendChild(mk);

                    XmlElement hoten = doc.CreateElement("HoTen");
                    hoten.InnerText = txt_hoten.Text;
                    TaiKhoan.AppendChild(hoten);

                    XmlElement sdt = doc.CreateElement("SDT");
                    sdt.InnerText = txt_sdt.Text;
                    TaiKhoan.AppendChild(sdt);

                    ql_taikhoan.AppendChild(TaiKhoan);

                    doc.Save(fileName);
                   DialogResult result =MessageBox.Show("Bạn đã đang kí tài khoản thành công bạn có muốn chuyển qua màn hình đăng nhập", "Thành Công", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        this.Hide();
                        Login login = new Login();
                        login.ShowDialog();
                    }
                    else
                    {
                    
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản đã tồn tại", "Thất Bại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thất Bại");

            }



        }

        }
}
