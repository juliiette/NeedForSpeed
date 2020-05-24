using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Business.Models
{
    public class PlayerModel : INotifyPropertyChanged
    {
        private int _cash;

        public int Id { get; set; }

        public string Name { get; set; }

        public CarModel Car { get; set; }

        public int Cash
        {
            get => _cash;
            set
            {
                _cash = value;
                OnPropertyChanged(nameof(Cash));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}