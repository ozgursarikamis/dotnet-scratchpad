namespace ConsoleApp.Tests;

public class HtmlElementTests
{
    [Fact]
    public void ShouldStoreTagName()
    {
        var image = new HtmlElement("img");
        Assert.Equal("img", image.TagName);
    }
}