// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagnosticSample.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CustomOptimizer;

using System.Collections.Generic;
using System.Threading.Tasks;
using Sundew.Xaml.Optimization;
using Sundew.Xaml.Optimization.Xml;

/// <summary>
/// Example implementation of a XAML optimizer the only reports diagnostics.
/// </summary>
public class DiagnosticSample : IXamlOptimizer
{
    /// <summary>
    /// Gets the list of platforms supported by this component.
    /// </summary>
    public IReadOnlyList<XamlPlatform> SupportedPlatforms => [XamlPlatform.WPF];

    /// <summary>
    /// Optimizes the specified XAML files asynchronously.
    /// </summary>
    /// <param name="xamlFiles">The xaml files.</param>
    /// <param name="xamlPlatformInfo">The xaml platform info.</param>
    /// <param name="projectInfo">The project info.</param>
    /// <returns>The optimization result.</returns>
    public ValueTask<OptimizationResult> OptimizeAsync(IReadOnlyList<XamlFile> xamlFiles, XamlPlatformInfo xamlPlatformInfo, ProjectInfo projectInfo)
    {
        var xamlDiagnostic = new XamlDiagnostic("DS0001", "This is a sample diagnostic from the DiagnosticSample optimizer.", [], DiagnosticSeverity.Warning, xamlFiles[0].Reference.Path, 1, 1, 1, 1);
        return OptimizationResult.Report(xamlDiagnostic);
    }
}
