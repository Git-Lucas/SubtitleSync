namespace SubtitleSync.Domain.ValueObjects;
public record Number
{
    public int Value { get; private set; }

    public Number(int number)
    {
        Validate(number);

        Value = number;
    }

    public static Number CreateFromSrt(string numberFromSrt)
    {
        if (int.TryParse(numberFromSrt, out int number))
        {
            return new Number(number);
        }

        throw new ArgumentException($"O número '{numberFromSrt}' está inválido.");
    }

    private static void Validate(int number)
    {
        if (number < 1)
        {
            throw new ArgumentException($"O número '{number}' deve ser maior do que 0.");
        }
    }
}
