using Wrap = CS.General.Form.Container;

namespace CS.General.Form.Logic
{
	public interface IFormUi
	{
		public Wrap.Container Container { get; }

		public void Show();
		public void Hide();
		public void Close();
		public void Open(Action send, Action close);
	}
}