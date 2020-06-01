using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Business.Models
{
    public class CarModel : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public DetailModel Motor { get; set; }

        public DetailModel Rim { get; set; }

        public DetailModel Battery { get; set; }

        private int _distance;
        public int Distance
        {
            get => _distance;
            set
            {
                _distance = value;
                OnPropertyChanged(nameof(Distance));
            }
        }

        private bool canRide;
        public bool CarRide
        {
            get => canRide;
            set
            {
                canRide = value;
                OnPropertyChanged(nameof(CarRide));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}