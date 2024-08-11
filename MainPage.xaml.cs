namespace AnimalMatchingGame;

public partial class MainPage : ContentPage
{
	Button lastButtonClicked;
	Boolean findingMatch = false;
	int matchesFound;
	int tenthsOfSecondsElapsed = 0;

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

		Dispatcher.StartTimer(TimeSpan.FromSeconds(.01), TimerTick);
	}

	private bool TimerTick()
	{
		if (!this.IsLoaded)
		{
			return false;
		}
		tenthsOfSecondsElapsed++;
		TimeElapsed.Text = "Time elapsed: " + (tenthsOfSecondsElapsed / 100F).ToString("0.00s");

		if (PlayAgainButton.IsVisible)
		{
			tenthsOfSecondsElapsed = 0;
			return false;
		}

		return true;
	}

	public void Button_Clicked(object sender, EventArgs e)
	{
		if (sender is Button buttonClicked)
		{
			if (!string.IsNullOrWhiteSpace(buttonClicked.Text) && (findingMatch == false))
			{
				buttonClicked.BackgroundColor = Colors.Red;
				lastButtonClicked = buttonClicked;
				findingMatch = true;
			}
			else
			{
				if ((buttonClicked != lastButtonClicked) && (buttonClicked.Text == lastButtonClicked.Text) && (!string.IsNullOrWhiteSpace(buttonClicked.Text)))
				{
					matchesFound++;
					lastButtonClicked.Text = " ";
					buttonClicked.Text = " ";
				}
				lastButtonClicked.BackgroundColor = Colors.AliceBlue;
				lastButtonClicked.BackgroundColor = Colors.AliceBlue;
				findingMatch = false;
			}
		}
		if (matchesFound == 8)
		{
			matchesFound = 0;
			AnimalButtons.IsVisible = false;
			PlayAgainButton.IsVisible = true;
		}


	}

}

