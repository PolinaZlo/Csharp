using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace L10C
{
    public class Valuta : INotifyPropertyChanged
    {
        private string title;
        private string code;

        public Valuta(string _title, string _code)
        {
            title = _title;
            code = _code;
        }

        public string Title
        {
            get { return title; }
            set { title = value; NotifyPropertyChanged("Title"); }
        }

        public string Code
        {
            get { return code; }
            set { code = value; NotifyPropertyChanged("Code"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]string str = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
    }
}
