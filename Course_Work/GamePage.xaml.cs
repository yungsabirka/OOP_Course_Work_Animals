using OOPLAB;

namespace Course_Work
{
	public partial class GamePage : ContentPage
	{
		private GameModel _gameModel;
		private int _grassAmount;
		private int _preysAmount;
		private int _predatorsAmount;
		public GamePage()
		{
			InitializeComponent();
		}

		private async void StartGame(object sender, EventArgs e)
		{
			if(int.TryParse(entryGrass.Text, out _grassAmount) && int.TryParse(entryPredators.Text, out _predatorsAmount) 
				&& int.TryParse(entryPreys.Text, out _preysAmount))
			{
				if (_grassAmount > 0 && _predatorsAmount > 0 && _preysAmount > 0)
				{

					if (_gameModel is null)
					{
						_gameModel = new GameModel(_preysAmount, _predatorsAmount, _grassAmount);
						var simulation = new Simulation(_gameModel.map);
						var visualisation = new Visualisation(_gameModel.map, this);
						visualisation.AddImagesToPage();
						await Task.Run(async () =>
						{
							while (!visualisation.MapReady)
							{
								await Task.Delay(50);
							}
							simulation.Start(visualisation);
						});
						Content = AddGoStatisticButton(simulation.Statistics);

                    }
					
				}

            }

		}

		private VerticalStackLayout AddGoStatisticButton(Statistics statistic)
		{
			var verticalContainer = new VerticalStackLayout
			{
				BackgroundColor = new Color(0, 0, 0),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
			};
			var buttonToStatistic = new Button
			{
				BackgroundColor = new Color(255,255,255),
				Text = "Go to statistic",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions= LayoutOptions.Center,
				TextColor = new Color(0,0,0),
				WidthRequest = 200,
			};
			buttonToStatistic.Clicked += (senter, e) =>
			{
                Navigation.PushAsync(new StatisticMenu(statistic));
            };
			verticalContainer.Add(buttonToStatistic);
			return verticalContainer;
        }

	}
}