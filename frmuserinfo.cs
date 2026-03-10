using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projet19dvld
{
    public partial class frmuserinfo : Form
    {
        private int _userid;
        public frmuserinfo(int userid)
        {
            InitializeComponent();
            _userid = userid;
        }
      

        private void Frmuserinfo_Load(object sender, EventArgs e)
        {
            ctrlusercard1.LoaduserInfo(_userid);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ctrlusercard1_Load(object sender, EventArgs e)
        {

        }
    }
}
