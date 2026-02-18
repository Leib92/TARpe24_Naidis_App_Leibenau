using Microsoft.Maui.Controls.Shapes;
using System.Security.Cryptography.X509Certificates;
using static AndroidX.ConstraintLayout.Core.Motion.Utils.HyperSpline;

namespace TARpe24_Naidis_App_Leibenau;

public partial class ValgusfoorPage : ContentPage
{
    BoxView boxView;
    Ellipse pall;
    Polygon kolmnurk;
    Random rnd = new Random();
    HorizontalStackLayout hsl;
    List<string> nupud = new List<string>() { "Tagasi", "Avaleht", "Edasi" };
    VerticalStackLayout vsl;

    public ValgusfoorPage()
	{
        int r = rnd.Next(256);
        int g = rnd.Next(256);
        int b = rnd.Next(256);
        boxView = new BoxView
        {
            Color = Color.FromRgb(r, g, b),
            WidthRequest = 200,
            HeightRequest = 200,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Color.FromRgba(0, 0, 0, 0),//teeb ta läbipaistvaks, et saaks ta peale teksti panna
            CornerRadius = 30,
        };

    }

	public async Task TeeAnimatsioon(View element)
	{
		await Task.WhenAll(
			element.ScaleTo(1.2, 150),
			element.FadeTo(0.5, 150)
		);

        await Task.WhenAll(
            element.ScaleTo(1.0, 150),
            element.FadeTo(1.0, 150)
        );
    }
}