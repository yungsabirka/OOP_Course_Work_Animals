namespace Course_Work;
using OOPLAB;
public partial class StatisticMenu : ContentPage
{
	private readonly int _scaleY = 300;
	private readonly int _scaleX = 400;
	public StatisticMenu(Statistics statistic)
	{
		InitializeComponent();
        var scrollView = new ScrollView
		{
			BackgroundColor = new Color(255,255,255),
		};
		var verticalContainer = new VerticalStackLayout
		{
			BackgroundColor= new Color(255,255,255),
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center
		};
		verticalContainer
			.Add(CreateHistogram(statistic.Select(item => item.PreysCount).ToList(), new Color(0, 0, 255), "Amount of prey"));
		verticalContainer.
			Add(CreateHistogram(statistic.Select(item => item.PredatorsCount).ToList(), new Color(255, 0, 0), "Amount of predators"));
		verticalContainer
			.Add(CreateHistogram(statistic.Select(item => item.GrassGrowCount).ToList(), new Color(0, 255, 0), "Amount of grass"));
        verticalContainer
			.Add(CreateHistogram(statistic.Select(item => item.GrassEatenCount).ToList(), new Color(163, 255, 178), "Amount of eaten grass"));
		verticalContainer
			.Add(CreateHistogram(statistic.Select(item => item.ChildPoopsCount).ToList(), new Color(97, 83, 0), "Amount of child poops"));
        scrollView.Content = verticalContainer;
		Content = scrollView;
	}

	private Border CreateHistogram(List<int> statistic, Color color, string statisticName)
	{
		var stepCounter = -1;
		var maxStatisticElement = statistic.Max();
		var statisticCounter = statistic.Count;
		var nameOfStatistic = new Label
		{
            VerticalTextAlignment = TextAlignment.Center,
            HorizontalTextAlignment = TextAlignment.Center,
            Text = statisticName.ToUpper(),
			BackgroundColor = color,
			TextColor = new Color(255, 255, 255),
			FontSize = 30
		};
		var border = new Border
		{
			BackgroundColor = new Color(255, 255, 255),
			Stroke = new SolidColorBrush(new Color(0, 0, 0)),
			Padding = 20
		};
	
		var horizontalContainer = new HorizontalStackLayout
		{
			BackgroundColor = new Color(255, 255, 255),
			Spacing = 20,
			Margin = 20,
            HeightRequest = 400,

        };
		var verticalContainer = new VerticalStackLayout
		{
            BackgroundColor = new Color(255, 255, 255),
			Spacing = 40
        };
        verticalContainer.Add(nameOfStatistic);
        foreach (var item in statistic)
		{
            stepCounter++;
            if (stepCounter % 10 != 0)
				continue;
			var histogramElementContainer = new VerticalStackLayout
			{
				BackgroundColor = color,
				Spacing = 0,
				Margin = 0,
				VerticalOptions = LayoutOptions.End,
			};
			var labelAmount = new Label
			{
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = new Color(0, 0, 0),
				Background = new Color(255, 255, 255),
				Text = item.ToString(),
			};
            var stepNumber = new Label
            {
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				Margin = new Thickness(0,5,0,0),
                TextColor = new Color(0, 0, 0),
                Background = new Color(255, 255, 255),
                Text = stepCounter.ToString(),
            };
            var histogramElement = new VerticalStackLayout
			{
				HeightRequest = item * _scaleY / maxStatisticElement,
				WidthRequest = statisticCounter / _scaleX,
				BackgroundColor = new Color(0, 0, 255)
			};
            histogramElementContainer.Add(labelAmount);
			histogramElementContainer.Add(histogramElement);
			histogramElementContainer.Add(stepNumber);
            horizontalContainer.Add(histogramElementContainer);
			border.Content = horizontalContainer;
		}
		verticalContainer.Add(horizontalContainer);
        border.Content = verticalContainer;
        return border;
	}

}