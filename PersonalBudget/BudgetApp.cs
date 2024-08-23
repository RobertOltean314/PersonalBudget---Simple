public interface InterfaceBudgetApp
{
    void Run();
}

public class BudgetApp : InterfaceBudgetApp
{
    private readonly InterfaceBudgetManager budgetManager;
    private readonly InterfaceBudgetMenu budgetMenu;

    public BudgetApp(InterfaceBudgetManager budgetManager, InterfaceBudgetMenu budgetMenu)
    {
        this.budgetManager = budgetManager;
        this.budgetMenu = budgetMenu;
    }

    public void Run()
    {
        string state;
        do
        {
            budgetMenu.DisplayMenu();
            state = Console.ReadLine()?.Trim().ToUpper();
            ProcessUserInput(state);
        } while (state != "X");
    }

    private void ProcessUserInput(string state)
    {
        switch (state)
        {
            case "A":
                AddTransaction(isIncome: true);
                break;

            case "S":
                AddTransaction(isIncome: false);
                break;

            case "C":
                Console.WriteLine(budgetManager.ShowBalance());
                break;

            case "I":
                Console.WriteLine(budgetManager.GetIncomeSummary());
                break;

            case "E":
                Console.WriteLine(budgetManager.GetExpenseSummary());
                break;

            case "X":
                Console.WriteLine("Exiting the application. Goodbye!");
                break;

            default:
                Console.WriteLine("Invalid choice. Please enter a valid choice.");
                break;
        }
        Console.WriteLine();
    }

    private void AddTransaction(bool isIncome)
    {
        string type = isIncome ? "income" : "expense";
        Console.WriteLine($"Please enter your {type} using this format: value, description");
        string input = Console.ReadLine();

        if (TryParseTransaction(input, out decimal value, out string description))
        {
            if (isIncome)
                budgetManager.AddIncome(value, description);
            else
                budgetManager.AddExpense(value, description);

            Console.WriteLine($"{char.ToUpper(type[0]) + type.Substring(1)} added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please use the correct format.");
        }
    }

    private bool TryParseTransaction(string input, out decimal value, out string description)
    {
        value = 0;
        description = null;
        var parts = input.Split(',');

        if (parts.Length == 2 && decimal.TryParse(parts[0].Trim(), out value))
        {
            description = parts[1].Trim();
            return true;
        }
        return false;
    }
}
