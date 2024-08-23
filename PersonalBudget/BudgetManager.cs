public interface InterfaceBudgetManager
{
    void AddIncome(decimal value, string description);
    void AddExpense(decimal value, string description);
    string ShowBalance();
    string GetIncomeSummary();
    string GetExpenseSummary();
}

public class BudgetManager : InterfaceBudgetManager
{
    private readonly List<Income> incomes;
    private readonly List<Expense> expenses;
    private decimal balance;

    public BudgetManager()
    {
        incomes = new List<Income>();
        expenses = new List<Expense>();
        balance = 0;
    }

    public decimal Balance => balance;

    public void AddIncome(decimal value, string description)
    {
        var income = new Income(value, description);
        incomes.Add(income);
        balance += income.Value;
    }

    public void AddExpense(decimal value, string description)
    {
        var expense = new Expense(value, description);
        expenses.Add(expense);
        balance -= expense.Value;
    }

    public string ShowBalance() => $"Your balance is {balance:C}";

    public string GetIncomeSummary()
    {
        var summary = new System.Text.StringBuilder("Income Summary:\n");
        foreach (var income in incomes)
        {
            summary.AppendLine($"- {income.Description}: {income.Value:C}");
        }
        return summary.ToString();
    }

    public string GetExpenseSummary()
    {
        var summary = new System.Text.StringBuilder("Expense Summary:\n");
        foreach (var expense in expenses)
        {
            summary.AppendLine($"- {expense.Description}: {expense.Value:C}");
        }
        return summary.ToString();
    }
}
