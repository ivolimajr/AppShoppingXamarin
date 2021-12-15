
using AppShopping.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppShopping
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : Shell
    {
        public Menu()
        {
            InitializeComponent();
            Routing.RegisterRoute("establishment/detail", typeof(EstablishmentDetail));
            Routing.RegisterRoute("cinema/detail", typeof(CinemaDetail));
        }
    }
}