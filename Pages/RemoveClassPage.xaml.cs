using Project.ViewModel;

namespace Project.Pages;

public partial class RemoveClassPage : ContentPage
{
	public RemoveClassPage(RemoveClassViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	private void Picker_SelectedIndexChanged(object sender, EventArgs e)
	{
		var vm = BindingContext as RemoveClassViewModel;
		vm?.YearSelectCommand.Execute(null);
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		if (BindingContext is RemoveClassViewModel vm)
		{
			vm?.pageReloadCommand.Execute(null);
		}
	}
}