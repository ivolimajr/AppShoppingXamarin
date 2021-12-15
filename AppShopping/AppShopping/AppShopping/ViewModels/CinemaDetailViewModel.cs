using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using Newtonsoft.Json;
using System;
using System.Linq;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    [QueryProperty("cinemaSerialized", "cinemaSerialized")]
    public class CinemaDetailViewModel : BaseViewModel
    {
        public Film Film { get; set; }
        public string cinemaSerialized
        {
            set
            {
                Film = JsonConvert.DeserializeObject<Film>(Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Film));
            }
        }
        public CinemaDetailViewModel()
        {
            Film = new CinemaService().GetFilms().First();
        }
    }
}
