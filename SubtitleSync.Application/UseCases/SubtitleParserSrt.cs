using SubtitleSync.Domain.Entities;
using SubtitleSync.Domain.UseCases;
using System.Globalization;

namespace SubtitleSync.Application.UseCases;
public class SubtitleParserSrt : ISubtitleParser
{
    public async Task<Subtitle> ExecuteAsync(string filePath)
    {
        string fileExtension = Path.GetExtension(filePath);
        if (fileExtension != ".srt")
        {
            throw new Exception($"A extensão do arquivo deve ser '.srt'. Extensão do arquivo selecionado: {fileExtension}");
        }

        string[] content = await File.ReadAllLinesAsync(filePath);

        IEnumerable<SubtitleLine> subtitleLines = ConvertToSubtitleLines(content);

        return new Subtitle(subtitleLines);
    }

    private IEnumerable<SubtitleLine> ConvertToSubtitleLines(string[] content)
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
            var startTime = TimeSpan.ParseExact(timeParts[0], @"hh\:mm\:ss\,fff", CultureInfo.InvariantCulture);
            var endTime = TimeSpan.ParseExact(timeParts[1], @"hh\:mm\:ss\,fff", CultureInfo.InvariantCulture);
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
