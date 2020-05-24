using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using Business.Abstract.Services;
using Business.Models;

namespace ViewModel
{
    public class MainWindowVModel : INotifyPropertyChanging
    {
        private readonly IDetailService _detailService;
        private readonly ICarService _carService;
        private readonly IPlayerService _playerService;

        private CarModel Car { get; set; }
        private PlayerModel _player;

        private DetailModel _selectedDetail;
        private RelayCommand _addDetailToCar;
        
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

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
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