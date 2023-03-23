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
        // Won't even compile
        var image = new HtmlElement("img");
        image.src = "car.jpg";
        Assert.Equal("car.jpg", image.src);
    }
}