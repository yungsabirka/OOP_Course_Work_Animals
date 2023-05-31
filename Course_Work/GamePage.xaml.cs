using OOPLAB;

namespace Course_Work
{
	public partial class GamePage : ContentPage
	{
		private GameModel _gameModel;

		public GamePage()
		{
			InitializeComponent();
		}

		private async void StartGame(object sender, EventArgs e)
		{
			if (_gameModel is null)
			{
				_gameModel = new GameModel(100, 15, 300);
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
			}
		}
	}
}