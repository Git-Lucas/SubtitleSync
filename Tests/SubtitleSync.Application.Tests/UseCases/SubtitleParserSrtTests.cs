using SubtitleSync.Application.UseCases;
using SubtitleSync.Domain.UseCases.Parser;
using SubtitleSync.Domain.UseCases.Parser.DomainServices;
using SubtitleSync.Domain.UseCases.Parser.ResultPattern;
using System.Text.Encodings.Web;
using System.Text.Json;
using Xunit.Abstractions;

namespace SubtitleSync.Application.Tests.UseCases;
public class SubtitleParserSrtTests(ITestOutputHelper testOutputHelper)
{
    private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;
    private readonly string _filePathValidSrt = @"..\..\..\..\..\SrtExamples\Valid_TheMatrix1999.srt";
    private readonly string _filePathInvalidLinesSrt = @"..\..\..\..\..\SrtExamples\InvalidLines_TheMatrix1999.srt";
    private readonly string _filePathInvalidSubtitleSrt = @"..\..\..\..\..\SrtExamples\InvalidSubtitle_Inception2010.srt";
    private readonly SubtitleParserSrt _subtitleParser = new(new Converter());

    [Fact]
    public async Task ParseAsync_WhenValidFile_ReturnsTypeParserSuccess()
    {
        char franceFractionalSeparator = ',';
        SubtitleParserRequest dto = new(_filePathValidSrt, franceFractionalSeparator);

        SubtitleParserResult subtitleParserResult = await _subtitleParser.ExecuteAsync(dto);

        SubtitleParserSuccess subtitleParserSuccess = Assert.IsType<SubtitleParserSuccess>(subtitleParserResult);
        _testOutputHelper.WriteLine(JsonSerializer.Serialize(subtitleParserSuccess, new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        }));
        Assert.Equal(1343, subtitleParserSuccess.Subtitle.Lines.Count());
    }

    [Fact]
    public async Task ParseAsync_WhenInvalidLines_ReturnsTypeParserInvalidLines()
    {
        char franceFractionalSeparator = ',';
        SubtitleParserRequest dto = new(_filePathInvalidLinesSrt, franceFractionalSeparator);

        SubtitleParserResult subtitleParserResult = await _subtitleParser.ExecuteAsync(dto);

        SubtitleParserInvalidLines invalidLines = Assert.IsType<SubtitleParserInvalidLines>(subtitleParserResult);
        _testOutputHelper.WriteLine(JsonSerializer.Serialize(invalidLines, new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        }));
        Assert.NotEmpty(invalidLines.Errors);
    }

    [Fact]
    public async Task ParseAsync_WhenInvalidSubtitle_ReturnsTypeParserInvalidSubtitle()
    {
        char franceFractionalSeparator = ',';
        SubtitleParserRequest dto = new(_filePathInvalidSubtitleSrt, franceFractionalSeparator);

        SubtitleParserResult subtitleParserResult = await _subtitleParser.ExecuteAsync(dto);

        SubtitleParserInvalidSubtitle invalidSubtitle = Assert.IsType<SubtitleParserInvalidSubtitle>(subtitleParserResult);
        _testOutputHelper.WriteLine(JsonSerializer.Serialize(invalidSubtitle, new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        }));
        Assert.NotEmpty(invalidSubtitle.Reason);
    }
}
