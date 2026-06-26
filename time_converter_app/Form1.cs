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
        }

        /// <summary>
        /// Populate the timezone dropdowns with system time zones.
        /// This sets the source and target timezone lists and selects a default timezone for the source.
        /// </summary>
        private void InitializeTimeZones()
        {
            var timeZones = TimeZoneInfo.GetSystemTimeZones().ToList();

            comboBoxSourceTimezone.DataSource = new List<TimeZoneInfo>(timeZones);
            comboBoxSourceTimezone.DisplayMember = "DisplayName";
            comboBoxSourceTimezone.ValueMember = "Id";

            comboBoxTargetTimezone.DataSource = new List<TimeZoneInfo>(timeZones);
            comboBoxTargetTimezone.DisplayMember = "DisplayName";
            comboBoxTargetTimezone.ValueMember = "Id";

            // Set a friendly default source timezone when possible.
            var defaultSource = timeZones.FirstOrDefault(tz => tz.Id.Contains("Manila") || tz.DisplayName.Contains("Philippine") || tz.Id.Contains("Singapore"));
            if (defaultSource != null)
            {
                comboBoxSourceTimezone.SelectedItem = defaultSource;
            }
            else if (timeZones.Count > 0)
            {
                comboBoxSourceTimezone.SelectedIndex = 0;
            }

            if (timeZones.Count > 0)
            {
                comboBoxTargetTimezone.SelectedIndex = timeZones.Count > 1 ? 1 : 0;
            }
        }

        /// <summary>
        /// Convert the selected time from the source timezone to the target timezone.
        /// This method is executed when the Convert button is clicked.
        /// </summary>
        private void buttonConvertTime_Click(object sender, EventArgs e)
        {
            if (!(comboBoxSourceTimezone.SelectedItem is TimeZoneInfo sourceZone) || !(comboBoxTargetTimezone.SelectedItem is TimeZoneInfo targetZone))
            {
                MessageBox.Show("Please select both source and target time zones.", "Missing time zone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime userEnteredDateTime = dateTimePickerInputDateTime.Value;
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

            labelConversionResult.Text = $"{sourceDateTime:yyyy-MM-dd HH:mm} in {sourceZone.StandardName} converts to {targetDateTime:yyyy-MM-dd HH:mm} in {targetZone.StandardName}.";
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
