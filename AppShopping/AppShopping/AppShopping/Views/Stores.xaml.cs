
using AppShopping.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppShopping.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Stores : ContentPage
    {
        public Stores()
        {
            InitializeComponent();
            BindingContext = new StoresViewModel();
        }
    }
}