public interface InterfaceBudgetMenu
{
    void DisplayMenu();
}

public class BudgetMenu : InterfaceBudgetMenu
{
    public void DisplayMenu()
    {
        Console.WriteLine("Hello, this is your Personal Budget Application!!!");

        Console.WriteLine();
        Console.WriteLine("What do you want to do?: ");
        Console.WriteLine();
        Console.WriteLine("[A]dd an income");
        Console.WriteLine("[S]ubtract an expense");
        Console.WriteLine("[C]heck balance");
        Console.WriteLine("[I]ncome summary");
        Console.WriteLine("[E]xpense summary");
        Console.WriteLine("[X] Exit");
    }
}
