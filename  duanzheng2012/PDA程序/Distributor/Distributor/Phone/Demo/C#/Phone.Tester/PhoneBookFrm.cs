using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SEUIC.Phone.Tester
{
    public partial class PhoneBookFrm : Form
    {
        public PhoneBookFrm()
        {
            InitializeComponent();
        }

        PhoneBook.PhoneBookCollection mPhoneBookCollection = new PhoneBook.PhoneBookCollection();

        private void PhoneBookFrm_Load(object sender, EventArgs e)
        {
            mPhoneBookCollection.Refresh();
            ShowPhoneBookList(mPhoneBookCollection);
        }

        public void ShowPhoneBookList(PhoneBook.PhoneBookCollection phonebookCollection)
        {
            lvPhoneBook.Items.Clear();

            for (int i = 0; i < phonebookCollection.Count; i++)
            {
                lvPhoneBook.Items.Add(new ListViewItem(new string[]{i.ToString(),
                    phonebookCollection[i].DBID.ToString(),
                    phonebookCollection[i].PhoneNumber.ToString(),
                    phonebookCollection[i].Name.ToString(),
                    phonebookCollection[i].Unit.ToString()}));
            }

            lvPhoneBook.Refresh();
        }

        private void PhoneBookFrm_Closing(object sender, CancelEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            mPhoneBookCollection.Refresh();
            ShowPhoneBookList(mPhoneBookCollection);

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lvPhoneBook.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection indexes = lvPhoneBook.SelectedIndices;

                if (indexes.Count == 1)
                {
                    mPhoneBookCollection.RemoveAt(indexes[0]);

                    ShowPhoneBookList(mPhoneBookCollection);

                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PhoneBook.PhoneBook phoneBook = new PhoneBook.PhoneBook();
            phoneBook.Name = tbName.Text;
            phoneBook.PhoneNumber = tbNo.Text;
            phoneBook.Unit = tbUnit.Text;

            mPhoneBookCollection[lvPhoneBook.SelectedIndices[0]] = phoneBook;

            ShowPhoneBookList(mPhoneBookCollection);

        }

        private void lvPhoneBook_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (lvPhoneBook.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection indexes = lvPhoneBook.SelectedIndices;

                if (indexes.Count == 1)
                {
                    tbNo.Text = mPhoneBookCollection[indexes[0]].PhoneNumber;
                    tbName.Text = mPhoneBookCollection[indexes[0]].Name;
                    tbUnit.Text = mPhoneBookCollection[indexes[0]].Unit;
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PhoneBook.PhoneBook phoneBook = new PhoneBook.PhoneBook();
            phoneBook.Name = tbName.Text;
            phoneBook.PhoneNumber = tbNo.Text;
            phoneBook.Unit = tbUnit.Text;

            mPhoneBookCollection.Add(phoneBook);

            ShowPhoneBookList(mPhoneBookCollection);

        }
    }
}