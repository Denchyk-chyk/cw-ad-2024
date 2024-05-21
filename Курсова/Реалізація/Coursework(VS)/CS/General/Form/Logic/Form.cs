﻿using System.Windows;
using Input = CS.General.Form.Field.Logic;

namespace CS.General.Form.Logic
{
	public class Form
	{
		public object this[Input.Tag tag]
		{
			get => _data[tag];
			set => _sets[tag].Write(value);
		}

		private Dictionary<Input.Tag, object> _data;
		private Dictionary<Input.Tag, Input.Field> _sets;
		private IFormUi _ui;
		private IFormUser _user;
		private IFormHandler _handler;

		public Form(IFormUi ui)
		{
			_ui = ui;
		}

		public void Open(IFormUser user, IFormHandler handler)
		{
			_ui.Open(Send, Close);
			_sets = _ui.Fields.ToDictionary(item => item.Tag, item => item);
			_user = user;
			_handler = handler;
		}

		private void Send()
		{
			if (Check(out Dictionary<Input.Tag, object> data))
			{
				_data = data;
				_ui.Disable();
				FormSender.Send(this, _handler);
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

		public void Reopen(string feedback)
		{
			_ui.Enable();
			foreach (var item in _data) _sets[item.Key].Write(item.Value);
			MessageBox.Show(feedback);
		}
		 
		public void Close()
		{
			_user.ReturnTo();
			_ui.Delete();
		}
	}
}