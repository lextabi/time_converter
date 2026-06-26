# Time Converter App

## Overview

This is the final version of the Time Converter Windows Forms application. It converts a selected date and time from a source timezone into a target timezone and includes a dedicated search box for finding target timezones quickly.

## Features

- Select your source timezone from a dropdown.
- Search available target timezones using a dedicated search textbox.
- Filter the target list by partial text such as `central` or `us eastern`.
- Select the desired target timezone from the filtered list.
- Use separate date and time pickers for source input.
- Display time in 12-hour format with AM/PM.
- Refresh the source time to the current local date/time instantly.
- Reset the form to default values.
- Exit the app with a dedicated button.

## How to Use

1. Open `time_converter_app/time_converter_app.slnx` in Visual Studio.
2. Build and run the application.
3. In the app window:
   - Select your source timezone from the `Your timezone` dropdown.
   - Enter search text in `Search timezones` to filter the target timezone list.
   - Click the desired target timezone from the filtered dropdown.
   - Select the source date and time, with AM/PM support.
   - Toggle `Daylight savings apply` if you need DST-aware conversion.
   - Click `Convert`.
4. The converted date and time appear in the result panel below.

## Notes

- The app uses the system's timezone database for available timezones.
- If no search results match the entered text, the target list remains empty until the search text changes.
- Reset clears the search text and restores the original timezone lists.
- This final version is stable and ready for use.
- Ignore generated Visual Studio files in `.vs`, `bin`, and `obj` when committing.

## Files of Interest

- `time_converter_app/TimeConverterForm.cs` - main application logic.
- `time_converter_app/TimeConverterForm.Designer.cs` - Windows Forms UI layout.
- `time_converter_app/Program.cs` - application entry point.
- `time_converter_app/time_converter_app.csproj` - project file.
- `.gitignore` - Visual Studio and build artifact exclusions.
