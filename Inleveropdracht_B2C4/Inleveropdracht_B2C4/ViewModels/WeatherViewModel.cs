using Inleveropdracht_B2C4.Models;
using Inleveropdracht_B2C4.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Inleveropdracht_B2C4.ViewModels
{
    public class WeatherViewModel
    {
        private IList<OneCallAPI> _weatherList;
        public IList<OneCallAPI> WeatherList
        {
            get
            {
                if (_weatherList == null)
                    _weatherList = new ObservableCollection<OneCallAPI>();
                return _weatherList;
            }
            set
            {
                _weatherList = value;
            }
        }

        private async Task APIAsync()
        {
            var location = Geolocation.GetLastKnownLocationAsync();
            var weather = await WeatherAPI.GetOneCallAPIAsync(location.Result.Latitude, location.Result.Longitude, "metric");
            WeatherList.Add(weather);
        }

        public WeatherViewModel()
        {
            Task.Run(APIAsync);
        }
    }
}
