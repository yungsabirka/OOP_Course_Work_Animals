using Course_Work;
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
		private Simulation _simulation;
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
        public Visualisation(List<GameObject>[,] gameModel, GamePage gamePage, Simulation simulation)
        {
			_simulation = simulation;
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
				if (cell.Count == 0 || cell is null)
					return null;
				return cell.ToList()
					.Where(item => item is not null)
					.Select(item => (item.Priority, item.SourceImage)).Min().SourceImage;

			}
        }
		public void CreateVisualisationPage()
		{
			MainThread.BeginInvokeOnMainThread(async () =>
			{
				var buttonContainer = AddButtonsToContainer();
				var scrollView = new ScrollView
				{
					BackgroundColor = new Color(0, 0, 0)
				};
				var verticalStackLayout = new StackLayout
				{
					Orientation = StackOrientation.Vertical,
					BackgroundColor = new Color(255, 255, 255),
					HorizontalOptions = LayoutOptions.Center
				};
				verticalStackLayout.Children.Add(buttonContainer);
				foreach (var row in _priorityMap)
				{
					var horisontalStackLayout = new StackLayout
					{
						Orientation = StackOrientation.Horizontal
                    };
					foreach (var item in row)
					{
						var image = new Image
						{
							HeightRequest = 33,
							WidthRequest = 33,
							BindingContext = item
						};
						image.SetBinding(Image.SourceProperty, new Binding($"ValueString"));
						horisontalStackLayout.Children.Add(image);
					}
					verticalStackLayout.Children.Add(horisontalStackLayout);
				}
				scrollView.Content = verticalStackLayout;
				_gamePage.Content = scrollView;
				MapReady = true;
			});
		}
        private HorizontalStackLayout AddButtonsToContainer()
        {
            var horisontalContainer = new HorizontalStackLayout
            {
                BackgroundColor = new Color(255, 255, 255),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
				Spacing = 10
            };
			var stopButton = CreateStopButton();
			var statisticButton = CreateGoToStatisticButton();
            horisontalContainer.Add(stopButton);
			horisontalContainer.Add(statisticButton);
            return horisontalContainer;
        }
		private Button CreateGoToStatisticButton()
		{
            var goToStatisticButton = new Button
            {
                BackgroundColor = new Color(50, 170, 255),
                Text = "Go to statistic",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = new Color(255, 255, 255),
                WidthRequest = 200,
            };
			goToStatisticButton.Clicked += (senter, e) =>
			{
				if (_simulation.isSimulationContinuing)
					_simulation.isSimulationContinuing = false;
                    lock (lockCells)
                    {
                        MainThread.BeginInvokeOnMainThread(() =>
                            _gamePage.Navigation.PushAsync(new StatisticMenu(_simulation.Statistics)));
                    }
            };

            return goToStatisticButton;
        }
		private Button CreateStopButton()
		{
            var stopButton = new Button
            {
                BackgroundColor = new Color(50, 170, 255),
                Text = "Stop",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = new Color(255, 255, 255),
                WidthRequest = 200,
            };
            stopButton.Clicked += async (senter, e) =>
            {
                if (_simulation.isSimulationContinuing)
                {
                    _simulation.isSimulationContinuing = false;
                    stopButton.Background = new Color(255, 170, 50);
                    stopButton.Text = "Continue";
                }
                else
                {
                    _simulation.isSimulationContinuing = true;
					stopButton.Background = new Color(50, 170, 255);
                    stopButton.Text = "Stop";
                    await Task.Run(() =>
                    {
                        _simulation.Start(this);
                    });

                }
            };
			return stopButton;
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