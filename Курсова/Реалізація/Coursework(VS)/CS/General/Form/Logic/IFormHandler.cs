using CS.General.Form.Field.Logic;

namespace CS.General.Form.Logic
{
	public interface IFormHandler
    {
        public bool Get(FormData data);
    }

    public struct FormFeedback(string message, Dictionary<Tag, object> data)
    {
        public string Message { get; private set; } = message;
        public Dictionary<Tag, object> Data { get; private set; } = data;
    }
}