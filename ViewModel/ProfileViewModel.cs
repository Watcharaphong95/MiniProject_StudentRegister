using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Project.ViewModel;

public partial class ProfileViewModel : ObservableObject
{
	[ObservableProperty]
	string name = "";
	[ObservableProperty]
	string uid = "";
	[ObservableProperty]
	string gender = "";
	[ObservableProperty]
	string yearStd = "";
	[ObservableProperty]
	string depart = "";
	[ObservableProperty]
	string mail = "";
	[ObservableProperty]
	string phone = "";
	[ObservableProperty]
	string addre = "";

	[RelayCommand]
	async Task LogoutAsync()
	{
		if (Application.Current?.MainPage != null)
		{
			bool result = await Application.Current.MainPage.DisplayAlert(
		 "ออกจากระบบ?",
		 $"คุณต้องการที่จะออกระบบและกลับไปหน้าล็อคอิน?",
		 "ตกลง",
		 "ยกเลิก"
		);
			if (result)
			{

				if (Shell.Current != null)
				{
					await Shell.Current.GoToAsync("login");
				}
			}
		}
	}

	[RelayCommand]
	async Task RemoveClassPageAsync()
	{
		if (Shell.Current != null)
		{
			await Shell.Current.GoToAsync("remove");
		}
	}

	[RelayCommand]
	async Task SearchPageAsync()
	{
		if (Shell.Current != null)
		{
			await Shell.Current.GoToAsync("search");
		}
	}

	[RelayCommand]
	async Task RegisteredPageAsync()
	{
		if (Shell.Current != null)
		{
			await Shell.Current.GoToAsync("registered");
		}
	}

	void getAllData(){
		foreach (var item in _LoginModelView.Users)
		{
			if(item.Email == _LoginModelView.Username){
				Name = item.Name;
				Uid = item.Id;
				Gender = item.Gender;
				YearStd = item.Year.ToString();
				Depart = item.Department;
				Mail = item.Email;
				Phone = item.Phone;
				Addre = item.Address;
			}
		}
	}

	private readonly LoginViewModel _LoginModelView;

	public ProfileViewModel(LoginViewModel vm){
		_LoginModelView = vm;
		getAllData();
	}
}