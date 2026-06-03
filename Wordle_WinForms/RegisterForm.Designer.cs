using System.Net.Http.Json;
using System.Text.Json.Serialization;

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
                Email = username,
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
            LoginForm.AppSession.UserId = result!.UserId;
            LoginForm.AppSession.Username = result.Email;
            LoginForm.AppSession.Token = result.Token;

            Form1 form = new Form1(result.UserId, result.Email); 
            form.Show();
            this.Hide();
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();

            loginForm.Show();

            this.Hide();
        }

        public class AuthRequest
        {
            public string Email { get; set; } = "";
            public string Password { get; set; } = "";
        }
        public class AuthResponse
        {
            [JsonPropertyName("userId")] public int UserId { get; set; }
            [JsonPropertyName("email")] public string Email { get; set; } = "";
            [JsonPropertyName("token")] public string Token { get; set; } = "";
            [JsonPropertyName("message")] public string Message { get; set; } = "";
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