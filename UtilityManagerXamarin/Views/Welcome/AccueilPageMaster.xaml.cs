using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UtilityManagerXamarin.Views.Welcome
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccueilPageMaster : ContentPage
    {
        public ListView ListView;

        public AccueilPageMaster()
        {
            InitializeComponent();

            BindingContext = new AccueilPageMasterViewModel();
            ListView = ListViewMenu;
        }

        class AccueilPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<AccueilPageMenuItem> MenuItems { get; set; }
            
            public AccueilPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<AccueilPageMenuItem>(new[]
                {
                    new AccueilPageMenuItem { Id = 0, Title = "Organisation", Icon = "login.png", TargetType = typeof(Organisation)},
                    new AccueilPageMenuItem { Id = 1, Title = "Shop", Icon = "UMLOGO.png", TargetType = typeof(Organisation) },
                    new AccueilPageMenuItem { Id = 2, Title = "Employees", Icon = "login.png", TargetType = typeof(Organisation) },
                    new AccueilPageMenuItem { Id = 3, Title = "Sales", Icon = "login.png", TargetType = typeof(Organisation) },
                    new AccueilPageMenuItem { Id = 4, Title = "Stocks", Icon = "login.png", TargetType = typeof(Organisation) },
                    new AccueilPageMenuItem { Id = 5, Title = "Statistics", Icon = "login.png", TargetType = typeof(Organisation) },
                    new AccueilPageMenuItem { Id = 6, Title = "Settings", Icon = "login.png", TargetType = typeof(Organisation) },
                    new AccueilPageMenuItem { Id = 7, Title = "Finances", Icon = "login.png", TargetType = typeof(Organisation) },
                    new AccueilPageMenuItem { Id = 8, Title = "Browse", Icon = "login.png", TargetType = typeof(Organisation) },
                    new AccueilPageMenuItem { Id = 9, Title = "About", Icon = "login.png", TargetType = typeof(Organisation) },
                    new AccueilPageMenuItem { Id = 10, Title = "LogOut", Icon = "login.png", TargetType = typeof(Organisation) },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}