using System.Text;
using System.Text.Json;

namespace CareerPathRecommender.Services;

public class AiService
{
    private readonly HttpClient _client;
    private readonly AiSettings _aiSettings = new AiSettings();

public AiService(HttpClient client)
    {
        _client = client;
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_aiSettings.ApiKey}");
    }

    public async Task<string> GetJobSkillsAsync(string jobTitle, string experience)
    {
        var requestBody = new
        {
            model = _aiSettings.Model,
            messages = new[]
            {
                new { role = "system", content = _aiSettings.SystemContent  },
                new { role = "user", content = $"What are the top EXACTLY 13 skills required for a {experience} {jobTitle} role? WITHOUT ANY MORE WORDS OR INTRODUCTION!!" }
            }
        };

        string jsonContent = JsonSerializer.Serialize(requestBody);
        HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _client.PostAsync(_aiSettings.ApiUrl, content);

        if (response.IsSuccessStatusCode)
        {
            string responseString = await response.Content.ReadAsStringAsync();
            return ParseResponse(responseString);
        }
        return "Error retrieving skills (API Key or request).";
    }

    private static string ParseResponse(string responseJson)
    {
        using JsonDocument doc = JsonDocument.Parse(responseJson);
        var root = doc.RootElement;
        var choices = root.GetProperty("choices");

        if (choices.GetArrayLength() > 0)
        {
            return choices[0].GetProperty("message").GetProperty("content").GetString() ?? "";
        }
        return "";
    }
}
