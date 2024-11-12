using SubtitleSync.Application.UseCases;
using SubtitleSync.Domain.UseCases.Parser;
using SubtitleSync.Domain.UseCases.Parser.DomainServices;
using SubtitleSync.Domain.UseCases.Parser.ResultPattern;
using SubtitleSync.Domain.UseCases.Processor;
using SubtitleSync.Domain.UseCases.Writer;

namespace SubtitleSync.Application.Tests;
public class ApplicationTests
{
    private readonly SubtitleParserSrt _subtitleParser = new(new Converter());
    private readonly SubtitleWriterSrt _subtitleWriter = new();

    [Fact]
    public async Task ParserProcessorAndWriter_WhenValidFile_ShouldCreateProcessedFile()
    {
        //Arrange
        string filePathValidSrt = @"..\..\..\..\..\SrtExamples\Valid_Inception2010.srt";
        char fractionalSeparator = ',';
        SubtitleParserRequest subtitleParserRequest = new(filePathValidSrt, fractionalSeparator);

        TimeSpan offset = TimeSpan.FromSeconds(-1);

        string pathFile = @"..\..\..\..\..\";
        string expectedFilePath = Path.Combine(pathFile, "SubtitleSync_ProcessedSubtitles.srt");

        //Act
        SubtitleParserResult subtitleParserResult = await _subtitleParser.ExecuteAsync(subtitleParserRequest);
        SubtitleParserSuccess subtitleParserSuccess = Assert.IsType<SubtitleParserSuccess>(subtitleParserResult);
        List<TimeSpan> startTimesBeforeProcessing = subtitleParserSuccess.Subtitle.Lines.Select(x => x.Duration.StartTime).ToList();
        List<TimeSpan> endTimesBeforeProcessing = subtitleParserSuccess.Subtitle.Lines.Select(x => x.Duration.EndTime).ToList();

        ApplyOffsetRequest applyOffsetRequest = new(subtitleParserSuccess.Subtitle, offset);
        SubtitleProcessor.ApplyOffset(applyOffsetRequest);
        List<TimeSpan> startTimesAfterProcessing = subtitleParserSuccess.Subtitle.Lines.Select(x => x.Duration.StartTime).ToList();
        List<TimeSpan> endTimesAfterProcessing = subtitleParserSuccess.Subtitle.Lines.Select(x => x.Duration.EndTime).ToList();

        SubtitleWriterRequest subtitleWriterRequest = new(subtitleParserSuccess.Subtitle, pathFile);
        await _subtitleWriter.ExecuteAsync(subtitleWriterRequest);

        //Assert
        Assert.True(ValidateOffset(startTimesBeforeProcessing, startTimesAfterProcessing, offset));
        Assert.True(ValidateOffset(endTimesBeforeProcessing, endTimesAfterProcessing, offset));
        Assert.True(File.Exists(expectedFilePath));
        if (File.Exists(expectedFilePath))
        {
            File.Delete(expectedFilePath);
        }
    }

    private static bool ValidateOffset(List<TimeSpan> timesBeforeProcessing, List<TimeSpan> timesAfterProcessing, TimeSpan offset)
    {
        for (int i = 0; i < timesBeforeProcessing.Count; i++)
        {
            if (timesBeforeProcessing[i] + offset != timesAfterProcessing[i])
            {
                return false;
            }
        }

        return true;
    }
}
