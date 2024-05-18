using SubtitleSync.Application.UseCases;
using SubtitleSync.Domain.Entities;
using SubtitleSync.Domain.UseCases.Parser;
using SubtitleSync.Domain.UseCases.Parser.DTOs;
using System.Text.Encodings.Web;
using System.Text.Json;
using Xunit.Abstractions;

namespace SubtitleSync.Application.Tests.Integration.UseCases;
public class SubtitleParserSrtTests(ITestOutputHelper testOutputHelper)
{
    private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;
    private readonly string _filePathValidSrt = @"..\..\..\..\..\TheMatrix1999.srt";

    [Fact]
    public async Task ParseAsync_WhenValidFile_ReturnsSubtitle()
    {
        ISubtitleParser subtitleParser = new SubtitleParserSrt();
        char franceFractionalSeparator = ',';
        SubtitleParserRequest dto = new(_filePathValidSrt, franceFractionalSeparator);

        Subtitle subtitle = await subtitleParser.ExecuteAsync(dto);

        Assert.Equal(1343, subtitle.Lines.Count());
        _testOutputHelper.WriteLine(JsonSerializer.Serialize(subtitle, new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        }));
    }
}
