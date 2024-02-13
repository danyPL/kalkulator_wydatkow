using kalkulator_wydatkow.ViewModel;
using kalkulator_wydatkow.Scripts;
namespace kalkulator_wydatkow.View;

public partial class AllExpenses : ContentPage
{
	AllExpensesViewModel viewModel;
	public AllExpenses()
	{
		InitializeComponent();
		viewModel = new AllExpensesViewModel();
		BindingContext = viewModel;
	}
}