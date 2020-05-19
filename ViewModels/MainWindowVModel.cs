using System.Collections.ObjectModel;
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
        private readonly IPlayerService _playerService;

        //public ObservableCollection<DetailModel> Motors { get; set; }
        //public ObservableCollection<DetailModel> Rims { get; set; }
        //public ObservableCollection<DetailModel> Batteries { get; set; }
        public ObservableCollection<DetailModel> Details { get; set; }
        public ObservableCollection<DetailModel> Car { get; set; }

        private CarModel car;

        private DetailModel selectedDetail;
        public DetailModel SelectedDetail
        {
            get { return selectedDetail; }
            set { selectedDetail = value;
                OnPropertyChanged(nameof(SelectedDetail));
            }
        }

   

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainWindowVModel(IDetailService detailService, ICarService carService, IPlayerService playerService)
        {
            _detailService = detailService;
            _carService = carService;
            _playerService = playerService;

            Details = new ObservableCollection<DetailModel>(detailService.GetAll());
            Car = new ObservableCollection<DetailModel>();
            //Motors = new ObservableCollection<DetailModel>(detailService.GetSpecial(DetailType.Motor));
            //Rims = new ObservableCollection<DetailModel>(detailService.GetSpecial(DetailType.Rim));
            //Batteries = new ObservableCollection<DetailModel>(detailService.GetSpecial(DetailType.Battery));

        }
    }
}
