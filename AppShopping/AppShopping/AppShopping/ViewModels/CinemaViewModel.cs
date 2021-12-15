using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    public class CinemaViewModel : BaseViewModel
    {
        public List<Film> Films { get; set; }
        public ICommand DetailCommand { get; set; }

        public CinemaViewModel()
        {
            Films = new CinemaService().GetFilms();
            DetailCommand = new Command<Film>(Detail);
        }

        private void Detail(Film film)
        {
            string cinemaSerialized = JsonConvert.SerializeObject(film);
            Shell.Current.GoToAsync($"cinema/detail?cinemaSerialized={Uri.EscapeDataString(cinemaSerialized)}");
        }
    }
}
