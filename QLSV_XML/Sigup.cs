using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_XML
{
    public partial class Sigup : Form
    {
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
    }
}
