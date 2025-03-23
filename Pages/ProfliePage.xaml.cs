using System.Threading.Tasks;
using Project.ViewModel;

namespace Project.Pages;

public partial class ProfliePage : ContentPage
{
	public ProfliePage(ProfileViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private async void back_Button(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}