using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Business.Abstract.Services;
using Business.Models;

namespace ViewModel
{
    public class MainWindowVModel : INotifyPropertyChanging
    {
        private readonly ICarService _carService;
        private readonly IDetailService _detailService;
        private readonly IPlayerService _playerService;
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
            Player = new PlayerModel { Name = "Garik", Car = Car, Cash = 1000 };
        }

        private CarModel Car { get; }
        public ObservableCollection<DetailModel> Details { get; set; }

        private ObservableCollection<DetailModel> carDetailsList;
        public ObservableCollection<DetailModel> CarDetailsList
        {
            get => carDetailsList;
            set
            {
                carDetailsList = value;
                OnPropertyChanged("CarDetailsList");
            }
        }

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

        private RelayCommand _addDetailToCar;
        public RelayCommand AddDetailToCar => _addDetailToCar ??= new RelayCommand(o =>
        {
            var newDetailsList = CarDetailsList.ToList<DetailModel>();
            foreach (DetailModel detail in newDetailsList)
            {
                if (detail.DetailType == SelectedDetail.DetailType)
                {
                    _detailService.SellDetail(detail, Car, Player);
                    newDetailsList.Remove(detail);
                    CarDetailsList.Remove(detail);
                }
                break;
            }
            _detailService.BuyDetail(SelectedDetail, Car, Player);
            CarDetailsList.Add(SelectedDetail);

        }, o => CheckCash(SelectedDetail));


        private RelayCommand _sellDetail;
        public RelayCommand SellDetail => _sellDetail ??= new RelayCommand(o =>
        {
            _detailService.SellDetail(SelectedDetail, Car, Player);
            CarDetailsList.Remove(SelectedDetail);
        }, o => CheckCash(SelectedDetail));


        private RelayCommand _rideCommand;
        public RelayCommand RideCommand => _rideCommand ??= new RelayCommand(o =>
        {
            if (CarDetailsList.Count == 3)
            {
                _carService.CollectCar(Car, Player);
            }
            else
            {
                MessageBox.Show("I have no needed details :(");
            }
        });


        private RelayCommand _repairCommand;
        public RelayCommand RepairCommand => _repairCommand ??= new RelayCommand(o =>
        {
            if (SelectedDetail.CanFunction == false)
            {
                _detailService.RepairDetail(SelectedDetail, Car, Player);
            }
        });


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