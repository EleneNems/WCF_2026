using System.Net.Http.Json;
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
                Username = username,
                Password = ""
            };

            var response = await _httpClient.PostAsJsonAsync("/api/auth/login", request);

            if (!response.IsSuccessStatusCode)
            {
                RegisterForm registerForm = new RegisterForm(username);
                registerForm.Show();
                this.Hide();
                return;
            }

            var result = await response.Content.ReadFromJsonAsync<AuthResponse>();

            Form1 gameForm = new Form1(result!.UserId, result.Username);
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
            public string Username { get; set; } = "";
            public string Password { get; set; } = "";
        }

        public class AuthResponse
        {
            [JsonPropertyName("userId")]
            public int UserId { get; set; }

            [JsonPropertyName("username")]
            public string Username { get; set; } = "";

            [JsonPropertyName("message")]
            public string Message { get; set; } = "";
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