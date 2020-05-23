using System.Windows;
using ViewModel;

namespace View
{
    public partial class GameWindow : Window
    {

        public GameWindow()
        {
            InitializeComponent();


            DataContext = App.DependencyResolver.GetService(typeof(MainWindowVModel));
        }
    }
}
