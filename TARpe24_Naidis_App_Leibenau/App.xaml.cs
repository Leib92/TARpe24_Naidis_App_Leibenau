using Microsoft.Extensions.DependencyInjection;

namespace TARpe24_Naidis_App_Leibenau
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new AppShell());
        }
    }
}