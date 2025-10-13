using System.Text;
using Application.Abstractions.Services;
using Application.Helpers;
using Domain.Entities;
using DotNetEnv;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharedKernel;

namespace Application.AIModelsFactory;

public class ModelMistralAI(Booking booking, IPromptService promptService) : ModelAI(booking)
{
    public override async Task<string?> SendPrompt(string prompt)
    {
        Env.Load();

        string apiKeyName = booking.Host.EnvironmentVariable;

        string? apiKey = Environment.GetEnvironmentVariable(apiKeyName);

        if (apiKey == null)
        {
            return null;
        }

        string url = "https://api.mistral.ai/v1/chat/completions";

        string modelIdentifier = booking.Host.Identifier;
        
        var prompts = await promptService.GetAllAsyncByThread(booking.Id);

        var messages = new List<object>();

        foreach (var promptRecord in prompts)
        {
            messages.Add(new
            {
                role = "user",
                content = promptRecord.PromptText
            });
            
            messages.Add(new
            {
                role = "system",
                content = promptRecord.Response
            });
        }
        
        messages.Add(new
        {
            role = "user",
            content = prompt
        });
        
        var payload = new
        {
            model = modelIdentifier,
            messages = messages.ToArray(),
            temperature = booking.Host.Temperature,
            stream = false
        };


        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

        try
        {
            var response = await httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            JObject responseJson = JObject.Parse(responseBody);


            var text = (string)(responseJson["choices"][0]["message"]["content"]);

            return text;
        }
        catch (Exception ex)
        {
            throw new Exception($"{ErrorMessages.ErrorRequestLLM}: {ex.Message}");
        }
    }
}