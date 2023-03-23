using System.Dynamic;
using System.Text;

namespace ConsoleApp;

public class HtmlElement : DynamicObject
{
    private readonly Dictionary<string, object?> _attributes = new();
    public string TagName { get; set; }

    public HtmlElement(string tagName)
    {
        TagName = tagName;
    }

    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        string attribute = binder.Name;
        _attributes[attribute] = value;

        return true;
    }

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        string attribute = binder.Name;
        result = _attributes[attribute];

        return true;
    }

    public override IEnumerable<string> GetDynamicMemberNames()
    {
        return _attributes.Keys.ToArray();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"<{TagName}");
        
        foreach (var attribute in _attributes)
        {
            sb.Append($" {attribute.Key}=\"{attribute.Value}\"");
        }
        
        sb.Append(" />");

        return sb.ToString();
    }
}