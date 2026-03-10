using DVLD.Classes;
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
    public partial class frmTakeTest : Form
    {
        private clsTest _Test;
        private clsTestType.enTestType _TestType;

        private int _TestID = -1;
       

        private int _appid = -1;
        
        public frmTakeTest(int appid, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _appid = appid;
            _TestType = TestType;
        }

        private void FrmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlSecheduledTest1.TestTypeID = _TestType;
            ctrlSecheduledTest1.LoadInfo(_appid);
            if (ctrlSecheduledTest1.TestAppointmentID == -1)

                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
            int _TestID = ctrlSecheduledTest1.TestID;
            if (_TestID != -1)
            {
                _Test = clsTest.Find(_TestID);
                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;
                txtNotes.Text = _Test.Notes;
                lblUserMessage.Visible = true;
                rbPass.Visible = false;
                rbFail.Visible = false;


            }
            else
                _Test = new clsTest();


        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                      "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
             )
            {
                return;
            }
            _Test.TestAppointmentID = _appid;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = txtNotes.Text;
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
