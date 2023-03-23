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
        // Assert.Equal(new[] {"src", "alt"}, members);
        Assert.Equal("src", members[0]);
        Assert.Equal("alt", members[1]);
    }
}