using Project.ViewModel;

namespace Project.Pages;

public partial class RegisteredPage : ContentPage
{
	public RegisteredPage(RegisteredViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
	private void Picker_SelectedIndexChanged(object sender, EventArgs e)
	{
		var vm = BindingContext as RegisteredViewModel;
		vm?.YearSelectCommand.Execute(null);
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		if (BindingContext is RegisteredViewModel vm)
		{
			vm?.pageReloadCommand.Execute(null);
		}
	}
}