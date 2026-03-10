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
    public partial class frmListTestTypes : Form
    {
        private static DataTable _DtAllTestTypes;
        public frmListTestTypes()
        {
            InitializeComponent();
        }

        private void FrmListTestTypes_Load(object sender, EventArgs e)
        {
            _DtAllTestTypes = clsTestType.GetAllTestTypes();
            dgvTestTypes.DataSource = _DtAllTestTypes;
            lblRecordsCount.Text = dgvTestTypes.Rows.Count.ToString();
            dgvTestTypes.Columns[0].HeaderText = "ID";
            dgvTestTypes.Columns[0].Width = 120;
           
            dgvTestTypes.Columns[1].HeaderText = "Title";
            dgvTestTypes.Columns[1].Width = 200;
            dgvTestTypes.Columns[2].HeaderText = "Description";
            dgvTestTypes.Columns[2].Width = 400;

            dgvTestTypes.Columns[3].HeaderText = "Fees";
            dgvTestTypes.Columns[3].Width = 100;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmsTestTypes_Opening(object sender, CancelEventArgs e)
        {

        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmEditTestType frm = new frmEditTestType((clsTestType.enTestType)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            FrmListTestTypes_Load(null, null);

        }
    }
}
