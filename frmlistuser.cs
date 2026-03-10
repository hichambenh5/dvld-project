using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace projet19dvld
{
    public partial class frmlistuser : Form
    {
        private static DataTable _DtAllUser = clsUser.GetAllUsers();
      
        
        public frmlistuser()
        {
            InitializeComponent();
        }

        private void Frmlistuser_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = _DtAllUser;
            cbFilterBy.SelectedIndex = 0;
           if(dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "UserID";
                dgvUsers.Columns[0].Width = 120;
                dgvUsers.Columns[1].HeaderText = "PersonID";
                dgvUsers.Columns[1].Width = 120;
                dgvUsers.Columns[2].HeaderText = "FullName";
                dgvUsers.Columns[2].Width = 600;
                dgvUsers.Columns[3].HeaderText = "UserName";
                dgvUsers.Columns[3].Width = 120;




            }
        }

        private void PbPersonImage_Click(object sender, EventArgs e)
        {
            

        }

        private void TxtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                


                default:
                    FilterColumn = "None";
                    break;
                   

            }
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _DtAllUser.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
                return;
            }if (FilterColumn != "FullName" && FilterColumn != "UserName")
            {
                _DtAllUser.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
              
               
            }
          
            else { _DtAllUser.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, txtFilterValue.Text.Trim()); }
              




        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            Form frm = new frmaddupdateuser();
            frm.ShowDialog();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmaddupdateuser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            Frmlistuser_Load(null, null);
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmaddupdateuser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete users [" + dgvUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {
                if (clsUser.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("users Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Frmlistuser_Load(null, null);
                }
                else
                    MessageBox.Show("users was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvUsers.CurrentRow.Cells[0].Value;
            Form frm = new frmuserinfo(id);
            frm.ShowDialog();
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ChangemodepaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new changepassowrd((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void CbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.Text== "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible=(cbFilterBy.Text != "None");
                cbIsActive.Visible = false;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void CbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;
            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;

                    

            }
            if (FilterValue == "All")
                _DtAllUser.DefaultView.RowFilter = "";
            else
                _DtAllUser.DefaultView.RowFilter = String.Format("[{0}] = {1}", FilterColumn, FilterValue);
        }
    }
    }

