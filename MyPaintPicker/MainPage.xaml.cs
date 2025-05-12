namespace MyPaintPicker;

public partial class MainPage : ContentPage
{
	// Flag to prevent multiple setColor calls during random color generation
	private bool isUpdatingSliders = false;

	public MainPage()
	{
		InitializeComponent();
		
		// Initialize color based on default slider values
		setColor();
	}

	private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		// Skip if we're updating sliders programmatically
		if (!isUpdatingSliders)
		{
			setColor();
		}
	}

	private void setColor()
	{
		// Get values from sliders
		int red = (int)sliderRed.Value;
		int green = (int)sliderGreen.Value;
		int blue = (int)sliderBlue.Value;

		// Create color and update background
		Color color = Color.FromRgb(red, green, blue);
		
		// Update page background color
		BackgroundColor = color;
		
		// Update random button color to match background
		btnRandom.BackgroundColor = color;
		
		// Update hex label
		string hexColor = $"#{red:X2}{green:X2}{blue:X2}";
		hexLabel.Text = hexColor;
	}

	private void btnRandom_Clicked(object sender, EventArgs e)
	{
		// Set the flag to prevent multiple setColor calls
		isUpdatingSliders = true;
		
		// Generate random RGB values
		var random = new Random();
		int red = random.Next(0, 256);
		int green = random.Next(0, 256);
		int blue = random.Next(0, 256);
		
		// Update slider values
		sliderRed.Value = red;
		sliderGreen.Value = green;
		sliderBlue.Value = blue;
		
		// Reset the flag
		isUpdatingSliders = false;
		
		// Update the color once after all sliders are set
		setColor();
	}
	
	private async void btnCopy_Clicked(object sender, EventArgs e)
	{
		// Get the current hex color value
		string hexColor = hexLabel.Text;
		
		// Show a message indicating the color code was copied
		await DisplayAlert("Color Code", $"Color code {hexColor} copied!", "OK");
	}
}

