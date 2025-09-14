# Sundew.Xaml.Optimizer.Sample

## Setting up a project to use xaml optimizations:
1. Reference [Sundew.Xaml.Optimizer](https://www.nuget.org/packages/Sundew.Xaml.Optimizer.BuildTool) via Nuget.
2. Reference optimization dlls, e.g. Nuget package: [Sundew.Xaml.Optimizations](https://www.nuget.org/packages/Sundew.Xaml.Optimizations).
3. Add sxo-settings.sxos to the project folder or a parent folder of the project folder.
4. Fill sxo-settings.sxos e.g. based on the following sample: https://github.com/hugener/Sundew.Xaml.Optimizer.Sample/blob/master/Source/Sundew.Xaml.Optimizer.Sample.Wpf/sxo/Sundew.Xaml.Optimizers.sxos
5. Build and run.

## More on sxo-settings.sxos
* The settings file allows to completely disable optimization (Global IsEnabled)
* Enable/disable individual optimizers (IsEnabled for each optimizer).
* Can be placed in a parent folder of the project file in order to support reuse (Currently, max. 4 levels above, let me know if you need more).
* Can contain optimizer specific settings in json.
