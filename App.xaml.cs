﻿using Project.Pages;

namespace Project;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		Application.Current.UserAppTheme = AppTheme.Light;
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{;
		return new Window(new AppShell());
	}
}