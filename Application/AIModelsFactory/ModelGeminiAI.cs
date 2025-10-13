using System.Text;
using Application.Abstractions.Services;
using Domain.Entities;
using DotNetEnv;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharedKernel;

namespace Application.AIModelsFactory;

public class ModelGeminiAI(Booking booking, IPromptService promptService) : ModelAI(booking)
{
    public override async Task<string?> SendPrompt(string prompt)
    {
        Env.Load();

        var apiKeyName = booking.Host.EnvironmentVariable;

        string? apiKey = Environment.GetEnvironmentVariable(apiKeyName);

        if (apiKey == null)
        {
            return null;
        }

        string modelIdentifier = booking.Host.Identifier;

        string url =
            $"https://generativelanguage.googleapis.com/v1beta/models/{modelIdentifier}:generateContent?key={apiKey}";

        using var httpClient = new HttpClient();

        var prompts = await promptService.GetAllAsyncByThread(booking.Id);

        var contents = new List<object>();

        foreach (var promptRecord in prompts)
        {
            contents.Add(new
            {
                role = "user",
                parts = new []
                {
                    new {text = promptRecord.PromptText}
                }
            });
            
            contents.Add(new
            {
                role = "model",
                parts = new []
                {
                    new {text = promptRecord.Response}
                }
            });
        }
        
        contents.Add(new
        {
            role = "user",
            parts = new []
            {
                new {text = prompt}
            }
        });
        
        var payload = new
        {
            contents = contents.ToArray(),
            generationConfig = new
            {
                temperature = booking.Host.Temperature
            }
        };

        var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

        try
        {
            var response = await httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            JObject responseJson = JObject.Parse(responseBody);


            var text = (string)(responseJson["candidates"][0]["content"]["parts"][0]["text"]);

            return text;
        }
        catch (Exception ex)
        {
            throw new Exception($"{ErrorMessages.ErrorRequestLLM}: {ex.Message}");
        }
    }
}