using MVVM.ViewModels;

namespace MVVM.View
{
    public partial class ToDoList
    {
        public ToDoList()
        {
            InitializeComponent();
            this.BindingContext = new ToDoModel();
        }
    }
}
