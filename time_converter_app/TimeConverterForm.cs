using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace time_converter_app
{
    public partial class TimeConverterForm : Form
    {
        public TimeConverterForm()
        {
            InitializeComponent();
            InitializeTimeZones();
            dateTimePickerDate.Value = DateTime.Now.Date;
            dateTimePickerTime.Value = DateTime.Now;
        }

        private class TimezoneDisplayItem
        {
            public TimeZoneInfo Timezone { get; }
            public string DisplayText { get; }

            public TimezoneDisplayItem(TimeZoneInfo timezone)
            {
                Timezone = timezone;
                DisplayText = GetDisplayText(timezone);
            }

            private static string GetDisplayText(TimeZoneInfo tz)
            {
                string offset = tz.BaseUtcOffset.ToString("hh\\:mm");
                if (tz.BaseUtcOffset < TimeSpan.Zero)
                {
                    offset = "-" + offset.TrimStart('-');
                }
                else if (tz.BaseUtcOffset == TimeSpan.Zero)
                {
                    offset = "Z";
                }
                else
                {
                    offset = "+" + offset;
                }

                return $"{offset} {tz.StandardName}";
            }

            public override string ToString() => DisplayText;
        }

        /// <summary>
        /// Populate the timezone dropdowns with system time zones.
        /// This sets the source and target timezone lists and selects a default timezone for the source.
        /// </summary>
        private void InitializeTimeZones()
        {
            var timeZones = TimeZoneInfo.GetSystemTimeZones()
                .OrderBy(tz => tz.BaseUtcOffset)
                .ThenBy(tz => tz.StandardName)
                .ToList();

            var items = timeZones.Select(tz => new TimezoneDisplayItem(tz)).ToList();

            comboBoxSourceTimezone.DataSource = new List<TimezoneDisplayItem>(items);
            comboBoxSourceTimezone.DisplayMember = "DisplayText";
            comboBoxSourceTimezone.ValueMember = "Timezone";
            comboBoxSourceTimezone.DropDownWidth = 420;

            comboBoxTargetTimezone.DataSource = new List<TimezoneDisplayItem>(items);
            comboBoxTargetTimezone.DisplayMember = "DisplayText";
            comboBoxTargetTimezone.ValueMember = "Timezone";
            comboBoxTargetTimezone.DropDownWidth = 420;

            var defaultSource = items.FirstOrDefault(item => item.Timezone.Id.Contains("Manila") || item.Timezone.DisplayName.Contains("Philippine") || item.Timezone.Id.Contains("Singapore"));
            if (defaultSource != null)
            {
                comboBoxSourceTimezone.SelectedItem = defaultSource;
            }
            else if (items.Count > 0)
            {
                comboBoxSourceTimezone.SelectedIndex = 0;
            }

            if (items.Count > 1)
            {
                comboBoxTargetTimezone.SelectedIndex = (comboBoxSourceTimezone.SelectedIndex == 0) ? 1 : 0;
            }
        }

        /// <summary>
        /// Convert the selected time from the source timezone to the target timezone.
        /// This method is executed when the Convert button is clicked.
        /// </summary>
        private void buttonConvertTime_Click(object sender, EventArgs e)
        {
            if (!(comboBoxSourceTimezone.SelectedItem is TimezoneDisplayItem sourceItem) || !(comboBoxTargetTimezone.SelectedItem is TimezoneDisplayItem targetItem))
            {
                MessageBox.Show("Please select both source and target time zones.", "Missing time zone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeZoneInfo sourceZone = sourceItem.Timezone;
            TimeZoneInfo targetZone = targetItem.Timezone;

            DateTime userEnteredDateTime = GetSelectedDateTime();
            bool daylightSavingsApplies = checkBoxDaylightSavings.Checked;
            DateTime sourceDateTime = DateTime.SpecifyKind(userEnteredDateTime, DateTimeKind.Unspecified);

            if (!daylightSavingsApplies)
            {
                sourceDateTime = RemoveDaylightSaving(sourceDateTime, sourceZone);
            }

            DateTime utcTime;
            try
            {
                utcTime = TimeZoneInfo.ConvertTimeToUtc(sourceDateTime, sourceZone);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not convert source time to UTC: {ex.Message}", "Conversion error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime targetDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, targetZone);
            if (!daylightSavingsApplies)
            {
                targetDateTime = RemoveDaylightSaving(targetDateTime, targetZone);
            }

            labelConversionResult.Text = $"{sourceDateTime:yyyy-MM-dd} {sourceDateTime:HH:mm} in {sourceZone.StandardName}\n→ {targetDateTime:yyyy-MM-dd} {targetDateTime:HH:mm} in {targetZone.StandardName}";
        }

        /// <summary>
        /// Refresh the date/time controls to the current local date and time.
        /// This lets the user quickly update the source entry to now.
        /// </summary>
        private void buttonRefreshDateTime_Click(object sender, EventArgs e)
        {
            dateTimePickerDate.Value = DateTime.Now.Date;
            dateTimePickerTime.Value = DateTime.Now;
            labelConversionResult.Text = "Date and time refreshed to current local time.";
        }

        /// <summary>
        /// Reset the form entries back to their initial state.
        /// The source and target timezones are restored and the result label is cleared.
        /// </summary>
        private void buttonResetForm_Click(object sender, EventArgs e)
        {
            InitializeTimeZones();
            dateTimePickerDate.Value = DateTime.Now.Date;
            dateTimePickerTime.Value = DateTime.Now;
            checkBoxDaylightSavings.Checked = false;
            labelConversionResult.Text = "Result will appear here.";
        }

        /// <summary>
        /// Close the application when the exit button is clicked.
        /// </summary>
        private void buttonExitApp_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Read the selected date and time controls and combine them into one DateTime.
        /// </summary>
        private DateTime GetSelectedDateTime()
        {
            DateTime datePart = dateTimePickerDate.Value.Date;
            TimeSpan timePart = dateTimePickerTime.Value.TimeOfDay;
            return datePart + timePart;
        }

        /// <summary>
        /// Remove the daylight saving offset from a date/time if DST is not meant to apply.
        /// This makes the conversion ignore DST for the selected timezone.
        /// </summary>
        private DateTime RemoveDaylightSaving(DateTime dateTime, TimeZoneInfo timeZone)
        {
            if (!timeZone.SupportsDaylightSavingTime)
            {
                return dateTime;
            }

            TimeSpan offset = timeZone.GetUtcOffset(dateTime);
            TimeSpan standardOffset = timeZone.BaseUtcOffset;
            if (offset == standardOffset)
            {
                return dateTime;
            }

            TimeSpan delta = offset - standardOffset;
            return dateTime - delta;
        }
    }
}
