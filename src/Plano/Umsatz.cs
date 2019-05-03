using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Plano
{
    public class Umsatz : INotifyPropertyChanged
    {
        public Umsatz()
        {
            
        }
        public Umsatz(Guid guid)
        {
            SerienID = guid;
        }
        public decimal Betrag { get; set; }
        public string Name { get; set; }
        public DateTime Datum { get; set; }
        public string Notizen { get; set; }
        public Guid SerienID { get; set; }
        public List<string> Tags { get; set; }

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
