using SubtitleSync.Domain.ValueObjects;

namespace SubtitleSync.Domain.Tests.Unit.ValueObjects;
public class DurationTests
{
    [Fact]
    public void Duration_WhenInvalidTimes_ShouldArgumentException()
    {
        TimeSpan endTime = TimeSpan.FromSeconds(1);
        TimeSpan invalidStartTime = endTime.Add(TimeSpan.FromSeconds(1));

        ArgumentException exception = Assert.Throws<ArgumentException>(() => new Duration(startTime: invalidStartTime, endTime));
        Assert.Equal($"O tempo de início não pode ser maior do que o tempo final. Tempo de início: {invalidStartTime} | Tempo final: {endTime}",
                     exception.Message);
    }
}
