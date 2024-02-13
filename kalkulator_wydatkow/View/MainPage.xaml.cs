using kalkulator_wydatkow.Model;
using kalkulator_wydatkow.Scripts;

namespace kalkulator_wydatkow.View;

public partial class MainPage : ContentPage
{
	int count = 0;
	DataManagement data = new DataManagement();
	public MainPage()
	{
		InitializeComponent();
	}

	public void AddExpenseBtn(object sender, EventArgs e)
	{
		string name = expenseName.Text;
		DateTime dateTime = DateTime.Parse(expenseDate.Date.ToString());
		double price = Convert.ToDouble(expensePrice.Text);
		string category = expenseCategory.SelectedItem.ToString();
		if(data.PushExpense(name, price,dateTime, category))
		{
			DisplayAlert("Dodano", "Wydatek został dodany!", "ok");
		}
		else
		{
			DisplayAlert("Nie dodano!", "Wystąpił błąd","ok");
		}
	}

	public async void GoToAll(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AllExpenses());
	}
	public async void GoToCalc(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new CalcExpenses());
	}
}

