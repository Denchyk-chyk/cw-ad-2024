using CS.General.Form.Field.Logic;

namespace CS.General.Form.Logic
{
	public class FormErrorHandler
    {
		private Type _type;
        private Func<Exception, bool> _condition;
        private Func<Exception, string> _message;
        private (Tag Tag, object Values)[] _edits;

        public bool Handle(Exception exception, Form form)
        {
            if (exception.GetType().Equals(_type) && _condition(exception))
            {
    		    foreach ((Tag tag, object value) in _edits) form[tag] = value;
				form.Reopen(_message(exception));
			    return true;
			}

            return false;
        }

		public FormErrorHandler(Type type, Func<Exception, bool> condition, Func<Exception, string> message, params (Tag Tag, object Value)[] edits)
        {
            _type = type;
            _condition = condition;
            _message = message;
            _edits = edits;
        }

		public FormErrorHandler(Func<Exception, string> message, params (Tag Tag, object Value)[] edits) : this(typeof(Exception), ex => true, message, edits) { }
		public FormErrorHandler(Type type, Func<Exception, bool> condition, string message, params (Tag Tag, object Value)[] edits) : this(type, condition, ex => message, edits) { }
		public FormErrorHandler(Type type, Func<Exception, string> message, params (Tag Tag, object Value)[] edits) : this(type, ex => true, message, edits) { }

	}
}