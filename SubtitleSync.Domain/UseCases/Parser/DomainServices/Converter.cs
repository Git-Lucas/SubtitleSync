using SubtitleSync.Domain.Entities;
using SubtitleSync.Domain.UseCases.Parser.DTOs;
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
            if (!int.TryParse(content[index], out int number))
            {
                index++;
                continue;
            }
            index++;

            var timeParts = content[index].Split(" --> ");
            var startTime = TimeSpan.ParseExact(timeParts[0], @$"hh\:mm\:ss\{fractionalSeparator}fff", CultureInfo.InvariantCulture);
            var endTime = TimeSpan.ParseExact(timeParts[1], @$"hh\:mm\:ss\{fractionalSeparator}fff", CultureInfo.InvariantCulture);
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
                lines.Add(new SubtitleLine(number, startTime, endTime, string.Join("\n", text)));
            }
            catch (Exception ex)
            {
                errors.Add(new SubtitleParserError(number, ex.Message));
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
