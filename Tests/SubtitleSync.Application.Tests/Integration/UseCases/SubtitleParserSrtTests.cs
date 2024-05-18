using SubtitleSync.Application.UseCases;
using SubtitleSync.Domain.Entities;
using SubtitleSync.Domain.UseCases;
using System.Text.Encodings.Web;
using System.Text.Json;
using Xunit.Abstractions;

namespace SubtitleSync.Application.Tests.Integration.UseCases;
public class SubtitleParserSrtTests(ITestOutputHelper testOutputHelper)
{
    private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

    [Fact]
    public async Task ParseAsync_WhenValidFile_ReturnsSubtitle()
    {
        string filePath = @"..\..\..\..\..\TheMatrix1999.srt";
        ISubtitleParser subtitleParser = new SubtitleParserSrt();

        Subtitle subtitle = await subtitleParser.ExecuteAsync(filePath);

        Assert.Equal(1343, subtitle.Lines.Count());
        _testOutputHelper.WriteLine(JsonSerializer.Serialize(subtitle, new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        }));
    }
}
