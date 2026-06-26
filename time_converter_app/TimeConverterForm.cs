using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace time_converter_app
{
    public partial class TimeConverterForm : Form
    {
        private List<TimezoneDisplayItem> _allTargetTimezones;
        private bool _isUpdatingTargetCombo;

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

            comboBoxTargetTimezone.DataSource = null;
            comboBoxTargetTimezone.DisplayMember = "DisplayText";
            comboBoxTargetTimezone.ValueMember = "Timezone";
            comboBoxTargetTimezone.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTargetTimezone.DropDownWidth = 420;
            comboBoxTargetTimezone.Items.Clear();
            comboBoxTargetTimezone.Items.AddRange(items.ToArray());
            _allTargetTimezones = items;

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
            if (!(comboBoxSourceTimezone.SelectedItem is TimezoneDisplayItem sourceItem))
            {
                MessageBox.Show("Please select your source timezone.", "Missing time zone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimezoneDisplayItem targetItem = comboBoxTargetTimezone.SelectedItem as TimezoneDisplayItem;
            if (targetItem == null)
            {
                targetItem = FindTargetItemByText(comboBoxTargetTimezone.Text);
                if (targetItem != null)
                {
                    comboBoxTargetTimezone.SelectedItem = targetItem;
                }
            }

            if (targetItem == null)
            {
                MessageBox.Show("Please enter or select a valid target timezone.", "Missing target time zone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            labelConversionResult.Text = $"{sourceDateTime:yyyy-MM-dd} {sourceDateTime:hh:mm tt} in {sourceZone.StandardName}\n→ {targetDateTime:yyyy-MM-dd} {targetDateTime:hh:mm tt} in {targetZone.StandardName}";
        }

        private void textBoxTargetTimezoneSearch_TextChanged(object sender, EventArgs e)
        {
            if (_isUpdatingTargetCombo)
            {
                return;
            }

            FilterTargetTimeZones(textBoxTargetTimezoneSearch.Text);
        }

        private void FilterTargetTimeZones(string searchText)
        {
            var selectedItem = comboBoxTargetTimezone.SelectedItem as TimezoneDisplayItem;
            var filtered = string.IsNullOrWhiteSpace(searchText)
                ? new List<TimezoneDisplayItem>(_allTargetTimezones)
                : _allTargetTimezones
                    .Where(item => item.DisplayText.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0
                        || item.Timezone.Id.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0
                        || item.Timezone.DisplayName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

            _isUpdatingTargetCombo = true;
            try
            {
                comboBoxTargetTimezone.BeginUpdate();
                comboBoxTargetTimezone.Items.Clear();
                comboBoxTargetTimezone.Items.AddRange(filtered.ToArray());
                comboBoxTargetTimezone.EndUpdate();

                if (selectedItem != null && filtered.Any(item => item.Timezone.Id == selectedItem.Timezone.Id))
                {
                    comboBoxTargetTimezone.SelectedItem = filtered.First(item => item.Timezone.Id == selectedItem.Timezone.Id);
                }
                else
                {
                    comboBoxTargetTimezone.SelectedIndex = -1;
                }
            }
            finally
            {
                _isUpdatingTargetCombo = false;
            }

            if (filtered.Count > 0)
            {
                comboBoxTargetTimezone.DroppedDown = true;
            }
        }

        private TimezoneDisplayItem FindTargetItemByText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            string normalized = text.Trim();
            return _allTargetTimezones.FirstOrDefault(item =>
                string.Equals(item.DisplayText, normalized, StringComparison.OrdinalIgnoreCase)
                || string.Equals(item.Timezone.Id, normalized, StringComparison.OrdinalIgnoreCase)
                || string.Equals(item.Timezone.DisplayName, normalized, StringComparison.OrdinalIgnoreCase));
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
