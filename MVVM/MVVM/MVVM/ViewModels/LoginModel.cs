using System.ComponentModel; 
using System.Windows.Input;
using Xamarin.Forms;
using MVVM.Database;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Threading.Tasks;


namespace MVVM.ViewModels
{
    public class LoginModel : INotifyPropertyChanged
    {
        string _item = string.Empty;
        ObservableCollection<ToDoItem> _ItemList = new ObservableCollection<ToDoItem>();
        public string Item { get { return _item; } set { _item = value; OnPropertyChanged("Item"); } }
        ToDoDatabase database { get; set; }
        public ObservableCollection<ToDoItem> ItemList { get { return _ItemList; } set {_ItemList = value; OnPropertyChanged("ItemList"); }}
        public ObservableCollection<ToDoItem> Items { get; set; }
        public ICommand SavekHandler { get; set; }

        public LoginModel(){            
            database = new ToDoDatabase();
            SavekHandler = new Command(SaveItemButton);
            Items = new ObservableCollection<ToDoItem>();
            ItemList = Items;
            RefreshList();
        }


        public void SaveItemButton()
        {
            if (string.IsNullOrWhiteSpace(Item))
                return;

            database.SaveItem(new ToDoItem { Name = Item });

            RefreshList();
            Item = string.Empty;
        }
        private void RefreshList()
        {
            Items.Clear();

            var items = (from i in database.GetItems<ToDoItem>() orderby i.Created select i);

            foreach (var item in items)
                Items.Add(item);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

         
    }
}
