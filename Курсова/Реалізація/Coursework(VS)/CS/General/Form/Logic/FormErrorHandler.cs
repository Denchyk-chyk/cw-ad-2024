using CS.General.Form.Field.Logic;

namespace CS.General.Form.Logic
{
	public class FormErrorHandler(Type type, Func<Exception, bool> condition, Func<Exception, string> message, params (Tag Tag, object Value)[] edits)
	{
		private Type _type = type;
        private Func<Exception, bool> _condition = condition;
        private Func<Exception, string> _message = message;
        private (Tag Tag, object Values)[] _edits = edits;

        public bool Handle(Exception exception, Form form)
        {
			if ((exception.GetType().Equals(_type) || exception.GetType().IsSubclassOf(_type)) && _condition(exception))
            {
    		    foreach ((Tag tag, object value) in _edits) form[tag] = value;
				form.Reopen(_message(exception));
			    return true;
			}

            return false;
        }

		public FormErrorHandler(Func<Exception, string> message, params (Tag Tag, object Value)[] edits) : this(typeof(object), ex => true, message, edits) { }
		public FormErrorHandler(Type type, Func<Exception, bool> condition, string message, params (Tag Tag, object Value)[] edits) : this(type, condition, ex => message, edits) { }
		public FormErrorHandler(Type type, Func<Exception, string> message, params (Tag Tag, object Value)[] edits) : this(type, ex => true, message, edits) { }

	}
}