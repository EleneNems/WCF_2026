using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Wordle_WinForms;

public partial class Form1 : Form
{
    private readonly HttpClient _httpClient = new HttpClient();

    private int _gameId;
    private int _currentRow = 0;
    private int _currentCol = 0;
    private string _currentGuess = "";
    private int _currentUserId;
    private string _currentUsername = "";

    private const string ApiBaseUrl = "https://localhost:7244";
    public Form1(int userId, string username)
    {
        InitializeComponent();

        _currentUserId = userId;
        _currentUsername = username;

        _httpClient.BaseAddress = new Uri(ApiBaseUrl);

        _httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Bearer",
                LoginForm.AppSession.Token);
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        InitializeBoxesArray();
        await StartNewGame();
    }

    private void InitializeBoxesArray()
    {
        _boxes[0, 0] = txt00; _boxes[0, 1] = txt01; _boxes[0, 2] = txt02; _boxes[0, 3] = txt03; _boxes[0, 4] = txt04;
        _boxes[1, 0] = txt10; _boxes[1, 1] = txt11; _boxes[1, 2] = txt12; _boxes[1, 3] = txt13; _boxes[1, 4] = txt14;
        _boxes[2, 0] = txt20; _boxes[2, 1] = txt21; _boxes[2, 2] = txt22; _boxes[2, 3] = txt23; _boxes[2, 4] = txt24;
        _boxes[3, 0] = txt30; _boxes[3, 1] = txt31; _boxes[3, 2] = txt32; _boxes[3, 3] = txt33; _boxes[3, 4] = txt34;
        _boxes[4, 0] = txt40; _boxes[4, 1] = txt41; _boxes[4, 2] = txt42; _boxes[4, 3] = txt43; _boxes[4, 4] = txt44;
        _boxes[5, 0] = txt50; _boxes[5, 1] = txt51; _boxes[5, 2] = txt52; _boxes[5, 3] = txt53; _boxes[5, 4] = txt54;
    }

    private async Task StartNewGame()
    {
        ClearBoard();

        var response = await _httpClient.PostAsJsonAsync("/api/games/start", new
        {
            userId = _currentUserId
        });

        if (!response.IsSuccessStatusCode)
        {
            MessageBox.Show("Could not start game. Check if API is running.");
            return;
        }

        var result = await response.Content.ReadFromJsonAsync<StartGameResponse>();

        if (result == null)
        {
            MessageBox.Show("Invalid response from API.");
            return;
        }

        _gameId = result.GameId;

        _currentRow = 0;
        _currentCol = 0;
        _currentGuess = "";
    }

    private async void KeyboardButton_Click(object sender, EventArgs e)
    {
        if (sender is not Button button)
            return;

        string value = button.Text;

        if (value == "ENTER")
        {
            await SubmitGuess();
            return;
        }

        if (value == "⌫")
        {
            DeleteLetter();
            return;
        }

        AddLetter(value);
    }

    private void AddLetter(string letter)
    {
        if (_currentRow >= 6)
            return;

        if (_currentCol >= 5)
            return;

        _currentGuess += letter.ToLower();

        TextBox box = _boxes[_currentRow, _currentCol];
        box.Text = letter.ToUpper();

        _currentCol++;
    }

    private void DeleteLetter()
    {
        if (_currentCol <= 0)
            return;

        _currentCol--;
        _currentGuess = _currentGuess[..^1];

        TextBox box = _boxes[_currentRow, _currentCol];
        box.Text = "";
    }

    private async Task SubmitGuess()
    {
        if (_currentGuess.Length != 5)
        {
            MessageBox.Show("Guess must be 5 letters.");
            return;
        }

        var request = new GuessRequest
        {
            GameId = _gameId,
            Word = _currentGuess
        };

        var response = await _httpClient.PostAsJsonAsync("/api/games/guess", request);

        if (!response.IsSuccessStatusCode)
        {
            MessageBox.Show("Invalid guess or game error.");
            return;
        }

        var result = await response.Content.ReadFromJsonAsync<GuessResponse>();

        if (result == null)
        {
            MessageBox.Show("Invalid response from API.");
            return;
        }

        for (int i = 0; i < result.Result.Count; i++)
        {
            string status = result.Result[i].Status;
            TextBox box = _boxes[_currentRow, i];

            if (status == "correct")
            {
                box.BackColor = Color.FromArgb(106, 170, 100);
            }
            else if (status == "present")
            {
                box.BackColor = Color.FromArgb(201, 180, 88);
            }
            else
            {
                box.BackColor = Color.FromArgb(120, 124, 126);
            }

            box.ForeColor = Color.White;
        }

        if (result.IsWin)
        {
            MessageBox.Show("You won!");
            await StartNewGame();
            return;
        }

        if (result.IsFinished)
        {
            MessageBox.Show("Game over!");
            await StartNewGame();
            return;
        }

        _currentRow++;
        _currentCol = 0;
        _currentGuess = "";
    }

    private void ClearBoard()
    {
        if (_boxes[0, 0] == null)
            return;

        for (int r = 0; r < 6; r++)
        {
            for (int c = 0; c < 5; c++)
            {
                _boxes[r, c].Text = "";
                _boxes[r, c].BackColor = Color.White;
                _boxes[r, c].ForeColor = Color.Black;
            }
        }
    }

    private async void btnNewGame_Click(object sender, EventArgs e)
    {
        await StartNewGame();
    }

    private void btnHelp_Click(object sender, EventArgs e)
    {
        HowToPlayForm helpForm = new HowToPlayForm();
        helpForm.ShowDialog();
    }

    private void btnStats_Click(object sender, EventArgs e)
    {
        StatsForm statsForm = new StatsForm(_currentUserId);
        statsForm.ShowDialog();
    }
}

public class StartGameResponse
{
    [JsonPropertyName("gameId")]
    public int GameId { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; } = "";
}

public class GuessRequest
{
    public int GameId { get; set; }

    public string Word { get; set; } = "";
}

public class GuessResponse
{
    [JsonPropertyName("gameId")]
    public int GameId { get; set; }

    [JsonPropertyName("guess")]
    public string Guess { get; set; } = "";

    [JsonPropertyName("attempt")]
    public int Attempt { get; set; }

    [JsonPropertyName("maxAttempts")]
    public int MaxAttempts { get; set; }

    [JsonPropertyName("isWin")]
    public bool IsWin { get; set; }

    [JsonPropertyName("isFinished")]
    public bool IsFinished { get; set; }

    [JsonPropertyName("result")]
    public List<LetterResult> Result { get; set; } = new();
}

public class LetterResult
{
    [JsonPropertyName("letter")]
    public char Letter { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = "";
}

public class AuthRequest
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
}

public class AuthResponse
{
    public int UserId { get; set; }
    public string Username { get; set; } = "";
    public string Message { get; set; } = "";
    public string Email { get; internal set; }
}

public class StatisticsResponse
{
    public int Played { get; set; }
    public int Wins { get; set; }
    public double WinPercentage { get; set; }
}