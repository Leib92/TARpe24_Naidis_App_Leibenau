using Android.App;

namespace TARpe24_Naidis_App_Leibenau;

public partial class PopUpPage : ContentPage
{
	public PopUpPage()
	{
		// 1. Loome esimese nupu (Lihtne teade)
		Button alertButton = new Button
		{
			Text = "Teade",
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.Center
		};
		// Seome nupu klikkimise sündmuse funktsiooniga
		alertButton.Clicked += AlertButton_Clicked;

		// 2. Loome teise nupu (Kinnitus)
		Button alertYesNoButton = new Button
		{
			Text = "Jah või ei",
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.Center
		};
		alertYesNoButton.Clicked += AlertYesNoButton_Clicked;

		// 3. Loome kolmanda nupu (Valikumenüü)
		Button alertListButton = new Button
		{
			Text = "Valik",
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.Center
		};
		alertListButton.Clicked += AlertListButton_Clicked;

		// 4. Paigutame kõik nupud ekraanile üksteise alla
		Content = new VerticalStackLayout
		{
			Spacing = 20, // Jätab nuppude vahele 20 pikslit vaba ruumi
			Padding = new Thickness(0, 50, 0, 0), // Lükkab sisu veidi ülevalt alla
			Children = { alertButton, alertYesNoButton, alertListButton }
		};


		// Loob alerQuest
		Button alertQuestButton = new Button
		{
			Text = "Küsimus",
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.Center
		};
		alertQuestButton.Clicked += AlertQuestButton_Clicked;
		Content = new StackLayout
		{
			Children = { alertButton, alertYesNoButton, alertListButton, alertQuestButton }
		};

		// Loome punase testnupu
		Button nulliNupp = new Button
		{
			Text = "Nulli seaded (Testimiseks)",
			BackgroundColor = Colors.Red,
			TextColor = Colors.White,
			CornerRadius = 10,
			HeightRequest = 50,
			Margin = new Thickness(0, 30, 0, 0) // Jätame veidi tühja ruumi üles
		};

		// Mis juhtub nupule vajutades?
		nulliNupp.Clicked += async (sender, e) =>
		{
			// Kustutame seadme mälust meie spetsiifilise võtme
			Preferences.Default.Remove("EsimeneKäivitamine");

			// Anname tagasisidet, et nullimine õnnestus
			await DisplayAlertAsync("Edukalt nullitud", "Mälu on tühjendatud. Kui sa lege uuesti avad, käitub äpp nagu täiesti uus!", "OK")
		};

		// Layout Nupp
		vst.Add(nulliNupp);
		sv = new ScrollView { Content = vst };
		Content = sv;
	}

	// 1. Nupp: Lihtne teade
	private async void AlertButton_Clicked(object? sender, EventArgs e)
	{
		// Kuvab lihtsalt teate ja ootab, kuni kasutaja vajutab "OK"
		await DisplayAlertAsync("Teade", "Teil on uus teade", "OK");
	}

    // 2. Nupp: Lihtne teade
    private async void AlertYesNoButton_Clicked(object? sender, EventArgs e)
    {
		// Küsime kasutajalt kinnitust (tagastab true või false)
		bool result = await DisplayAlertAsync("Kinnitus", "Kas oled kindel?", "Olen kindel", "Ei ole kindel");

		// Kubame uue teate vastavalt sellele, mida kasutaja valis
		// (result ? "Jah" : "Ei") tähendab: kui result on true, kirjuta "Jah", muidu "Ei".
		await DisplayAlertAsync("Teade", "Teie valik on: " + (result ? "Jah" : "Ei"), "OK");
    }

    // 3. Nupp: Lihtne teade
    private async void AlertListButton_Clicked(object? sender, EventArgs e)
    {
		// Kuvab menüü ja salvestab kasutaja valitud teksti muutujasse 'action'
		string action = await DisplayActionSheetAsync("Mida teha?", "Loobu", "Kustutada", "Tantsida", "Laulda", "Joonestada");

		// Kontrollime, et kasutaja ei vajutanud lihtsalt kõrvale ega valinud "Loobu"
		if (action != null && action != "Loobu")
		{
			await DisplayAlertAsync("Valik", "Sa valisid tegevuse: " + action, "OK");
		}
    }

	// Valikvastusega
	private async void AlertQuestButton_Clicked(object sender, EventArgs e)
	{
		string result1 = await DisplayPromptAsync("Küsimus", "Kuidas läheb", placeholder: "Tore!");
		string result2 = await DisplayPromptAsync("Vasta", "Millega võrdub 5 + 5", initialValue: "10", maxLength: 2, keyboard: Keyboard.Numeric);
	}
}