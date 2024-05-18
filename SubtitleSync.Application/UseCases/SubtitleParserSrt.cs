using SubtitleSync.Domain.Entities;
using SubtitleSync.Domain.UseCases.Parser;
using SubtitleSync.Domain.UseCases.Parser.DomainServices;
using SubtitleSync.Domain.UseCases.Parser.DTOs;

namespace SubtitleSync.Application.UseCases;
public class SubtitleParserSrt : ISubtitleParser
{
    public async Task<Subtitle> ExecuteAsync(SubtitleParserRequest dto)
    {
        dto.Validate();

        string[] content = await File.ReadAllLinesAsync(dto.FilePath);
        IEnumerable<SubtitleLine> subtitleLines = Converter.Execute(content, dto.FractionalSeparator);

        return new Subtitle(subtitleLines);
    }
}
