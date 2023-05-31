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
					}
				}
            }

		}

	}
}