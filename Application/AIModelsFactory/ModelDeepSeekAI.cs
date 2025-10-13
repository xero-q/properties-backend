using System.Text;
using Application.Helpers;
using Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharedKernel;

namespace Application.AIModelsFactory;

public class ModelDeepSeekAI(Booking booking) : ModelAI(booking)
{
    public override async Task<string?> SendPrompt(string prompt)
    {
        string apiKeyName = booking.Host.EnvironmentVariable;

        var apiKey = Environment.GetEnvironmentVariable(apiKeyName);

        if (apiKey == null)
        {
            return null;
        }

        var url = "https://api.deepseek.com/chat/completions";

        string modelIdentifier = booking.Host.Identifier;

        var payload = new
        {
            model = modelIdentifier,
            messages = new[]
            {
                new { role = "system", content = "You are a helpful assistant." },
                new { role = "user", content = prompt },
            },
            stream = false,
            temperature = booking.Host.Temperature,
        };
        
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
        var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

        try
        {
            var response = await httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                JObject responseJson = JObject.Parse(responseBody);


                var text = (string)(responseJson["choices"][0]["message"]["content"]);

                return text;
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"{ErrorMessages.ErrorRequestLLM}: {ex.Message}");
        }
    }
}