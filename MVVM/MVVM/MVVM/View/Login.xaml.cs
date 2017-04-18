using MVVM.ViewModels;
using Xamarin.Forms;

namespace MVVM.View
{
    public partial class Login
    {
        public Login()
        {
            InitializeComponent();
            this.BindingContext = new LoginModel();
        }
    }
}
