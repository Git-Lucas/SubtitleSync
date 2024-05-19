using SubtitleSync.Domain.Entities;
using SubtitleSync.Domain.UseCases.Parser.ResultPattern;
using SubtitleSync.Domain.ValueObjects;
using System.Globalization;

namespace SubtitleSync.Domain.UseCases.Parser.DomainServices;
public class Converter
{
    public static SubtitleParserResult Execute(string[] content, char fractionalSeparator)
    {
        int index = 0;
        List<SubtitleLine> lines = [];
        List<SubtitleParserError> errors = [];

        while (index < content.Length)
        {
            string numberSrt = content[index];
            index++;

            string timecodesSrt = content[index];
            index++;

            var text = new List<string>();
            while (index < content.Length && !string.IsNullOrWhiteSpace(content[index]))
            {
                text.Add(content[index]);
                index++;
            }
            index++;

            try
            {
                lines.Add(new SubtitleLine(numberSrt, timecodesSrt, fractionalSeparator, string.Join("\n", text)));
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

        Subtitle subtitle = new(lines);
        return new SubtitleParserSuccess(subtitle);

    }
}
