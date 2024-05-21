namespace CS.General.Form.Logic
{
	public static class FormSender
	{
        public static void Send(Form form, IFormHandler handler)
        {
            try { handler.Get(form); }
            catch (Exception exception)
            {
                foreach (var errorHandler in handler.ErrorHandlers)
                    if (errorHandler.Handle(exception, form)) return;
			}

			form.Close();
		}
	}
}