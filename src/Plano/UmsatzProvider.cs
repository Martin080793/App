using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Plano
{
    public class UmsatzProvider : IUmsatzProvider, INotifyPropertyChanged
    {
        public UmsatzProvider()
        {
            Umsätze = new List<Umsatz>();
        }
        public List<Umsatz> Umsätze { get; set; }

        public void umsatzHinzufügen(Umsatz umsatz)
        {
            Umsätze.Add(umsatz);
        }

        public void umsatzLöschen(Umsatz umsatz)
        {
            Umsätze.Remove(umsatz);
        }

        public void umsatzVerändern(Umsatz umsatz)
        {
            throw new NotImplementedException();
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
