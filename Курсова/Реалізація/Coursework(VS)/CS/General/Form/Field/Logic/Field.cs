using CS.General.Form.Field.UI;

namespace CS.General.Form.Field.Logic
{
    public abstract class Field(Tag tag)
    {
        public Tag Tag => tag;
		public abstract IFieldUi UiPart { get; }

		public abstract bool TryRead(out object value);

        public abstract void Write(object value);
        
        protected abstract void ShowCorrectness(bool correct);
	}

    public enum Tag
    {
        Default, Host, Port, Database, Name, Password, Type,
		Unit, ProductCategory, Product, Workshop, Site,
        FirstDate, LastDate,
		EmployeeCategory, Engineer, Laborer, 
        Laboratory, ProductsPart
	}
}