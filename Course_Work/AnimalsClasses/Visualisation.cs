using Course_Work;
using System.Collections.ObjectModel;

namespace OOPLAB
{
	class Visualisation : BindableObject
	{
		private ObservableCollection<ObservableCollection<MyString>> _priorityMap;

		public Visualisation(List<GameObject>[,] gameModel, GamePage gamePage)
		{
			_gamePage = gamePage;
			_gameModelMap = gameModel;
			_priorityMap = new ObservableCollection<ObservableCollection<MyString>>();
			InitializePriorityMap();
		}

		private readonly List<GameObject>[,] _gameModelMap;
		private readonly GamePage _gamePage;

		private void InitializePriorityMap()
		{
			lock (lockCells)
			{
				for (int i = 0; i < _gameModelMap.GetLength(0); i++)
				{
					var row = new ObservableCollection<MyString>();
					for (int j = 0; j < _gameModelMap.GetLength(1); j++)
					{
						if (EasyVisualisation(_gameModelMap[i, j]) != null)
							row.Add(new MyString(EasyVisualisation(_gameModelMap[i, j])));
						else
							row.Add(new MyString("square.png"));
					}
					_priorityMap.Add(row);
				}
			}
		}

		object lockCells = new();

		private string EasyVisualisation(List<GameObject> cell)
		{

			if (cell.Count == 0)
				return null;
			var priorityQueue = new PriorityQueue<GameObject, int>();
			foreach (var item in cell.ToList())
				priorityQueue.Enqueue(item, item.Priority);

			return priorityQueue.Dequeue().SourceImage;

		}

		private bool _MapReady;
		public bool MapReady
		{
			get
			{
				return _MapReady;
			}
			set
			{
				if (_MapReady != value)
				{
					_MapReady = value;
					OnPropertyChanged();
				}
			}
		}


		public void AddImagesToPage()
		{
			MainThread.BeginInvokeOnMainThread(async () =>
			{
				var horisontalStackLayout = new StackLayout
				{
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = new Color(255, 255, 255)
				};
				foreach (var row in _priorityMap)
				{
					var verticalStackLayout = new StackLayout
					{
						Orientation = StackOrientation.Vertical
					};
					foreach (var item in row)
					{
						var image = new Image
						{
							HeightRequest = 25,
							WidthRequest = 25,
							BindingContext = item
						};
						image.SetBinding(Image.SourceProperty, new Binding($"ValueString"));
						verticalStackLayout.Children.Add(image);
					}
					horisontalStackLayout.Children.Add(verticalStackLayout);
				}
				_gamePage.Content = horisontalStackLayout;
				MapReady = true;
			});
		}

		public async Task GenerateImageArrayAsync()
		{
			Dispatcher.Dispatch(() =>
			{
				UpdatePriorityMap();
			});
		}

		private void UpdatePriorityMap()
		{
			lock (lockCells)
			{
				for (int i = 0; i < _gameModelMap.GetLength(0); i++)
				{
					for (int j = 0; j < _gameModelMap.GetLength(1); j++)
					{
						if (EasyVisualisation(_gameModelMap[i, j]) != null)
							_priorityMap[i][j].ValueString = EasyVisualisation(_gameModelMap[i, j]);
						else
							_priorityMap[i][j].ValueString = "square.png";
					}
				}
			}
		}
	}
}