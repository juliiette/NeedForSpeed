using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Business.Abstract.Services;
using Business.Models;

namespace ViewModel
{
    public class MainWindowVModel : INotifyPropertyChanging
    {
        private readonly ICarService _carService;
        private readonly IDetailService _detailService;
        private readonly IPlayerService _playerService;
        private RelayCommand _addDetailToCar;
        private PlayerModel _player;

        private DetailModel _selectedDetail;

        public MainWindowVModel(IDetailService detailService, ICarService carService, IPlayerService playerService)
        {
            _detailService = detailService;
            _carService = carService;
            _playerService = playerService;

            Details = new ObservableCollection<DetailModel>(detailService.GetAll());
            CarDetailsList = new ObservableCollection<DetailModel>();
            SelectedDetail = Details.FirstOrDefault();

            Car = new CarModel();
            Player = new PlayerModel {Name = "Garik", Car = Car, Cash = 1000};
        }

        private CarModel Car { get; }
        public ObservableCollection<DetailModel> Details { get; set; }
        public ObservableCollection<DetailModel> CarDetailsList { get; set; }

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


        public RelayCommand AddDetailToCar => _addDetailToCar ??= new RelayCommand(o =>
        {
            _detailService.BuyDetail(SelectedDetail, Car, Player);
            CarDetailsList.Add(SelectedDetail);
        }, o => CheckCash(SelectedDetail));

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        private bool CheckCash(DetailModel detailModel)
        {
            return _playerService.CheckCash(Player, detailModel.RetailCost);
        }


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}