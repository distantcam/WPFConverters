# WPFConverters

- [![Build status](https://ci.appveyor.com/api/projects/status/lbawgdvn3k5omfcw?svg=true)](https://ci.appveyor.com/project/distantcam/wpfconverters)
- [![NuGet Package](https://img.shields.io/nuget/v/WPFConverters.svg)](https://www.nuget.org/packages/WPFConverters/)


WPF Converters is a collection of common converters for WPF.

The namespace for the converters is `xmlns:con="http://schemas.macfar.land/wpfconverters"`

- [BaseConverter](#baseconverter) - A base class for implementing your own converter.
- [BitmapImageConverter](#bitmapimageconverter) - Converts a `Url` (or `string`) to a `BitmapImage`.
- [BoolToBrushConverter](#booltobrushconverter) - Converts a `bool` to a `Brush`.
- [BoolToVisibilityConverter](#booltovisibilityconverter) - Converts a `bool` to `Visibility`.
- [ColorToBrushConverter](#colortobrushconverter) - Converts a `Color` to a `Brush`.
- [NullToVisibilityConverter](#nulltovisibilityconverter) - Converts `null` to `Visibility`.
- [StringEmptyOrNullToVisibilityConverter](#stringemptyornulltovisibilityconverter) - Convert an empty or `null` `string` to `Visibility`.

---

## BaseConverter

A helper class for implementing converters.

Instead of throwing an exception if your converter fails, return `DependencyProperty.UnsetValue` instead.

---

## BitmapImageConverter

Converts a `Url` (or `string`) to a `BitmapImage`.

```
<Image Source="{Binding ImageUrl,
                        Converter={con:BitmapImageConverter}}" />
```

---

## BoolToBrushConverter

Converts a `bool` to a `Brush`.

- `FalseBrush` - The `Brush` to use for false.
- `TrueBrush` - The `Brush` to use for true.

```
<Border Background="{Binding HasError,
                             Converter={con:BoolToBrushConverter FalseBrush=Black, TrueBrush=Red}}">
```

---

## BoolToVisibilityConverter

Converts a bool to Visibility. Defaults to `Visibility.Collapsed`.

- `Invert` - Reverses the converter (true is collapsed, false is visible).
- `IsHidden` - Use `Visibility.Hidden` for false values (or true values if `Invert` is also true).

```
<TextBlock Text="There was a problem"
           Visibility="{Binding HasError,
                                Converter={con:BoolToVisibilityConverter IsHidden=true}}" />
```

---

## ColorToBrushConverter

Converts a `Color` to a `Brush`.

```
<Border Background={Binding Source={StaticResource ErrorColor},
                            Converter={con:ColorToBrushConverter},
                            Mode=OneWay}" />
```
---

## NullToVisibilityConverter

Converts `null` to `Visibility`

- `Invert` - Reverses the converter (true is collapsed, false is visible).
- `IsHidden` - Use `Visibility.Hidden` for false values (or true values if `Invert` is also true).

```
TextBlock Text="There was a problem"
           Visibility="{Binding ErrorData,
                                Converter={con:NullToVisibilityConverter}}" />
```

---

## StringEmptyOrNullToVisibilityConverter

Convert an empty or `null` `string` to `Visibility`.

- `Invert` - Reverses the converter (true is collapsed, false is visible).
- `IsHidden` - Use `Visibility.Hidden` for false values (or true values if `Invert` is also true).

```
TextBlock Text="{Binding ErrorString}"
           Visibility="{Binding ErrorString,
                                Converter={con:StringEmptyOrNullToVisibilityConverter}}" />
```