namespace TARpe24_Naidis_App_Leibenau;

public partial class TablePage : ContentPage
{
	TableView tableview;
	SwitchCell sc;
	ImageCell ic;
	TableSection fotosection;

	public TablePage()
	{
		sc = new SwitchCell { Text = "Näita veel" };
		sc.OnChanged += Sc_OnChanged;
		ic = new ImageCell
		{
			ImageSource = ImageSource.FromFile("bob.jpg"),
			Text = "Foto nimetus",
			Detail = "Foto kirjeldus"
		};

        fotosection = new TableSection("Kontaktandmed:")
        {
            new EntryCell
            {
                Label = "Telefon",
                Placeholder = "Sisesta tel. number",
                Keyboard = Keyboard.Telephone
            },
            new EntryCell
            {
                Label = "Email",
                Placeholder = "Sisesta email",
                Keyboard = Keyboard.Email
            },
            sc
        };

        Content = tableview;
    }

    private void Sc_OnChanged(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            fotosection.Title = "Foto";
            fotosection.Add(ic);
            sc.Text = "Peida";
        }
        else
        {
            fotosection.Title = "";
            fotosection.Remove(ic);
            sc.Text = "Näita veel";
        }
    }

}