InterfaceBudgetManager budgetManager = new BudgetManager();
InterfaceBudgetMenu budgetMenu = new BudgetMenu();
InterfaceBudgetApp app = new BudgetApp(budgetManager, budgetMenu);

app.Run();