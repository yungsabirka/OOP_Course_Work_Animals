namespace Course_Work;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
    }

	private void GoToGamePage(object sender, EventArgs e)
	{
		Navigation.PushAsync(new GamePage());
	}
}

