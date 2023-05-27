namespace Course_Work;
using OOPLAB;
public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();

        GameModel gameModel = new();
        Simulation simulation = new(gameModel.map);

        var visualisation = new Visualisation(gameModel, this);
        simulation.Start();
        /*var imageArray = new Image[32,32];
        for(int i = 0; i < 32; i++)
        {
            for(int j = 0; j < 32; j++)
            {
                if (gameModel.map[i, j].Count != 0)
                    imageArray[i, j] = new Image { Source = gameModel.map[i, j][0].SourceImage };
                else
                    imageArray[i, j] = new Image { Source = "square.png" };
            }
        }

        var horizontalStackLayout = new HorizontalStackLayout
        {
            BackgroundColor = new Color(255, 255, 255),
            HorizontalOptions = LayoutOptions.Center
        };
        for (int i = 0; i < imageArray.GetLength(0); i++)
        {
            var vertivalStackLayout = new VerticalStackLayout();
            for (int j = 0; j < imageArray.GetLength(1); j++)
            {
                var image = imageArray[i, j];

                image.WidthRequest = 50; // Установите желаемую ширину
                image.HeightRequest = 50; // Установите желаемую высоту

                vertivalStackLayout.Children.Add(image);
            }
            horizontalStackLayout.Children.Add(vertivalStackLayout);
        }
        Content = horizontalStackLayout;*/

    }

    private void PrintImages(GameModel gameModel)
    {

    }
}