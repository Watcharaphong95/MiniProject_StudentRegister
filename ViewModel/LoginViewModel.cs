using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project2.Model;

namespace Project.ViewModel;

public partial class LoginViewModel : ObservableObject
{
	[ObservableProperty]
	private UsersData userData;

	[ObservableProperty]
	string name = "";

	[ObservableProperty]
	string uid = "";

	[ObservableProperty]
	string yearOfStudy = "";

	[ObservableProperty]
	string department = "";

	[ObservableProperty]
	List<UsersData> allUser = [];

	[ObservableProperty]
	string username = "";
	[ObservableProperty]
	string password = "";

	[RelayCommand]
	async Task Login()
	{
		foreach (var item in Users)
		{
			if (item.Email == Username)
			{
				if (item.Password == Password)
				{
					if (Shell.Current != null)
					{
						getUser();
						getUserData();
						await Shell.Current.GoToAsync("search");
						break;
					}
				}
				else
				{
					await Application.Current.MainPage.DisplayAlert(
		 "กรุณาลองใหม่อีกครั้ง?",
		 $"รหัสผ่านไม่ถูกต้อง",
		 "ตกลง");
					break;
				}
			}
			else
			{
				await Application.Current.MainPage.DisplayAlert(
		 "กรุณาลองใหม่อีกครั้ง?",
		 $"อีเมลนี้ไม่มีอยู่ในระบบ",
		 "ตกลง");
				break;
			}
		}
	}

	[ObservableProperty]
	ObservableCollection<UsersData> users = new ObservableCollection<UsersData>();
	async Task<List<UsersData>> ReadJsonAsync()
	{
		try
		{
			using var stream = await FileSystem.OpenAppPackageFileAsync("users.json");
			using var reader = new StreamReader(stream);
			var contents = await reader.ReadToEndAsync();
			List<UsersData> users = UsersData.FromJson(contents);
			AllUser = users;
			return users;
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine(ex.Message);
			return new List<UsersData>();
		}
	}

	void getUser()
	{
		foreach (var item in AllUser)
		{
			if (item.Email == Username)
			{
				UserData = item;
			}
		}
	}

	void getUserData()
	{
		Name = UserData.Name;
		Uid = UserData.Id;
		YearOfStudy = UserData.Year.ToString();
		Department = UserData.Department;
	}

	async Task LoadDataAsync()
	{
		var jsonClasses = await ReadJsonAsync();
		Users = new ObservableCollection<UsersData>(jsonClasses);
	}

	public LoginViewModel()
	{
		Task.Run(LoadDataAsync);
	}
}