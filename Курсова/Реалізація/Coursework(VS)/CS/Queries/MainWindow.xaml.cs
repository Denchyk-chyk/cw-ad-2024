using CS.General;
using CS.General.Form.Logic;
using System.Windows;
using System.Windows.Controls;

namespace CS.Queries
{
	public partial class MainWindow : Window, IFormUser
	{
		private static (Func<IFormUi> ui, Func<IFormHandler> handler, string name, string tooltip)[] _options;

		public MainWindow()
		{
			InitializeComponent();
			CreateButtons(Main, 2, _options);
			FinishInit();
		}

		static MainWindow()
		{
			_options =
			[
				(() => new First.FormUi(), () => new First.Query(), "Види виробів цеху", "Перелік видів виробів окремої категорії і в цілому, що збираються зазначеним цехом, підприємством. "),
				(() => new Second.FormUi(), () => new Second.Query(), "Вироби за період часу", "Число і перелік виробів окремої категорії і в цілому, зібраних зазначеним цехом, ділянкою, підприємством в цілому за певний відрізок часу. "),
				(() => new Third.FormUi(), () => new Third.Query(), "Кадровий склад", "Дані про кадровий склад цеху, підприємства в цілому і по зазначеним категоріям інженерно-технічного персоналу і робітників. "),
				(() => new Fourth.FormUi(), () => new Fourth.Query(), "Ділянки цехів", "Число і перелік ділянок зазначеного цеху, підприємства в цілому та їх начальників. "),
				(() => new Fifth.FormUi(), () => new Fifth.Query(), "Обробка виробів", "Перелік робіт, які проходить вказаний виріб. "),
				(() => new Sixth.FormUi(), () => new Sixth.Query(), "Склад бригад", "Склад бригад зазначеної ділянки, цеху. "),
				(() => new Sixth.FormUi(), () => new Seventh.Query(), "Майстри", "Перелік майстрів вказаної ділянки, цеху. "),
				(() => new Eighth.FormUi(), () => new Eighth.Query(), "Поточні вироби", "Перелік виробів окремої категорії і в цілому, що збираються зараз зазначеним ділянкою, цехом, підприємством. "),
				(() => new Fifth.FormUi(), () => new Ninth.Query(), "Бригади для виробу", "Склад бригад, що беруть участь в складанні зазначеного виробу. "),
				(() => new Fifth.FormUi(), () => new Tenth.Query(), "Лабораторії для виробу", "Перелік випробувальних лабораторій, що беруть участь у випробуваннях деякого конкретного виробу. "),
				(() => new Eleventh.FormUi(), () => new Eleventh.Query(), "Вироби лабораторії", "Перелік виробів окремої категорії і в цілому, що проходили випробування у зазначеній лабораторії за певний період. "),
				(() => new Twelfth.FormUi(), () => new Twelfth.Query(), "Випробувачі виробу", "Перелік випробувачів, що беруть участь у випробуваннях зазначеного виробу, виробів окремої категорії і в цілому у вказаній лабораторії за певний період. "),
				(() => new Twelfth.FormUi(), () => new Thirteenth.Query(), "Випробувальне обладнання", "Склад обладнання, що використовувалося при випробуванні зазначеного виробу, виробів окремої категорії і в цілому у вказаній лабораторії за певний період. "),
				(() => new Eighth.FormUi(), () => new Fourteenth.Query(), "Уточнені поточні вироби", "Число і перелік виробів окремої категорії і в цілому, що збираються зазначеним цехом, ділянкою, підприємством в даний час")
			];
		}


		private void FinishInit()
		{
			User.Content = Database.Connection.UserName;
		}

		private void CreateButtons(Grid grid, int width, (Func<IFormUi> ui, Func<IFormHandler> handler, string name, string tooltip)[] options)
		{
			for (int i = 0; i < width; i++) grid.ColumnDefinitions.Add(new ColumnDefinition());
			for (int i = 0; i <= options.Length / width; i++) grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

			grid.RowDefinitions[^1].Height = new GridLength(1, GridUnitType.Star);
			var buttons = new Button[options.Length];

			for (int i = 0; i < buttons.Length; i++)
			{
				buttons[i] = new()
				{
					Content = options[i].name,
					ToolTip = options[i].tooltip,
					Style = (Style)FindResource("TopMarginButton")
				};

				int index = i;
				buttons[i].Click += (s, e) => new Form(options[index].ui()).Open(this, options[index].handler());

				grid.Children.Add(buttons[i]);
				Grid.SetRow(buttons[i], i / width);
				Grid.SetColumn(buttons[i], i % width);
			}
		}

		private static T Instant<T>(Type type) => (T)Activator.CreateInstance(type);

		public void ReturnTo()
		{
			Show();
		}

		private void User_Click(object sender, RoutedEventArgs e)
		{
			new CS.MainWindow().Show();
			Close();
		}
	}
}