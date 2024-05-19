using SubtitleSync.Domain.Entities;
using SubtitleSync.Domain.UseCases.Parser;
using SubtitleSync.Domain.UseCases.Parser.DomainServices;
using SubtitleSync.Domain.UseCases.Parser.DTOs;
using SubtitleSync.Domain.UseCases.Parser.ResultPattern;

namespace SubtitleSync.Application.UseCases;
public class SubtitleParserSrt : ISubtitleParser
{
    public async Task<SubtitleParserResult> ExecuteAsync(SubtitleParserRequest dto)
    {
        dto.Validate();

        string[] content = await File.ReadAllLinesAsync(dto.FilePath);
        SubtitleParserResult subtitleParserResult = Converter.Execute(content, dto.FractionalSeparator);

        return subtitleParserResult;
    }
}
