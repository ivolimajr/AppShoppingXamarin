using AppShopping.Libraries.Enums;
using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    public class StoresViewModel : BaseViewModel
    {
        public String SearchWord { get; set; }
        public ICommand SearchCommand { get; set; }

        private List<Establishment> _stablishments;
        public List<Establishment> Establishments
        {
            get
            {
                return _stablishments;
            }
            set
            {
                SetProperty(ref _stablishments, value);
            }
        }
        private List<Establishment> _allEstablishments { get; set; }

        public StoresViewModel()
        {
            SearchCommand = new Command(Search);
            init();
        }

        private void init()
        {
            var stores = new EstablishmentService().GetEstablishments();
            var allStores = stores.Where(e => e.Type == EstablishmentType.STORE).ToList();
            Establishments = allStores;
            _allEstablishments = allStores;
        }

        private void Search()
        {
            Establishments = _allEstablishments.Where(e => e.Name.ToLower().Contains(SearchWord.ToLower())).ToList();
        }
    }
}
