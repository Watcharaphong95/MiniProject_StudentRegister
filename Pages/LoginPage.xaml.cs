using System.Threading.Tasks;
using Project.ViewModel;

namespace Project.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		// if(username.Text == "1" && password.Text == "1"){
		// 	await Shell.Current.GoToAsync("search");
		// }else{
		// 	await DisplayAlert("Error", "Username or Password incorrect", "Close");
		// }
    }
}