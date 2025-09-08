// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimizer.Sample;

using System.Collections.ObjectModel;
using System.Windows;
using Sundew.Xaml.Theming;

/// <summary>
/// Interaction logic for App.xaml.
/// </summary>
public partial class App
{
    public App()
    {
        this.ThemeManager = new ThemeManager(
            new ObservableCollection<Theme>
            {
                new Theme(
                    "/Sundew.Xaml.Optimizer.Sample.Wpf;component/Themes/Forrest.xaml",
                    [
                        new Sundew.Xaml.Theming.ThemeMode("/Sundew.Xaml.Optimizer.Sample.Wpf;component/Themes/Forrest/Modes/Dark.xaml"),
                        new Sundew.Xaml.Theming.ThemeMode("/Sundew.Xaml.Optimizer.Sample.Wpf;component/Themes/Forrest/Modes/Light.xaml")
                    ]),
                new Theme(
                    "/Sundew.Xaml.Optimizer.Sample.Wpf;component/Themes/Sky.xaml",
                    [
                        new Sundew.Xaml.Theming.ThemeMode("/Sundew.Xaml.Optimizer.Sample.Wpf;component/Themes/Sky/Modes/Dark.xaml"),
                        new Sundew.Xaml.Theming.ThemeMode("/Sundew.Xaml.Optimizer.Sample.Wpf;component/Themes/Sky/Modes/Light.xaml")
                    ]),
            },
            false);
        this.InitializeComponent();

        this.ThemeManager.CurrentTheme = this.ThemeManager.Themes[0];
        this.ThemeManager.ThemeChanged += this.ThemeManager_ThemeChanged;
    }

    public ThemeManager ThemeManager { get; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
    }

    private void ThemeManager_ThemeChanged(object? sender, ThemeUpdateEventArgs e)
    {
    }
}