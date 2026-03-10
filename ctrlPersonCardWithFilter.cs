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
    public partial class ctrlPersonCardWithFilter : UserControl
    {
       public event Action <int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID);
            }

        }
       private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }
        




        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }
        private int _PersonID = -1;

        public int PersonID
        {
            get { return cardperson1.PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return cardperson1.SelectedPersonInfo; }
        }
        public void LoadPersonInfo(int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            FindNow();
        }
        
        private void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    cardperson1.LoadPersonInfo(int.Parse(txtFilterValue.Text));
                    break;
                    case "National No.":
                    cardperson1.LoadPersonInfo(txtFilterValue.Text);
                    break;

                default:
                    break;
            }
        }

        private void GbFilters_Enter(object sender, EventArgs e)
        {

        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            FindNow();

        }
        private void DataBackEvent(object sender, int PersonID) {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            cardperson1.LoadPersonInfo(PersonID);
        }
        private void BtnAddNewPerson_Click(object sender, EventArgs e)
        {
           addandupdate frm = new addandupdate();
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();
        }

        private void TxtFilterValue_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
