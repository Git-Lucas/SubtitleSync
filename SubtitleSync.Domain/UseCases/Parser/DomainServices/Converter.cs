using SubtitleSync.Domain.Entities;
using System.Globalization;

namespace SubtitleSync.Domain.UseCases.Parser.DomainServices;
public class Converter
{
    public static IEnumerable<SubtitleLine> Execute(string[] content, char fractionalSeparator)
    {
        int index = 0;
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

            yield return new SubtitleLine(number, startTime, endTime, string.Join("\n", text));
        }
    }
}
