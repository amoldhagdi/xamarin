using System.ComponentModel; 
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM.ViewModels
{
    public class LoginModel : INotifyPropertyChanged
    {
        private string _msg;
        public string Msg {
            get { return _msg; }
            set
            {
                _msg = value;
                OnPropertyChanged("Msg");
            }
        }
        public ICommand ClickHandler { get; set; }

        public LoginModel(){
            Msg = "This is text msg";
            ClickHandler = new Command(ClickHandler1);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ClickHandler1() {
            Msg = "you change the text";
        }

    }
}
