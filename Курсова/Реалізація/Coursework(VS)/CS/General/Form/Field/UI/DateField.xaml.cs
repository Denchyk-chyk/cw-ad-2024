using CS.General.Form.Field.UI;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace CS.General.Form.Field
{
	public partial class DateField : UserControl, ITextFieldUi
	{
		public string Title
		{
			get => Header.Text;
			set => Header.Text = value;
		}

		public string Text
		{
			get => Field.SelectedDate.HasValue ? Field.SelectedDate.Value.ToString("yyyy-MM-dd") : string.Empty;
			set => Field.SelectedDate = DateTime.ParseExact(value, "yyyy-MM-dd", null);
		}

		public DateField()
		{
			InitializeComponent();

			Field.Loaded += (s, e) =>
			{
				if (Field.Template.FindName("PART_TextBox", Field) is DatePickerTextBox datePickerTextBox)
				{
					var watermarkProperty = typeof(DatePickerTextBox).GetProperty("Watermark", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
					watermarkProperty?.SetValue(datePickerTextBox, "Оберіть дату");
				}
			};
		}

		public void ShowCorrectness(bool correct)
		{
			Header.Foreground = correct ? Brushes.Black : Brushes.Red;
		}
	}
}