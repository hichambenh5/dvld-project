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
    public partial class frmListApplicationTypes : Form
    {
        private static DataTable _DtAllApplicationTypes=clsApplicationType.GetAllApplicationTypes();
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void CmsApplicationTypes_Opening(object sender, CancelEventArgs e)
        {

        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            FrmListApplicationTypes_Load(null, null);
        }

        private void FrmListApplicationTypes_Load(object sender, EventArgs e)
        {
            dgvApplicationTypes.DataSource = _DtAllApplicationTypes;
            lblRecordsCount.Text = dgvApplicationTypes.Rows.Count.ToString();
           
                dgvApplicationTypes.Columns[0].HeaderText = "ID";
                dgvApplicationTypes.Columns[0].Width = 120;
                dgvApplicationTypes.Columns[1].HeaderText = "Title";
                dgvApplicationTypes.Columns[1].Width = 400;
                dgvApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvApplicationTypes.Columns[2].Width = 100;

            
        }
    }
}
