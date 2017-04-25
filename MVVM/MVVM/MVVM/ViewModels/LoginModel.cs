using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using MVVM.Services;
using MVVM.Contracts;
using MVVM.Common;
using System.Collections.Generic;  
using System.Threading.Tasks; 


namespace MVVM.ViewModels
{

    public class LoginModel : INotifyPropertyChanged
    {
        public List<Student> stud { get; set; } 
        IRestSarvice restService { get;set; } 

        public ICommand HandleApiCall { get; set; }

        public LoginModel(){
            restService = new RestSarvice();
            HandleApiCall = new Command(ApiCall);
        }

        async void ApiCall()
        {
            string url = Constants.ApiUrl + "/posts";
            stud = await restService.Get<Student>(url, null);
            OnPropertyChanged("stud");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

         
    }
}
