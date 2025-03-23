using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project.Model;
using Project1.Model;

namespace Project.ViewModel;

public partial class RegisteredViewModel : ObservableObject
{
	[ObservableProperty]
	string name = "";

	[ObservableProperty]
	string uid = "";

	[ObservableProperty]
	string yearOfStudy = "";

	[ObservableProperty]
	string department = "";


	[ObservableProperty]
	List<Registered> dataRegister = [];

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
	async Task ProfilePageAsync()
	{
		if (Shell.Current != null)
		{
			await Shell.Current.GoToAsync("profile");
		}
	}

	[ObservableProperty]
	string year = "1";

	[ObservableProperty]
	string semester = "1";

	[RelayCommand]
	public void YearSelect()
	{
		Registers.Clear();
		foreach (var item in DataRegister)
		{
			if (item.Semester.ToString() == Semester && item.Year.ToString() == Year)
			{
				if (!Registers.Contains(item))
				{
					Registers.Add(item);
				}
			}
		}
	}

	[RelayCommand]
	public void pageReload()
	{
		Registers.Clear();
		YearSelect();
	}

	[ObservableProperty]
	ObservableCollection<Registered> registers = new ObservableCollection<Registered>();
	async Task<List<Registered>> ReadJsonAsync()
	{
		try
		{
			using var stream = await FileSystem.OpenAppPackageFileAsync("register.json");
			using var reader = new StreamReader(stream);
			var contents = await reader.ReadToEndAsync();
			List<Registered> registers = Registered.FromJson(contents);
			foreach (var item in registers)
			{
				DataRegister.Add(item);
			}
			DataRegister.Sort((x, y) => string.Compare(x.SubjectId, y.SubjectId, StringComparison.Ordinal));
			YearSelect();
			return registers;
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine(ex.Message);
			return new List<Registered>();
		}
	}

	void getUserData(){
		Name = _LoginViewModel.Name;
		Uid = _LoginViewModel.Uid;
		YearOfStudy = _LoginViewModel.YearOfStudy.ToString();
		Department = _LoginViewModel.Department;
	}

	async Task LoadDataAsync()
	{
		var jsonClasses = await ReadJsonAsync();
		Registers = new ObservableCollection<Registered>(jsonClasses);
	}

	private readonly SearchViewModel _SearchModelView;
	private readonly LoginViewModel _LoginViewModel;

	public RegisteredViewModel(SearchViewModel vm, LoginViewModel vm1)
	{
		Task.Run(LoadDataAsync);
		// YearSelect();
		_SearchModelView = vm;
		_LoginViewModel = vm1;
		getUserData();
		DataRegister = _SearchModelView.DataRegister;
	}
}