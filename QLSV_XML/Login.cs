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
    public partial class Login : Form
    {

        string fileName = @"D:\zKiemlongJr\XML\QLSV\QLSV_XML\TaiKhoan.xml";
        XmlDocument doc = new XmlDocument();
        XmlElement ql_taikhoan;
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            doc.Load(fileName);

            ql_taikhoan = doc.DocumentElement;
            XmlNode check_tk = ql_taikhoan.SelectSingleNode("TaiKhoan[TaiKhoan ='" + txt_taikhoan.Text + "']");


            if(check_tk != null)
            {
                if(check_tk.SelectSingleNode("MatKhau").InnerText == txt_matkhau.Text)
                {
                    this.Hide();
                    Form1 lop = new Form1(check_tk.SelectSingleNode("@id_TaiKhoan").Value.ToString());
                    lop.ShowDialog();
                }
                else
                {

                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Đăng nhập thất bại");
                }

            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại", "Đăng nhập thất bại");
            }



        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            Sigup sigup = new Sigup();
            sigup.ShowDialog();
        }
    }
}
