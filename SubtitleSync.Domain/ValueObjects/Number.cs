namespace SubtitleSync.Domain.ValueObjects;
public record Number
{
    public int Value { get; private set; }

    public Number(int number)
    {
        Validate(number);

        Value = number;
    }

    private static void Validate(int number)
    {
        if (number < 1)
        {
            throw new ArgumentException($"O número {number} deve ser maior do que 0.");
        }
    }
}
