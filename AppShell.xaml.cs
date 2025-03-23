using Project.Pages;

namespace Project;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("profile", typeof(ProfliePage));
		Routing.RegisterRoute("search", typeof(SearchPage));
		Routing.RegisterRoute("login", typeof(LoginPage));
		Routing.RegisterRoute("registered", typeof(RegisteredPage));
		Routing.RegisterRoute("remove", typeof(RemoveClassPage));
	}
}
