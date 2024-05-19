using System.Text;

namespace SubtitleSync.Domain.Entities;
public class Subtitle
{
    public IEnumerable<SubtitleLine> Lines { get; private set; }

    private int _minValue;

    public Subtitle(IEnumerable<SubtitleLine> lines)
    {
        Validate(lines);

        Lines = lines;
    }

    private void Validate(IEnumerable<SubtitleLine> lines)
    {
        HashSet<int> uniqueValues = [];
        foreach (SubtitleLine subtitleLine in lines)
        {
            if (!uniqueValues.Add(subtitleLine.Number.Value))
            {
                throw new ArgumentException($"O número {subtitleLine.Number.Value} está repetido.");
            }
        }

        SetMinValue(uniqueValues);
    }

    private void SetMinValue(HashSet<int> uniqueValues)
    {
        _minValue = uniqueValues.Min();
    }

    public void ApplyOffset(TimeSpan offset)
    {
        SubtitleLine firstLine = Lines.First(x => x.Number.Value == _minValue);
        if (firstLine.Duration.StartTime.Add(offset) < TimeSpan.Zero)
        {
            throw new ArgumentException(
                "A aplicação do deslocamento temporal não pode provocar um tempo de início menor que 0. " +
                $"Tempo inicial das legendas: {firstLine.Duration.StartTime} | Deslocamento temporal solicitado: {offset}");
        }

        Lines
            .ToList()
            .ForEach(subtitleLine => subtitleLine.Duration.ApplyOffset(offset));
    }

    public string ToSrt()
    {
        StringBuilder stringBuilder = new();

        foreach (SubtitleLine line in Lines)
        {
            stringBuilder.AppendLine(line.Number.Value.ToString());
            stringBuilder.AppendLine(line.Duration.ToFormatStr());
            stringBuilder.AppendLine(line.Text);
            stringBuilder.AppendLine();
        }

        return stringBuilder.ToString();
    }
}
