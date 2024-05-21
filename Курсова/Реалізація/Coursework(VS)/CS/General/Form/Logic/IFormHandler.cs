namespace CS.General.Form.Logic
{
	public interface IFormHandler
    {
		public FormErrorHandler[] ErrorHandlers { get; }

        public void Get(Form form);
    }
}