using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Wordle_WinForms
{
    public partial class StatsForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string ApiBaseUrl = "https://localhost:7244";

        public StatsForm(int currentUserId)
        {
            InitializeComponent();
            _httpClient.BaseAddress = new Uri(ApiBaseUrl);
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Bearer", LoginForm.AppSession.Token);
        }

        private async void StatsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var stats = await _httpClient.GetFromJsonAsync<StatsResponseDto>("/api/statistics");
                if (stats == null)
                {
                    MessageBox.Show("Could not load statistics.");
                    return;
                }
                lblPlayedNumber.Text = stats.Played.ToString();
                lblWinNumber.Text = stats.WinPercentage.ToString();
                lblCurrentStreakNumber.Text = stats.CurrentStreak.ToString();
                lblMaxStreakNumber.Text = stats.MaxStreak.ToString();
            }
            catch
            {
                MessageBox.Show("Could not connect to API. Make sure backend is running.");
            }
        }
    }

    public class StatsResponseDto
    {
        [JsonPropertyName("played")]
        public int Played { get; set; }
        [JsonPropertyName("wins")]
        public int Wins { get; set; }
        [JsonPropertyName("winPercentage")]
        public int WinPercentage { get; set; }
        [JsonPropertyName("currentStreak")]
        public int CurrentStreak { get; set; }
        [JsonPropertyName("maxStreak")]
        public int MaxStreak { get; set; }
    }
}