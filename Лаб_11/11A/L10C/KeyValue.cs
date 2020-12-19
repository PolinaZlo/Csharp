using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace L10C
{
    public class KeyValue : INotifyPropertyChanged
    {
        private string key;
        private double currency;

        public KeyValue(string _key, double _currency)
        {
            key = _key;
            currency = _currency;
        }

        public string Key
        {
            get { return key; }
            set { key = value; NotifyPropertyChanged("Key"); }
        }

        public double Currency
        {
            get { return currency; }
            set { currency = value; NotifyPropertyChanged("Currency"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]string str = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
    }
}
