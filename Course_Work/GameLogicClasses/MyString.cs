namespace Course_Work
{
    public class MyString : BindableObject
    {

        public MyString(string value)
        {
            ValueString = value;
        }

        private string _ValueString;
        public string ValueString
        {
            get
            {
                return _ValueString;
            }
            set
            {
                if (_ValueString != value)
                {
                    _ValueString = value;
                    OnPropertyChanged();
                }
            }
        }


    }
}
