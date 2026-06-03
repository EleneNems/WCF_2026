using System.Net.Http.Json;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace Wordle_WinForms
{
    public partial class LoginForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        private const string ApiBaseUrl = "https://localhost:7244";

        public LoginForm()
        {
            InitializeComponent();
            _httpClient.BaseAddress = new Uri(ApiBaseUrl);
            
        }

        private async void btnContinue_Click(object sender, EventArgs e)
        {
            string username = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter your email.");
                return;
            }

            if (!IsValidEmail(username))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            var request = new AuthRequest
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            var response = await _httpClient.PostAsJsonAsync("/api/auth/login", request);

            if (!response.IsSuccessStatusCode)
            {

                var errorContent = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Login failed. Please check your credentials.");
                return;
            }

            var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
            AppSession.UserId = result!.UserId;
            AppSession.Username = result.Email;
            AppSession.Token = result.Token;

            Form1 gameForm = new Form1(result.UserId, result.Email);
            gameForm.Show();

            this.Hide();
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm("");
            registerForm.Show();
            this.Hide();
        }

        public class AuthRequest
        {
            public string Email { get; set; } = "";
            public string Password { get; set; } = "";
        }

        public class AuthResponse
        {
            [JsonPropertyName("userId")]
            public int UserId { get; set; }

            [JsonPropertyName("email")]
            public string Email { get; set; } = "";

            [JsonPropertyName("message")]
            public string Message { get; set; } = "";

            [JsonPropertyName("token")]
            public string Token { get; set; } = "";
        }

        public static class AppSession
        {
            public static int UserId { get; set; }
            public static string Username { get; set; } = "";
            public static string Token { get; set; } = "";
        }

        private bool IsValidEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
            );
        }
        private TextBox txtPassword;
        private Label label1;
    }
}