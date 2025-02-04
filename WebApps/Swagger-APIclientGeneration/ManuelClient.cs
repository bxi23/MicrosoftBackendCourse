public class Clients
{
    // ================================
    // manual client generation
    // ==============================
    public async Task ManualClient()
    {
        var httpClient = new HttpClient();
        var apiBaseUrl = "http://localhost:5000";

        var httpResults = await httpClient.GetAsync($"{apiBaseUrl}/blogs");

        //check if status code are okay
        if (httpResults.StatusCode != System.Net.HttpStatusCode.OK)
        {
            Console.WriteLine("Error");
            return;
        }

        //create stream to hold blogs
        var stream = await httpResults.Content.ReadAsStreamAsync();

        var options = new System.Text.Json.JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var blogs = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Blog>>(stream, options);

        if (blogs == null)
        {
            Console.WriteLine("Error");
            return;
        }
    }
}
