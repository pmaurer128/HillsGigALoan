using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GigaLoan_Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Newtonsoft.Json;
namespace GigALoanWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<DTO_College> _Colleges;
        private ObservableCollection<DTO_CORE_GigAlert> _Alerts;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public ObservableCollection<DTO_College> Colleges
        {
            get { return _Colleges; }
            set
            {
                _Colleges = value;
                OnPropertyChanged("Colleges");
            }
        }
        public MainWindow()
        {
            
            InitializeComponent();

            
            DataContext = this;
            GetData();
            
        }

        async void GetData()
        {
            
            ServiceLayer sl = new ServiceLayer();

            await sl.GetAlert();
            Alerts = new ObservableCollection<DTO_CORE_GigAlert>(sl.alerts);
            //await sl.GetCollege();

            //Colleges = new ObservableCollection<DTO_College>(sl.colleges);
            
        }

        public ObservableCollection<DTO_CORE_GigAlert> Alerts
        {
            get { return _Alerts; }
            set
            {
                _Alerts = value;
                OnPropertyChanged("Alerts");
            }
        }
    }
}
