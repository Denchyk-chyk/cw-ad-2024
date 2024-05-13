using System.Windows;
using Input = CS.General.Form.Field.Logic;

namespace CS.General.Form.Logic
{
	public class Form
	{
		private Dictionary<Input.Tag, Input.Field> _sets;
		private IFormUi _ui;
		private IFormUser _user;
		private IFormHandler _handler;

		public Form(IFormUi ui)
		{
			_ui = ui;
		}

		public void Open(IFormHandler handler, IFormUser user)
		{
			_handler = handler;
			_user = user;
			_ui.Open(this);
			_sets = _ui.Fields.ToDictionary(item => item.Tag, item => item);
		}

		public void Send()
		{
			if (Check(out Dictionary<Input.Tag, object> data))
			{
				_ui.Disable();
				if (_handler.Get(new FormData(this, data))) Close();
			}
		}

		private bool Check(out Dictionary<Input.Tag, object> data)
		{
			data = [];
			bool result = true;

			foreach (var set in _sets)
			{
				if (set.Value.TryRead(out object value)) data[set.Key] = value;
				else result = false;
			}

			return result;
		}

		public void Reopen(FormFeedback feedback)
		{
			_ui.Enable();
			foreach (var data in feedback.Data) _sets[data.Key].Write(data.Value);
			MessageBox.Show(feedback.Message);
		}
		 
		public void Close()
		{
			_user.ReturnTo();
			_ui.Delete();
		}
	}

	public struct FormData(Form form, Dictionary<Input.Tag, object> data)
	{
		public object this[Input.Tag tag] => _values[tag];
		public Form Form { get; private set; } = form;

		private Dictionary<Input.Tag, object> _values = data;

		public FormFeedback CreateFeedback(string message, params (Input.Tag tag, object value)[] toChange)
		{
			foreach ((Input.Tag tag, object value) in toChange) _values[tag] = value;
			return new FormFeedback(message, _values);
		}
	}
}