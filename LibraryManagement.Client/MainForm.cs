using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LibraryManagement.Client.Helpers;
using LibraryManagement.Client.Models;

namespace LibraryManagement.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshAllData();
        }

        private void RefreshAllData()
        {
            LoadBooks();
            LoadMembers();
            LoadBorrowData();
            LoadTransactions();
        }

        private void LoadBooks()
        {
            try
            {
                var response = ApiHelper.Get<ApiResponse<List<BookDto>>>("/books");

                if (response.Success)
                {
                    dgvBooks.AutoGenerateColumns = true;
                    dgvBooks.DataSource = null;
                    dgvBooks.DataSource = response.Data;
                }
                else
                {
                    MessageBox.Show(response.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message);
            }
        }

        private void LoadMembers()
        {
            try
            {
                var response = ApiHelper.Get<ApiResponse<List<MemberDto>>>("/members");

                if (response.Success)
                {
                    dgvMembers.AutoGenerateColumns = true;
                    dgvMembers.DataSource = null;
                    dgvMembers.DataSource = response.Data;
                }
                else
                {
                    MessageBox.Show(response.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading members: " + ex.Message);
            }
        }

        private void LoadBorrowData()
        {
            try
            {
                var booksResponse = ApiHelper.Get<ApiResponse<List<BookDto>>>("/books");
                var membersResponse = ApiHelper.Get<ApiResponse<List<MemberDto>>>("/members");

                if (booksResponse.Success)
                {
                    cmbBorrowBooks.DataSource = null;
                    cmbBorrowBooks.DataSource = booksResponse.Data;
                    cmbBorrowBooks.DisplayMember = "Title";
                    cmbBorrowBooks.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show(booksResponse.Message);
                }

                if (membersResponse.Success)
                {
                    cmbBorrowMembers.DataSource = null;
                    cmbBorrowMembers.DataSource = membersResponse.Data;
                    cmbBorrowMembers.DisplayMember = "FullName";
                    cmbBorrowMembers.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show(membersResponse.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading borrow data: " + ex.Message);
            }
        }

        private void LoadTransactions()
        {
            try
            {
                var response = ApiHelper.Get<ApiResponse<List<BorrowTransactionDto>>>("/transactions");

                if (response.Success)
                {
                    dgvTransactions.AutoGenerateColumns = true;
                    dgvTransactions.DataSource = null;
                    dgvTransactions.DataSource = response.Data;
                }
                else
                {
                    MessageBox.Show(response.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions: " + ex.Message);
            }
        }

        private void ClearBookFields()
        {
            txtBookId.Text = "";
            txtBookTitle.Text = "";
            txtBookAuthor.Text = "";
            txtBookISBN.Text = "";
            numBookQuantity.Value = 0;
        }

        private void ClearMemberFields()
        {
            txtMemberId.Text = "";
            txtMemberName.Text = "";
            txtMemberEmail.Text = "";
            txtMemberPhone.Text = "";
        }

        private void ClearBorrowFields()
        {
            txtReturnTransactionId.Text = "";
        }

        private void btnLoadBooks_Click(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new CreateBookRequest
                {
                    Title = txtBookTitle.Text,
                    Author = txtBookAuthor.Text,
                    ISBN = txtBookISBN.Text,
                    Quantity = (int)numBookQuantity.Value
                };

                var response = ApiHelper.Post<ApiResponse<BookDto>>("/books/add", request);

                MessageBox.Show(response.Message);

                if (response.Success)
                {
                    RefreshAllData();
                    ClearBookFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding book: " + ex.Message);
            }
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                if (!int.TryParse(txtBookId.Text, out id))
                {
                    MessageBox.Show("Invalid Book Id.");
                    return;
                }

                var request = new UpdateBookRequest
                {
                    Id = id,
                    Title = txtBookTitle.Text,
                    Author = txtBookAuthor.Text,
                    ISBN = txtBookISBN.Text,
                    Quantity = (int)numBookQuantity.Value
                };

                var response = ApiHelper.Put<ApiResponse<BookDto>>("/books/update", request);

                MessageBox.Show(response.Message);

                if (response.Success)
                {
                    RefreshAllData();
                    ClearBookFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating book: " + ex.Message);
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                if (!int.TryParse(txtBookId.Text, out id))
                {
                    MessageBox.Show("Invalid Book Id.");
                    return;
                }

                if (MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                var response = ApiHelper.Delete<ApiResponse<bool>>("/books/delete/" + id);

                MessageBox.Show(response.Message);

                if (response.Success)
                {
                    RefreshAllData();
                    ClearBookFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting book: " + ex.Message);
            }
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvBooks.Rows[e.RowIndex];

                txtBookId.Text = row.Cells["Id"].Value?.ToString();
                txtBookTitle.Text = row.Cells["Title"].Value?.ToString();
                txtBookAuthor.Text = row.Cells["Author"].Value?.ToString();
                txtBookISBN.Text = row.Cells["ISBN"].Value?.ToString();

                int quantity;
                if (int.TryParse(row.Cells["Quantity"].Value?.ToString(), out quantity))
                {
                    numBookQuantity.Value = quantity;
                }
            }
        }

        private void btnLoadMembers_Click(object sender, EventArgs e)
        {
            LoadMembers();
        }

        private void btnAddMembers_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new CreateMemberRequest
                {
                    FullName = txtMemberName.Text,
                    Email = txtMemberEmail.Text,
                    Phone = txtMemberPhone.Text
                };

                var response = ApiHelper.Post<ApiResponse<MemberDto>>("/members/add", request);

                MessageBox.Show(response.Message);

                if (response.Success)
                {
                    RefreshAllData();
                    ClearMemberFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding member: " + ex.Message);
            }
        }

        private void btnUpdateMembers_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                if (!int.TryParse(txtMemberId.Text, out id))
                {
                    MessageBox.Show("Invalid Member Id.");
                    return;
                }

                var request = new UpdateMemberRequest
                {
                    Id = id,
                    FullName = txtMemberName.Text,
                    Email = txtMemberEmail.Text,
                    Phone = txtMemberPhone.Text
                };

                var response = ApiHelper.Put<ApiResponse<MemberDto>>("/members/update", request);

                MessageBox.Show(response.Message);

                if (response.Success)
                {
                    RefreshAllData();
                    ClearMemberFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating member: " + ex.Message);
            }
        }

        private void btnDeleteMembers_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                if (!int.TryParse(txtMemberId.Text, out id))
                {
                    MessageBox.Show("Invalid Member Id.");
                    return;
                }

                if (MessageBox.Show("Are you sure you want to delete this member?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                var response = ApiHelper.Delete<ApiResponse<bool>>("/members/delete/" + id);

                MessageBox.Show(response.Message);

                if (response.Success)
                {
                    RefreshAllData();
                    ClearMemberFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting member: " + ex.Message);
            }
        }

        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvMembers.Rows[e.RowIndex];

                txtMemberId.Text = row.Cells["Id"].Value?.ToString();
                txtMemberName.Text = row.Cells["FullName"].Value?.ToString();
                txtMemberEmail.Text = row.Cells["Email"].Value?.ToString();
                txtMemberPhone.Text = row.Cells["Phone"].Value?.ToString();
            }
        }

        private void btnLoadTransactions_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }


        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBorrowBooks.SelectedValue == null)
                {
                    MessageBox.Show("Please select a book.");
                    return;
                }

                if (cmbBorrowMembers.SelectedValue == null)
                {
                    MessageBox.Show("Please select a member.");
                    return;
                }

                var request = new BorrowBookRequest
                {
                    BookId = Convert.ToInt32(cmbBorrowBooks.SelectedValue),
                    MemberId = Convert.ToInt32(cmbBorrowMembers.SelectedValue)
                };

                var response = ApiHelper.Post<ApiResponse<BorrowTransactionDto>>("/borrow", request);

                MessageBox.Show(response.Message);

                if (response.Success && response.Data != null)
                {
                    txtReturnTransactionId.Text = response.Data.Id.ToString();
                    RefreshAllData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error borrowing book: " + ex.Message);
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            try
            {
                int transactionId;
                if (!int.TryParse(txtReturnTransactionId.Text, out transactionId))
                {
                    MessageBox.Show("Invalid Transaction Id.");
                    return;
                }

                var request = new ReturnBookRequest
                {
                    TransactionId = transactionId
                };

                var response = ApiHelper.Post<ApiResponse<BorrowTransactionDto>>("/return", request);

                MessageBox.Show(response.Message);

                if (response.Success)
                {
                    RefreshAllData();
                    ClearBorrowFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error returning book: " + ex.Message);
            }
        }

        private void txtReturnTransactionId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvTransactions.Rows[e.RowIndex];
                txtReturnTransactionId.Text = row.Cells["Id"].Value?.ToString();
            }
        }
    }
}