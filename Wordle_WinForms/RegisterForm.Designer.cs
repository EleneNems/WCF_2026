using System.Net.Http.Json;

namespace Wordle_WinForms
{
    public partial class RegisterForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        private const string ApiBaseUrl = "https://localhost:7244";

        public RegisterForm(string email)
        {
            InitializeComponent();

            _httpClient.BaseAddress = new Uri(ApiBaseUrl);

            txtEmail.Text = email;
            txtEmail.ReadOnly = false;

            txtPassword.PasswordChar = '●';
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '●')
            {
                txtPassword.PasswordChar = '\0';
                btnShow.Text = "Hide";
            }
            else
            {
                txtPassword.PasswordChar = '●';
                btnShow.Text = "Show";
            }
        }

        private async void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string username = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Email is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password is required.");
                return;
            }

            if (!IsValidEmail(username))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            var request = new AuthRequest
            {
                Username = username,
                Password = password
            };

            var response = await _httpClient.PostAsJsonAsync("/api/auth/register", request);

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();

                MessageBox.Show(error);

                return;
            }

            var result = await response.Content.ReadFromJsonAsync<AuthResponse>();

            Form1 form = new Form1(result!.UserId, result.Username);

            form.Show();

            this.Hide();
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();

            loginForm.Show();

            this.Hide();
        }

        private bool IsValidEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
            );
        }
    }
}