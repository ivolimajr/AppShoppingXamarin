using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using System.Linq;

namespace AppShopping.ViewModels
{
    public class EstablishmentDetailViewModel : BaseViewModel
    {
        public Establishment Establishment { get; set; }
    
        public EstablishmentDetailViewModel()
        {
            Establishment = new EstablishmentService().GetEstablishments().First();
        }
    }
}
