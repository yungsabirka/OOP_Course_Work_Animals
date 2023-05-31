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



		private void StartGame(object sender, EventArgs e)
		{
			if (_gameModel == null)
			{
				_gameModel = new GameModel();
				var simulation = new Simulation(_gameModel.map);
				var visualisation = new Visualisation(_gameModel.map, this);
				visualisation.AddImagesToPage();
				Task.Run(async () =>
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