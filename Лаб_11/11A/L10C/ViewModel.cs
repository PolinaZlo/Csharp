using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace L10C
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Valuta selectedValuta;

        public ViewModel()
        {
            KeyValueCollection = new ObservableCollection<KeyValue>();
            ValutaCollection = new ObservableCollection<Valuta>();
        }

        public ObservableCollection<KeyValue> KeyValueCollection { get; }

        public ObservableCollection<Valuta> ValutaCollection { get; }

        public Valuta SelectedValuta
        {
            get { return selectedValuta; }
            set { selectedValuta = value; NotifyPropertyChanged("SelectedValuta"); }
        }

        public void AddKeyValue(string key, double value) => KeyValueCollection.Add(new KeyValue(key, value));

        public void AddValuta(string _title, string _code) => ValutaCollection.Add(new Valuta(_title, _code));

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]string str = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
    }
}
