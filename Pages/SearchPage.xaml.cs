using Project.ViewModel;

namespace Project.Pages;

public partial class SearchPage : ContentPage
{
	public SearchPage(SearchViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
	private void Search_Button(object sender, EventArgs e)
	{
		
	}
}