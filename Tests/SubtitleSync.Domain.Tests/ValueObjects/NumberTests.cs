using SubtitleSync.Domain.ValueObjects;

namespace SubtitleSync.Domain.Tests.ValueObjects;
public class NumberTests
{
    [Fact]
    public void Number_WhenNegativeNumber_ThrowsArgumentException()
    {
        int number = -1;

        ArgumentException exception = Assert.Throws<ArgumentException>(() => new Number(number));
        Assert.Equal($"O número '{number}' deve ser maior do que 0.", exception.Message);
    }

    [Fact]
    public void Number_WhenValidNumber_ShouldSuccessfulyInstantiate()
    {
        int number = 511;

        Number valueObject = new(number);

        Assert.Equal(number, valueObject.Value);
    }
}
