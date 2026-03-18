using Classword_2Forms.StudentServiceRef;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classword_2Forms
{
    public partial class Form1 : Form
    {
        StudentServiceClient client = new StudentServiceClient();
        int selectedId = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.GetStudents();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student s = new Student();

            s.FirstName = txtFirstName.Text;
            s.LastName = txtLastName.Text;
            s.Age = int.Parse(txtAge.Text);

            client.AddStudent(s);

            dataGridView1.DataSource = client.GetStudents();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;

            txtFirstName.Text = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
            txtLastName.Text = dataGridView1.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
            txtAge.Text = dataGridView1.Rows[e.RowIndex].Cells["Age"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student s = new Student();

            s.Id = selectedId;
            s.FirstName = txtFirstName.Text;
            s.LastName = txtLastName.Text;
            s.Age = int.Parse(txtAge.Text);

            client.UpdateStudent(s);

            dataGridView1.DataSource = client.GetStudents();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            client.DeleteStudent(selectedId);

            dataGridView1.DataSource = client.GetStudents();
        }
    }
}
