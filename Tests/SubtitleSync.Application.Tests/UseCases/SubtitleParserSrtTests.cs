using SubtitleSync.Application.UseCases;
using SubtitleSync.Domain.Entities;
using SubtitleSync.Domain.UseCases.Parser;
using SubtitleSync.Domain.UseCases.Parser.DTOs;
using System.Text.Encodings.Web;
using System.Text.Json;
using Xunit.Abstractions;

namespace SubtitleSync.Application.Tests.UseCases;
public class SubtitleParserSrtTests(ITestOutputHelper testOutputHelper)
{
    private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;
    private readonly string _filePathValidSrt = @"..\..\..\..\..\SrtExamples\Valid_TheMatrix1999.srt";
    private readonly string _filePathInvalidSrt = @"..\..\..\..\..\SrtExamples\Invalid_TheMatrix1999.srt";
    private readonly ISubtitleParser _subtitleParser = new SubtitleParserSrt();

    [Fact]
    public async Task ParseAsync_WhenValidFile_ReturnsTypeParserSuccess()
    {
        char franceFractionalSeparator = ',';
        SubtitleParserRequest dto = new(_filePathValidSrt, franceFractionalSeparator);

        SubtitleParserResult subtitleParserResult = await _subtitleParser.ExecuteAsync(dto);

        SubtitleParserSuccess subtitleParserSuccess = Assert.IsType<SubtitleParserSuccess>(subtitleParserResult);
        Assert.Equal(1343, subtitleParserSuccess.Subtitle.Lines.Count());
        _testOutputHelper.WriteLine(JsonSerializer.Serialize(subtitleParserSuccess, new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        }));
    }

    [Fact]
    public async Task ParseAsync_WhenInvalidFile_ReturnsParserFailure()
    {
        char franceFractionalSeparator = ',';
        SubtitleParserRequest dto = new(_filePathInvalidSrt, franceFractionalSeparator);

        SubtitleParserResult subtitleParserResult = await _subtitleParser.ExecuteAsync(dto);

        SubtitleParserFailure subtitleParserFailure = Assert.IsType<SubtitleParserFailure>(subtitleParserResult);
        Assert.NotEmpty(subtitleParserFailure.Errors);
        _testOutputHelper.WriteLine(JsonSerializer.Serialize(subtitleParserFailure, new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        }));
    }
}
