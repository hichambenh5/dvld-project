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
    public partial class showperson : Form
    {
        public showperson(int personid)
        {
            InitializeComponent();
            cardperson1.LoadPersonInfo(personid);
        }
        public showperson(string national)
        {
            InitializeComponent();
            cardperson1.LoadPersonInfo(national);
        }
        private void Cardperson1_Load(object sender, EventArgs e)
        {

        }

        private void Showperson_Load(object sender, EventArgs e)
        {

        }
    }
}
