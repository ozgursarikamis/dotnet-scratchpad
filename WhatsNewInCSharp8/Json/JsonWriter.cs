using System.Buffers;
using System.Text;
using System.Text.Json;

namespace WhatsNewInCSharp8.Json;

public static class JsonWriter
{
    public static void Run()
    {
        var options = new JsonWriterOptions
        {
            Indented = true
        };
        var buffer = new ArrayBufferWriter<byte>();
        using var json = new Utf8JsonWriter(buffer, options);
        
        PopulateJson(json);
        json.Flush();

        var output = buffer.WrittenSpan.ToArray();
        var jsonStr = Encoding.UTF8.GetString(output);
        WriteLine(jsonStr);
    }

    private static void PopulateJson(Utf8JsonWriter writer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("courseName");

        writer.WriteStringValue("Build Your Own Application Framework");
        writer.WriteString("language", "C#");
        
        writer.WriteStartObject("author");
        writer.WriteString("firstName", "John");
        writer.WriteString("middleName", "Smith");
        writer.WriteString("lastName", "Doe");
        
        writer.WriteEndObject();
    }
}