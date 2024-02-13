using kalkulator_wydatkow.View;
namespace kalkulator_wydatkow;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainPage());
	}
}
