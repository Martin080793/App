using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Plano.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IUmsatzProvider _umsatzProvider;
        private readonly IPageDialogService _pagedialogService;

        public MainPageViewModel(INavigationService navigationService, IUmsatzProvider umsatzProvider, IPageDialogService pagedialogService)
            : base(navigationService)
        {
            Title = "Main Page";
            _umsatzProvider = umsatzProvider;
            _pagedialogService = pagedialogService;
            Umsätze = new ObservableCollection<Umsatz>(_umsatzProvider.Umsätze);

            UmsatzHinzufügenCommand = new DelegateCommand(umsatzHinzufügen);
        }

        private void umsatzHinzufügen()
        {

            //_umsatzProvider.umsatzHinzufügen(new Umsatz
            //{
            //    Name = Name,
            //    Betrag = Betrag,
            //    Datum = Date
            //});
            Umsätze.Add(new Umsatz
            {
                Name = Name,
                Betrag = Betrag,
                Datum = Date
            });
        }

        public ICommand UmsatzHinzufügenCommand { get; set; }
        public ObservableCollection<Umsatz> Umsätze { get; set; }
        private Umsatz _selectedUmsatz;
        public Umsatz SelectedUmsatz
        {
            get { return _selectedUmsatz; }
            set
            {
                if (value != null)
                {
                    Name = value.Name;
                    Betrag = value.Betrag;
                    Date = value.Datum;
                }
                SetProperty(ref _selectedUmsatz, value);
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        private decimal _betrag;
        public decimal Betrag
        {
            get { return _betrag; }
            set { SetProperty(ref _betrag, value); }
        }
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }
    }
}
