using SubtitleSync.Domain.Entities;
using SubtitleSync.Domain.UseCases.Parser.ResultPattern;

namespace SubtitleSync.Domain.UseCases.Parser.DomainServices;
public class Converter
{
    public static SubtitleParserResult Execute(string[] srt, char fractionalSeparator)
    {
        int line = 0;
        List<SubtitleLine> subtitleLines = [];
        List<SubtitleParserError> errors = [];

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
                subtitleLines.Add(new SubtitleLine(numberSrt, timecodesSrt, fractionalSeparator, textsSrt));
            }
            catch (Exception ex)
            {
                errors.Add(new SubtitleParserError(numberSrt, ex.Message));
                continue;
            }
        }

        if (errors.Count > 0)
        {
            return new SubtitleParserFailure(errors);
        }

        Subtitle subtitle = new(subtitleLines);
        return new SubtitleParserSuccess(subtitle);

    }
}
