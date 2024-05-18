namespace SubtitleSync.Domain.Entities;
public class Subtitle
{
    public IEnumerable<SubtitleLine> Lines { get; private set; }

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
            if (!uniqueValues.Add(subtitleLine.Number))
            {
                throw new ArgumentException($"O número {subtitleLine.Number} está repetido.");
            }
        }
    }
}
