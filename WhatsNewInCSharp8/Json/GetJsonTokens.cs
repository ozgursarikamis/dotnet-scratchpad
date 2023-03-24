using System.Text.Json;

namespace WhatsNewInCSharp8.Json;

public static class GetJsonTokens
{
    public static void Run()
    {
        var jsonBytes = File.ReadAllBytes("./Json/sample.json");
        var jsonSpan = jsonBytes.AsSpan();
        var json = new Utf8JsonReader(jsonSpan);

        while (json.Read())
        {
            WriteLine(GetTokenDesc(json));
        }
    }

    private static string GetTokenDesc(Utf8JsonReader json) => json.TokenType switch
    {
        JsonTokenType.StartObject => "Start Object",
        JsonTokenType.EndObject => "End Object",
        JsonTokenType.StartArray => "Start Array",
        JsonTokenType.EndArray => "End Array",
        JsonTokenType.PropertyName => $"Property {json.GetString()}",
        JsonTokenType.String => "String",
        JsonTokenType.Comment => $"Comment {json.GetString()}",
        JsonTokenType.Number => $"Number {json.GetInt32()}",
        JsonTokenType.True => $"True {json.GetBoolean()}",
        JsonTokenType.False => $"False {json.GetBoolean()}",
        JsonTokenType.Null => "NULL",
        _ => $"Unknown {json.TokenType}"
    };
}