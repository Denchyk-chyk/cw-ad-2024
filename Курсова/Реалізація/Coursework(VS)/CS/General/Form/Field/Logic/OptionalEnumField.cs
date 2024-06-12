namespace CS.General.Form.Field.Logic
{
	internal class OptionalEnumField(ListField ui, ComboList type, Tag tag) : EnumField(ui, type, tag)
	{
		protected override bool Check() => true;
	}
}