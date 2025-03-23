using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project.Model;
using Project1.Model;
using Project2.Model;
using Windows.System;

namespace Project.ViewModel;

public partial class SearchViewModel : ObservableObject
{
	[ObservableProperty]
	List<Class> data = [];

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

	[ObservableProperty]
	bool subName = true;

	[ObservableProperty]
	bool term1 = false;

	[ObservableProperty]
	bool term2 = false;

	[ObservableProperty]
	bool term3 = false;

	[ObservableProperty]
	bool year1 = false;

	[ObservableProperty]
	bool year2 = false;

	[ObservableProperty]
	bool year3 = false;

	[ObservableProperty]
	bool year4 = false;

	[ObservableProperty]
	string search = "";

	[ObservableProperty]
	ObservableCollection<Class> classes = new ObservableCollection<Class>();
	async Task<List<Class>> ReadJsonAsync()
	{
		try
		{
			using var stream = await FileSystem.OpenAppPackageFileAsync("classes.json");
			using var reader = new StreamReader(stream);
			var contents = await reader.ReadToEndAsync();
			List<Class> classes = Class.FromJson(contents);
			Data = classes;
			return classes;
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine(ex.Message);
			return new List<Class>();
		}
	}

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
	async Task RemoveClassPageAsync()
	{
		if (Shell.Current != null)
		{
			await Shell.Current.GoToAsync("remove");
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

	[RelayCommand]
	public void SearchName()
	{
		Classes.Clear();
		if (SubName)
		{
			if (Year1)
			{
				if (Term1)
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Year == "1" && item.Semester == "1")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term2)
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Year == "1" && item.Semester == "2")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term3)
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Year == "1" && item.Semester == "3")
						{
							Classes.Add(item);
						}
					}
				}
				else
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Year == "1")
						{
							Classes.Add(item);
						}
					}
				}
			}
			else if (Year2)
			{
				if (Term1)
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Year == "2" && item.Semester == "1")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term2)
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Year == "2" && item.Semester == "2")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term3)
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Year == "2" && item.Semester == "3")
						{
							Classes.Add(item);
						}
					}
				}
				else
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Year == "2")
						{
							Classes.Add(item);
						}
					}
				}
			}
			else if (Year3)
			{
				if (Term1)
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Year == "3" && item.Semester == "1")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term2)
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Year == "3" && item.Semester == "2")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term3)
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Year == "3" && item.Semester == "3")
						{
							Classes.Add(item);
						}
					}
				}
				else
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Year == "3")
						{
							Classes.Add(item);
						}
					}
				}
			}
			else if (Year4)
			{
				if (Term1)
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Year == "4" && item.Semester == "1")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term2)
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Year == "4" && item.Semester == "2")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term3)
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Year == "4" && item.Semester == "3")
						{
							Classes.Add(item);
						}
					}
				}
				else
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Year == "4")
						{
							Classes.Add(item);
						}
					}
				}
			}
			else
			{
				if (Term1)
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Semester == "1")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term2)
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Semester == "2")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term3)
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search) && item.Semester == "3")
						{
							Classes.Add(item);
						}
					}
				}
				else
				{
					foreach (var item in data)
					{
						if (item.SubjectName.Contains(Search))
						{
							Classes.Add(item);
						}
					}
				}
			}

		}
		// SubjectID Search!!!!!!!!!!!!!!!
		else
		{
			if (Year1)
			{
				if (Term1)
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Year == "1" && item.Semester == "1")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term2)
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Year == "1" && item.Semester == "2")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term3)
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Year == "1" && item.Semester == "3")
						{
							Classes.Add(item);
						}
					}
				}
				else
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Year == "1")
						{
							Classes.Add(item);
						}
					}
				}
			}
			else if (Year2)
			{
				if (Term1)
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Year == "2" && item.Semester == "1")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term2)
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Year == "2" && item.Semester == "2")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term3)
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Year == "2" && item.Semester == "3")
						{
							Classes.Add(item);
						}
					}
				}
				else
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Year == "2")
						{
							Classes.Add(item);
						}
					}
				}
			}
			else if (Year3)
			{
				if (Term1)
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Year == "3" && item.Semester == "1")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term2)
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Year == "3" && item.Semester == "2")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term3)
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Year == "3" && item.Semester == "3")
						{
							Classes.Add(item);
						}
					}
				}
				else
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Year == "3")
						{
							Classes.Add(item);
						}
					}
				}
			}
			else if (Year4)
			{
				if (Term1)
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Year == "4" && item.Semester == "1")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term2)
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Year == "4" && item.Semester == "2")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term3)
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Year == "4" && item.Semester == "3")
						{
							Classes.Add(item);
						}
					}
				}
				else
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Year == "4")
						{
							Classes.Add(item);
						}
					}
				}
			}
			else
			{
				if (Term1)
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Semester == "1")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term2)
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Semester == "2")
						{
							Classes.Add(item);
						}
					}
				}
				else if (Term3)
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search) && item.Semester == "3")
						{
							Classes.Add(item);
						}
					}
				}
				else
				{
					foreach (var item in data)
					{
						if (item.SubjectId.Contains(Search))
						{
							Classes.Add(item);
						}
					}
				}
			}
		}
	}

	[RelayCommand]
	async Task ClassSelectAsync(string subjectID)
	{
		string subNameAlert = "";
		subNameAlert = Classes.FirstOrDefault(c => c.SubjectId == subjectID)?.SubjectName ?? "Unknown";
		if (Application.Current?.MainPage != null)
		{
			bool result = await Application.Current.MainPage.DisplayAlert(
		 "ลงทะเบียนวิชานี้?",
		 $"คุณต้องการลงทะเบียนวิชา: {subNameAlert}\nรหัสวิชา: {subjectID}",
		 "ตกลง",
		 "ยกเลิก"
		);
			if (result)
			{
				var removedItems = Data.Where(item => item.SubjectId == subjectID).ToList();
				Data.RemoveAll(item => item.SubjectId == subjectID);

				DataRegister.AddRange(removedItems.Select(item => new Registered
				{
					Semester = item.Semester,
					Year = item.Year,
					SubjectName = item.SubjectName,
					SubjectId = item.SubjectId,
					Grade = null
				}));
				SearchName();
			}
		}
	}

	async Task LoadDataAsync()
	{
		var jsonClasses = await ReadJsonAsync();
		Classes = new ObservableCollection<Class>(jsonClasses);
	}

	void getUserData(){
		Name = _LoginViewModel.Name;
		Uid = _LoginViewModel.Uid;
		YearOfStudy = _LoginViewModel.YearOfStudy.ToString();
		Department = _LoginViewModel.Department;
	}

	private readonly LoginViewModel _LoginViewModel;

	public SearchViewModel(LoginViewModel vm)
	{
		Task.Run(LoadDataAsync);
		_LoginViewModel = vm;
		getUserData();
	}
}


