using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Work
{
    public class MyString : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _ValueString;
        public string ValueString
        {
            get { return _ValueString; }
            set { _ValueString = value; OnPropertyChanged(nameof(ValueString)); }
        }
        public MyString(string value) 
        {
            ValueString = value;
        }
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
