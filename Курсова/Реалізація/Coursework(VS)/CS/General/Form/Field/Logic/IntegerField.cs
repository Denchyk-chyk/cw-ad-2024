namespace CS.General.Form.Field.Logic
{
    internal class IntegerField(TextField ui, Tag tag) : StringField(ui, tag)
    {
        public override bool TryRead(out object value)
        {
            bool result = base.TryRead(out value) & int.TryParse(value.ToString(), out int number);
            value = number;
            ShowCorrectness(result);
			return result;
        }
    }
}