namespace ConsoleApp.Tests;

public class HtmlElementTests
{
    [Fact]
    public void ShouldStoreTagName()
    {
        var image = new HtmlElement("img");
        Assert.Equal("img", image.TagName);
    }

    [Fact]
    public void ShouldAddAttributeNameAndValueDynamically()
    {
        dynamic image = new HtmlElement("img");
        image.src = "car.jpg";
        Assert.Equal("car.jpg", image.src);
    }
    
    [Fact]
    public void ShouldReturnDynamicMemberNames()
    {
        dynamic image = new HtmlElement("img");
        image.src = "car.jpg";
        image.alt = "Car";

        string[] members = image.GetDynamicMemberNames();
        Assert.Equal("src", members[0]);
        Assert.Equal("alt", members[1]);
        
        // or:
        Assert.Equal(new[] {"src", "alt"}, members);
    }

    [Fact]
    public void ShouldOutputTagHtml()
    {
        dynamic image = new HtmlElement("img");
        image.src = "car.jpg";
        image.alt = "Car";

        var html = image.ToString();
        
        Assert.Equal("<img src=\"car.jpg\" alt=\"Car\" />", html);
    }

    [Fact]
    public void ShouldBeCastableToDictionary()
    {
        dynamic image = new HtmlElement("img");
        IDictionary<string, object> attributes =
            (IDictionary<string, object>)image;
        
        attributes["src"] =  "car.jpg";
        
        Assert.Equal("car.jpg", image.src);
    }

    [Fact]
    public void ShouldBeEnumerable()
    {
        dynamic image = new HtmlElement("img");
        image.src = "car.jpg";

        foreach (var attribute in (IDictionary<string, object>)image)
        {
            var x = attribute;
        }
    }
}