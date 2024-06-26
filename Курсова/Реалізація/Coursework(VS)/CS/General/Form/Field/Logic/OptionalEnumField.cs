namespace CS.General.Form.Field.Logic
{
	internal class OptionalEnumField : EnumField
	{
		public OptionalEnumField(ListField ui, ComboList type, Tag tag) : base(ui, type, tag)
		{
			ui.Title += " *";
		}

		protected override bool Check() => true;
	}
}