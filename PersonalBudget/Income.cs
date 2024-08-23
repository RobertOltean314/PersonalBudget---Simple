public class Income
{
    public decimal Value { get; set; }
    public string Description { get; set; }

    public Income(decimal value, string description)
    {
        Value = value;
        Description = description;
    }
}
