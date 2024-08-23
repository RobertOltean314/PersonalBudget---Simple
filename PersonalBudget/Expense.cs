public class Expense
{
    public decimal Value { get; set; }
    public string Description { get; set; }

    public Expense(decimal value, string description)
    {
        Value = value;
        Description = description;
    }
}
