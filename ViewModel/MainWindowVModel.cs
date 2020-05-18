using System.Collections.ObjectModel;
using System.ComponentModel;
using Business.Abstract.Services;
using Business.Models;

namespace ViewModel
{
    public partial class MainWindowVModel : INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        private readonly IDetailService detailService;
        private readonly ICarService carService;
        private readonly IPlayerService playerService;

        public ObservableCollection<DetailModel> Details { get; set; }
        public ObservableCollection<CarModel> Cars { get; set; }
        public ObservableCollection<PlayerModel> Players { get; set; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private RelayCommand addCommand;
    }
}
