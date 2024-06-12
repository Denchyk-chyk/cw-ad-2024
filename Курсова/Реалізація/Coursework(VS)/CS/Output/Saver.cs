using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace CS.Output
{
	internal static class Saver
	{
		public static void SaveText(string text)
		{
			var dialogue = new SaveFileDialog
			{
				Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
				FilterIndex = 1,
				RestoreDirectory = true
			};

			if (dialogue.ShowDialog() == true)
			{
				try
				{
					File.WriteAllText(dialogue.FileName, text);
					MessageBox.Show("Дані збережено");
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Помилка при збереженні ({ex.Message})");
				}
			}
		}
	}
}