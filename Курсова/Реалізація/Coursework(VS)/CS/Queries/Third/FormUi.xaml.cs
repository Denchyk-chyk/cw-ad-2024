using CS.General.Form.Container;
using CS.General.Form.Field.Logic;
using CS.General.Form.Logic;
using System.Windows;
using Input = CS.General.Form.Field.Logic;

namespace CS.Queries.Third
{
	public partial class FormUi : Window, IFormUi
	{
		public Container Container { get; private set; }

		public FormUi()
		{
			InitializeComponent();
			Container = new Container([
				new EnumField(Unit, General.ComboList.Unit, Input.Tag.Unit),
				new EnumField(Workshop, General.ComboList.Workshop, Input.Tag.Workshop),
				new EnumField(Site, General.ComboList.Site, Input.Tag.Site),
				new EnumField(EmployeeCategory, General.ComboList.EmployeeCategory, Input.Tag.EmployeeCategory),
				new EnumField(Engineer, General.ComboList.Engineer, Input.Tag.Engineer),
				new EnumField(Laborer, General.ComboList.Laborer, Input.Tag.Laborer),
				], [[[1, 2], [2], [1]], [[4, 5], [5], [4]]] );

			Unit.SetEvent((n) => Container.Activate(n));
			EmployeeCategory.SetEvent((n) => Container.Activate(n, 1));
		}

		public void Open(Action send, Action close)
		{
			Show();
			Buttons.Connect(send, close);
		}
	}
}
