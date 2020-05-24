using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Policy;
using Business.Abstract.Services;
using Business.Models;

namespace ViewModel
{
    public partial class MainWindowVModel : INotifyPropertyChanging
    {
        private readonly IDetailService _detailService;
        private readonly ICarService _carService;
     
        private CarModel _car;
        private PlayerModel _player;

        private DetailModel _selectedDetail;
        private DetailModel _addDetailToCar;
        
        public MainWindowVModel(IDetailService detailService, ICarService carService)
        {
            _detailService = detailService;
            _carService = carService;

            Details = new ObservableCollection<DetailModel>(detailService.GetAll());
            Car = new ObservableCollection<DetailModel>();

            var player = new PlayerModel();
            player.Name = "Garik";
            player.Car = _car;
            player.Cash = 1000;
            Player = player;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
        public ObservableCollection<DetailModel> Details { get; set; }
        public ObservableCollection<DetailModel> Car { get; set; }

        public PlayerModel Player
        {
            get => _player;
            set
            {
                _player = value;
                OnPropertyChanged("Player");
            }
        }

        public DetailModel SelectedDetail
        {
            get => _selectedDetail;
            set
            {
                _selectedDetail = value;
                OnPropertyChanged(nameof(SelectedDetail));
            }
        }



        public DetailModel AddDetailToCar
        {
            get => _selectedDetail;
            set
            {
                _addDetailToCar = value;
                OnPropertyChanged(nameof(AddDetailToCar));
                _detailService.BuyDetail(_addDetailToCar, _car, _player);
                Car.Add(_addDetailToCar);
            }
        }
        

        
        
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}