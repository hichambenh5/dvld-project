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
    public partial class frmlistpeople : Form
    {
        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName",
                                                                       "SecondName", "ThirdName", "LastName", "GendorCaption", "DateOfBirth", "CountryName", "Phone", "Email");
        private void _RefreshPeoplList()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
            dataGridView1.DataSource = _dtPeople;
            lbldata.Text = dataGridView1.Rows.Count.ToString();
        }
        public frmlistpeople()
        {
            InitializeComponent();
        }

        private void Btnadd_Click(object sender, EventArgs e)
        {
            Form frm = new addandupdate();
            frm.ShowDialog();
        }

        private void Frmlistpeople_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _dtPeople;
            comboBox1.SelectedIndex = 0;
            lbldata.Text = dataGridView1.Rows.Count.ToString();
            if (dataGridView1.Rows.Count > 0)
            {

               dataGridView1.Columns[0].HeaderText = "Person ID";
                dataGridView1.Columns[0].Width = 110;

               dataGridView1.Columns[1].HeaderText = "National No.";
               dataGridView1.Columns[1].Width = 120;


               dataGridView1.Columns[2].HeaderText = "First Name";
                dataGridView1.Columns[2].Width = 120;

               dataGridView1.Columns[3].HeaderText = "Second Name";
               dataGridView1.Columns[3].Width = 140;


               dataGridView1.Columns[4].HeaderText = "Third Name";
               dataGridView1.Columns[4].Width = 120;

               dataGridView1.Columns[5].HeaderText = "Last Name";
               dataGridView1.Columns[5].Width = 120;

               dataGridView1.Columns[6].HeaderText = "Gendor";
               dataGridView1.Columns[6].Width = 120;

                dataGridView1.Columns[7].HeaderText = "Date Of Birth";
               dataGridView1.Columns[7].Width = 140;

               dataGridView1.Columns[8].HeaderText = "Nationality";
               dataGridView1.Columns[8].Width = 120;


               dataGridView1.Columns[9].HeaderText = "Phone";
                dataGridView1.Columns[9].Width = 120;


              dataGridView1.Columns[10].HeaderText = "Email";
               dataGridView1.Columns[10].Width = 170;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (comboBox1.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (textBox1.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lbldata.Text = dataGridView1.Rows.Count.ToString();
                return;
            }if (FilterColumn == "PersonID")

                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, textBox1.Text.Trim());
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new addandupdate();
            frm.ShowDialog();
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new addandupdate((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeoplList();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete Person [" + dataGridView1.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsPerson.DeletePerson((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeoplList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                int id=(int)dataGridView1.CurrentRow.Cells[0].Value;
            Form frm = new showperson(id);
            frm.ShowDialog();
        }
    }
}
