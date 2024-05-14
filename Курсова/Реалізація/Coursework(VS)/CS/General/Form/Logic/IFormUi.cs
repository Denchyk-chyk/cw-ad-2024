using Input = CS.General.Form.Field.Logic;

namespace CS.General.Form.Logic
{
	public interface IFormUi
	{
		public List<Input.Field> Fields { get; }

		public void Enable();
		public void Disable();
		public void Delete();
		public void Open(Form logic);
	}
}