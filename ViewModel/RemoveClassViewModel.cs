using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project.Model;
using Project1.Model;

namespace Project.ViewModel;

public partial class RemoveClassViewModel : ObservableObject
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
	ObservableCollection<Registered> registers = new ObservableCollection<Registered>();
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
	async Task RegisteredPageAsync()
	{
		if (Shell.Current != null)
		{
			await Shell.Current.GoToAsync("registered");
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
		foreach (var item in dataRegister)
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
	async Task RemoveSelect(string subjectID)
	{
		string subNameAlert = "";
		subNameAlert = Registers.FirstOrDefault(c => c.SubjectId == subjectID)?.SubjectName ?? "Unknown";
		if (Application.Current?.MainPage != null)
		{
			bool result = await Application.Current.MainPage.DisplayAlert(
		 $"คุณต้องการที่จะถอนวิชานี้?",
		 $"คุณต้องการถอนวิชา: {subNameAlert} รหัสวิชา: {subjectID}",
		 "ตกลง",
		 "ยกเลิก"
		);
			if (result)
			{
				var removedItems = dataRegister.Where(item => item.SubjectId == subjectID).ToList();
				dataRegister.RemoveAll(item => item.SubjectId == subjectID);
				
				_SearchViewModel.Data.AddRange(removedItems.Select(item => new Class{
					Semester = item.Semester,
					SubjectId = item.SubjectId,
					SubjectName = item.SubjectName,
					Year = item.Year,
				}));
				YearSelect();
			}
		}
	}

	[RelayCommand]
	public void pageReload()
	{
		Registers.Clear();
		YearSelect();
	}

	void getUserData(){
		Name = _LoginViewModel.Name;
		Uid = _LoginViewModel.Uid;
		YearOfStudy = _LoginViewModel.YearOfStudy.ToString();
		Department = _LoginViewModel.Department;
	}

	private readonly RegisteredViewModel _RegisteredViewModel;
	private readonly LoginViewModel _LoginViewModel;
	private readonly SearchViewModel _SearchViewModel;

	public RemoveClassViewModel(RegisteredViewModel vm, LoginViewModel vm1, SearchViewModel vm2)
	{
		// Task.Run(LoadDataAsync);
		_RegisteredViewModel = vm;
		_LoginViewModel = vm1;
		_SearchViewModel = vm2;
		getUserData();
		dataRegister = _RegisteredViewModel.DataRegister;
		Registers = _RegisteredViewModel.Registers;
	}
}