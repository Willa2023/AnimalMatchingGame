namespace AnimalMatchingGame;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	public void PlayAgainButton_Clicked(object sender, EventArgs e)
	{
		AnimalButtons.IsVisible = true;
		PlayAgainButton.IsVisible = false;

		List<string> animalEmoji = new List<string> { "🐶", "🐶", "🐱", "🐱", "🐰", "🐰", "🦊", "🦊", "🐻", "🐻", "🐼", "🐼", "🐠", "🐠", "🦉", "🦉" };
		foreach (var button in AnimalButtons.Children.OfType<Button>())
		{
			int index = Random.Shared.Next(animalEmoji.Count);
			string nextEmoji = animalEmoji[index];
			button.Text = nextEmoji;
			animalEmoji.RemoveAt(index);
		}
	}

	public void Button_Clicked(object sender, EventArgs e)
	{
		Console.WriteLine("Button clicked");
	}

}

