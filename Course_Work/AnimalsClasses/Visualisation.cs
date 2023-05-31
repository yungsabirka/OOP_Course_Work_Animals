﻿using Course_Work;
using System.Collections.ObjectModel;

namespace OOPLAB
{
	class Visualisation : BindableObject
	{
		private ObservableCollection<ObservableCollection<MyString>> _priorityMap;

		private readonly List<GameObject>[,] _gameModelMap;
		private readonly GamePage _gamePage;
        object lockCells = new();
        private bool _mapReady;
        public bool MapReady
        {
            get
            {
                return _mapReady;
            }
            set
            {
                if (_mapReady != value)
                {
                    _mapReady = value;
                    OnPropertyChanged();
                }
            }
        }
        public Visualisation(List<GameObject>[,] gameModel, GamePage gamePage)
        {
            _gamePage = gamePage;
            _gameModelMap = gameModel;
            _priorityMap = new ObservableCollection<ObservableCollection<MyString>>();
            InitializePriorityMap();
        }
        private void InitializePriorityMap()
		{
			lock (lockCells)
			{
				for (int i = 0; i < _gameModelMap.GetLength(0); i++)
				{
					var row = new ObservableCollection<MyString>();
					for (int j = 0; j < _gameModelMap.GetLength(1); j++)
					{
						if (GetPriorityItem(_gameModelMap[i, j]) != null)
							row.Add(new MyString(GetPriorityItem(_gameModelMap[i, j])));
						else
							row.Add(new MyString("square.png"));
					}
					_priorityMap.Add(row);
				}
			}
		}


		private string GetPriorityItem(List<GameObject> cell)
		{
			lock (lockCells)
			{
				if (cell.Count == 0)
					return null;
				var priorityQueue = new PriorityQueue<GameObject, int>();
				foreach (var item in cell)
					if (item is not null)
						priorityQueue.Enqueue(item, item.Priority);

				return priorityQueue.Dequeue().SourceImage;
			}
		}



		public void AddImagesToPage()
		{
			MainThread.BeginInvokeOnMainThread(async () =>
			{
				var horisontalStackLayout = new StackLayout
				{
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = new Color(255, 255, 255),
					HorizontalOptions = LayoutOptions.Center
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

		public async Task GeneratePriorityMap()
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
						if (GetPriorityItem(_gameModelMap[i, j]) != null)
							_priorityMap[i][j].ValueString = GetPriorityItem(_gameModelMap[i, j]);
						else
							_priorityMap[i][j].ValueString = "square.png";
					}
				}
			}
		}
	}
}