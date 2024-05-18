using System.Text.Json;
using ClassLibraryIndividueel.Business;


namespace MauiAppNintendoGames
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnButtonClick(object sender, EventArgs e)
        {
            RestService restService = new RestService();
            try
            {
                // GET request to fetch NDS games
                string jsonResponse = await restService.GetAsync("NDS");

                // Deserialize JSON response into a list of NdsGame objects
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<NdsGame> ndsGames = JsonSerializer.Deserialize<List<NdsGame>>(jsonResponse, options);

                // Log the JSON response for debugging
                Console.WriteLine(jsonResponse);

                // Use the data as needed, for example, bind it to a ListView
                LstGames.ItemsSource = ndsGames;
                LstGames.IsVisible = true;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log error, display message)
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

}
