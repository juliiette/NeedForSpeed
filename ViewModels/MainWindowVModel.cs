﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Policy;
using Business.Abstract.Services;
using Business.Models;

namespace ViewModel
{
    public partial class MainWindowVModel : INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        private readonly IDetailService _detailService;
        private readonly ICarService _carService;

        public ObservableCollection<DetailModel> Details { get; set; }
        public ObservableCollection<DetailModel> Car { get; set; }

        private CarModel car;
        private PlayerModel player;
       

        private DetailModel selectedDetail;
        public DetailModel SelectedDetail
        {
            get { return selectedDetail; }
            set { selectedDetail = value;
                OnPropertyChanged(nameof(SelectedDetail));
            }
        }

        private DetailModel addDetailToCar;
        public DetailModel AddDetailToCar
        {
            get { return selectedDetail; }
            set
            {
                addDetailToCar = value;
                OnPropertyChanged(nameof(AddDetailToCar));
                _detailService.BuyDetail(addDetailToCar, car, player);
                Car.Add(addDetailToCar);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainWindowVModel(IDetailService detailService, ICarService carService)
        {
            _detailService = detailService;
            _carService = carService;

            Details = new ObservableCollection<DetailModel>(detailService.GetAll());
            Car = new ObservableCollection<DetailModel>();
            
            player = new PlayerModel();
            player.Name = "Garik";
            player.Car = car;
            player.Cash = 1000;

        }


    }
}
