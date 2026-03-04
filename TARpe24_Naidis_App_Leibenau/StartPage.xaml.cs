namespace TARpe24_Naidis_App_Leibenau;

public partial class StartPage : ContentPage
{
	VerticalStackLayout vst;
	ScrollView sv;
	public List<ContentPage> Lehed = new List<ContentPage>() { new TextPage(), new FigurePage(), new DateTimePage(), new StepperSliderPage() };
	public List<string> LeheNimed = new List<string>() { "Tekst", "Kujund", "Kuupäev/Aeg", "Liigur" };
	public StartPage()
	{
		// Title == "Avaleht"
        vst = new VerticalStackLayout { Padding = 20, Spacing = 15 };
		for (int  i=0; i < Lehed.Count; i++)
		{
			Button nupp = new Button
			{
				Text = LeheNimed[i],
				FontSize = 36,
				FontFamily = "Luffio",
				BackgroundColor = Colors.LightGray,
				TextColor = Colors.Black,
				CornerRadius = 10,
				HeightRequest = 60,
				ZIndex = i
			};
			vst.Add(nupp);
			nupp.Clicked += (sender, e) =>
			{
				var valik = Lehed[nupp.ZIndex];
				Navigation.PushAsync(valik);
			};
		}
		sv = new ScrollView { Content = vst };
		Content = sv;
	}

	// OnAppearing
	protected override async void OnAppearing()
	{
		base.OnAppearing();

		// 1. Loeme seadme mälust muutuja "EsimeneKäivitamine".
		// Kui sellist muutujad pole (äpp on uus), annab see vaikimisi väärtusels 'true'.
		bool onEsimeneStart = Preferences.Default.Get("EsimeneKäivitamine", true);

		// 2. Kui on esimene start, kuvame dialoogiakna
		if (onEsimeneStart)
		{
			bool vastus = await DisplayAlertAsync("Tere tulemast!",
				"Tundub, et avasid selle rakenduse esimest korda. Kas soovid näha lühikest juhendit?",
				"Jah, palun",
				"Ei, saan ise hakkama");
			if (vastus)
			{
				await DisplayAlertAsync("Juhend",
					"Siin on sinu lühike juhend: vali menüüst sobiv teema ja uuri, kuidas elemendid töötavad!",
					"Selge");
			}

			// 3. Salvestame info, et esimene käivitamine on tehtud.
			Preferences.Default.Set("EsimeneKäivitamine", false);
		}
	}
}