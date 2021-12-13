using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using Newtonsoft.Json;
using System;
using System.Linq;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    [QueryProperty("establishmentSerialized", "establishmentSerialized")]
    public class EstablishmentDetailViewModel : BaseViewModel
    {
        public Establishment Establishment { get; set; }
        public string establishmentSerialized
        {
            set
            {
                Establishment = JsonConvert.DeserializeObject<Establishment>(Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Establishment));
            }
        }
        public EstablishmentDetailViewModel()
        {
            Establishment = new EstablishmentService().GetEstablishments().First();
        }
    }
}
