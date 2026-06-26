# Time Converter App

## Overview

This is a simple Windows Forms application that converts a user-entered date and time from one timezone to another.

## Features

- Choose your current timezone from a dropdown list.
- Choose the target timezone you want to convert to.
- Enter the source date and time using a date/time picker.
- Specify whether daylight savings should apply using a checkbox.
- Press the Convert button to see the resulting date and time in the selected target timezone.

## How to Use

1. Open the `time_converter_app` project in Visual Studio.
2. Build the project and run the application.
3. In the app window:
   - Select your source timezone from the `Your timezone` dropdown.
   - Select the `Convert to` target timezone.
   - Choose the date and time you want to convert.
   - Check `Daylight savings apply` if the source timezone currently has DST in effect.
   - Click the `Convert` button.
4. The converted time and date appear below the button in the result label.

## Notes

- The app uses your system's available timezone database.
- If a timezone observes daylight savings and you uncheck the DST option, the app will convert using the standard time offset instead.
- Ignore generated Visual Studio files in `.vs`, `bin`, and `obj` when committing.

## Files of Interest

- `time_converter_app/TimeConverterForm.cs` - main app logic and comments.
- `time_converter_app/TimeConverterForm.Designer.cs` - UI control definitions.
- `time_converter_app/Program.cs` - application startup.
- `.gitignore` - ignores IDE/build artifacts.
