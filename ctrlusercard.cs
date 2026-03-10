using DVLD_Buisness;
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
    public partial class ctrlusercard : UserControl
    {
        clsUser _User;
        int _Userid = -1;
        int _personid = -1;
        public int userID
        {
            get { return _Userid; }
        }

        public clsUser SelecteduserInfo
        {
            get { return _User; }
        }
        public ctrlusercard()
        {
            InitializeComponent();
           
           
        }
        public void ResetuserInfo()
        {
            _Userid = -1;
            _personid = _User.PersonID;
            cardperson1.LoadPersonInfo(_personid);
            lblUserID.Text = "";
            lblUserName.Text = "";
            lblIsActive.Text = "";
        }
        public void LoaduserInfo(int userid)
        {
            
           _User = clsUser.FindByUserID(userid);
           
            if (_User == null)
            {
               ResetuserInfo();
                MessageBox.Show("No Person with PersonID = " + userid.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillusersInfo();
        }
       
        
        private void _FillusersInfo()
        {
            _Userid = _User.UserID;
            _personid = _User.PersonID;
            cardperson1.LoadPersonInfo(_personid);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName;
            lblIsActive.Text = _User.IsActive.ToString();
        }
        private void Ctrlusercard_Load(object sender, EventArgs e)
        {

        }
    }
}
