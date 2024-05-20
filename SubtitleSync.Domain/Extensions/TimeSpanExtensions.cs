namespace SubtitleSync.Domain.Extensions;
public static class TimeSpanExtensions
{
    public static string ToFormatSrt(this TimeSpan time)
    {
        return $"{time.Hours:D2}:{time.Minutes:D2}:{time.Seconds:D2},{time.Milliseconds:D3}";
    }
}
