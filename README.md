# Sundew.Xaml.Optimizer.Sample

## Setting up a project to use xaml optimizations:
1. Reference [Sundew.Xaml.Optimizer](https://www.nuget.org/packages/Sundew.Xaml.Optimizer) via Nuget.
2. Reference optimization dlls, e.g. Nuget package: [Sundew.Xaml.Optimizations](https://www.nuget.org/packages/Sundew.Xaml.Optimizations).
3. Add sxo-settings.json to the project folder or a parent folder of the project folder.
4. Fill sxo-settings.json e.g. based on the following sample: https://github.com/hugener/Sundew.Xaml.Optimizer.Sample/blob/master/Sources/Sundew.Xaml.Optimizer.Sample.Wpf/sxo-settings.json
5. Build and run.

## More on sxo-settings.json
* The settings file allows to completely disable optimization (Global IsEnabled)
* Enable/disable individual optimizers (IsEnabled for each optimizer).
* Can be placed in a parent folder of the project file in order to support reuse (Currently, max. 4 levels above, let me know if you need more).
* Library paths can be absolute or relative to the packages folder in the solution directory.  
* Library paths can use ?LATEST_VERSION? instead of using a specific version number to avoid breaking the build when optimizer packages are updated. Non-Prerelease packages are considered newer than prerelease packages if the version numbers are the same. See sample: https://github.com/hugener/Sundew.Xaml.Optimizer.Sample/blob/master/Sources/Sundew.Xaml.Optimizer.Sample.Wpf/sxo-settings.json
* Can contain optimizer specific settings in json.
