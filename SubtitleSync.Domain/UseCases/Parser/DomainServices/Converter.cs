using SubtitleSync.Domain.Entities;
using SubtitleSync.Domain.UseCases.Parser.ResultPattern;

namespace SubtitleSync.Domain.UseCases.Parser.DomainServices;
public class Converter
{
    private readonly List<SubtitleLine> _subtitleLines = [];
    private readonly List<InvalidLine> _invalidLines = [];

    public SubtitleParserResult ExecuteSrt(string[] srt, char fractionalSeparator)
    {
        TryConvertLines(srt, fractionalSeparator);

        if (_invalidLines.Count > 0)
        {
            return new SubtitleParserInvalidLines(_invalidLines);
        }

        try
        {
            Subtitle subtitle = new(_subtitleLines);
            return new SubtitleParserSuccess(subtitle);
        }
        catch (Exception ex)
        {
            return new SubtitleParserInvalidSubtitle(ex.Message);
        }
    }

    private void TryConvertLines(string[] srt, char fractionalSeparator)
    {
        int line = 0;

        while (line < srt.Length)
        {
            string numberSrt = srt[line];
            line++;

            string timecodesSrt = srt[line];
            line++;

            List<string> textsSrt = [];
            while (line < srt.Length && !string.IsNullOrWhiteSpace(srt[line]))
            {
                textsSrt.Add(srt[line]);
                line++;
            }
            line++;

            try
            {
                _subtitleLines.Add(new SubtitleLine(numberSrt, timecodesSrt, fractionalSeparator, textsSrt));
            }
            catch (Exception ex)
            {
                _invalidLines.Add(new InvalidLine(numberSrt, ex.Message));
                continue;
            }
        }
    }
}
