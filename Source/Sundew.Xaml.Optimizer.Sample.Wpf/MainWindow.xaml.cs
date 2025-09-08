// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimizer.Sample;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using Sundew.Xaml.Theming;

/// <summary>
/// Interaction logic for MainWindow.xaml.
/// </summary>
public partial class MainWindow : INotifyPropertyChanged
{
    public MainWindow()
    {
        this.DataContext = this;
        this.ThemeManager.ThemeChanged += this.ThemeManager_ThemeChanged;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public ThemeManager ThemeManager => ((App)App.Current).ThemeManager;

    public List<ResourceDictionaryInfo> ResourceDictionaries
    {
        get
        {
            var list = new List<ResourceDictionaryInfo>();
            var dictionary =
                (((IEnumerable?)typeof(Sundew.Xaml.Optimizations.ResourceDictionary).GetProperty("ResourceDictionaries", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy)?.GetValue(null))?.Cast<object>() ?? new List<object>())
                .Concat(
                    ((IEnumerable?)typeof(ThemeResourceDictionary).GetProperty("ResourceDictionaries", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy)?.GetValue(null))?.Cast<object>() ?? new List<object>())
                .Concat(
                    ((IEnumerable?)typeof(ThemeModeResourceDictionary).GetProperty("ResourceDictionaries", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy)?.GetValue(null))?.Cast<object>() ?? new List<object>());
            if (dictionary == null)
            {
                return list;
            }

            foreach (var o in dictionary)
            {
                var value = o.GetType().GetProperty("Value")?.GetValue(o);
                var key = (Uri?)o?.GetType().GetProperty("Key")?.GetValue(o);
                var references = (int?)value?.GetType().GetProperty(
                                     "ReferenceCount",
                                     BindingFlags.Instance | BindingFlags.Public)?
                                     .GetValue(value);
                if (key != null && references.HasValue)
                {
                    list.Add(new ResourceDictionaryInfo(key, references.Value));
                }
            }

            return list;
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void ThemeManager_ThemeChanged(object? sender, ThemeUpdateEventArgs e)
    {
        this.OnPropertyChanged(nameof(this.ResourceDictionaries));
    }

    private void CloseOnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void MinimizeOnClick(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    public class ResourceDictionaryInfo
    {
        public ResourceDictionaryInfo(Uri uri, int references)
        {
            this.Uri = uri;
            this.References = references;
        }

        public Uri Uri { get; }

        public int References { get; }
    }
}
