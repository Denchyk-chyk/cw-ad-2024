using Input = CS.General.Form.Field.Logic;

namespace CS.General.Form.Container
{
	public class Container
	{
		private int[][][] _inactive;
		private Input.Field[] _fields;

		public Container(Input.Field[] fields, int[][][] inactive)
		{
			_fields = fields;
			_inactive = inactive;
			if (inactive.Length > 0)
			{
				for (int i = 0; i < inactive.Length; i++)
					Activate(-1, i);
			}
		}

		public Container(Input.Field[] fields, int[][] inactive) : this(fields, [inactive]) { }

		public Container(Input.Field[] fields) : this(fields, Array.Empty<int[][]>()) { }

		public Input.Field[] GetFields() => _fields.Where(e => e.UiPart.IsEnabled).ToArray();

		public void Activate(int value, int layer = 0)
		{
			value = value > _inactive[layer].Length - 1 ? _inactive[layer].Length - 1 : value;
			for (int i = 0; i < _fields.Length; i++)
			{
				if (_inactive[layer].Any(a => a.Contains(i)))
					_fields[i].UiPart.IsEnabled = !(value == -1 || _inactive[layer][value].Contains(i));
			}
		}
	}
}