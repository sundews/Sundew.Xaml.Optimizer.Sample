// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Hukano">
// Copyright (c) Hukano. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimizer.Sample
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using Sundew.Xaml.Theming;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            this.DataContext = this;
        }

        public ThemeManager ThemeManager => ((App)App.Current).ThemeManager;

        public List<ResourceDictionaryInfo> ResourceDictionaries
        {
            get
            {
                var list = new List<ResourceDictionaryInfo>();
                var dictionary = (IEnumerable)typeof(Sundew.Xaml.Optimizations.ResourceDictionary).GetField("ResourceDictionaries", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
                foreach (var o in dictionary)
                {
                    var value = o.GetType().GetProperty("Value").GetValue(o);
                    var key = (Uri)o.GetType().GetProperty("Key").GetValue(o);
                    var references = ((ICollection)value.GetType().GetProperty(
                                         "ReferencingResourceDictionaries",
                                         BindingFlags.Instance | BindingFlags.Public)
                                         .GetValue(value)).Count;
                    list.Add(new ResourceDictionaryInfo(key, references));
                }

                return list;
            }
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
}
