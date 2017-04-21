using System;
using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace MVVM.Database
{
    public class ToDoDatabase : ContentPage
    {
        SQLiteConnection Connection { get; }
        public static string Root { get; set; } = string.Empty;

        public ToDoDatabase()
        {
            try
            {
                var location = "tododb.db3";
                location = System.IO.Path.Combine(Root, location);
                Connection = new SQLiteConnection(location);
                Connection.CreateTable<ToDoItem>();
            }
            catch (Exception ex)
            {
                DisplayAlert("Alert", ex.Message, "OK");
            }
        }


        public T GetItem<T>(int id) where T : IBusinessEntity, new()
        {
            try
            {

                return (from i in Connection.Table<T>()
                        where i.Id == id
                        select i).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DisplayAlert("Alert", ex.Message, "OK");
            }
            return new T();
        }

        public IEnumerable<T> GetItems<T>() where T : IBusinessEntity, new()
        {
            try
            {
                return (from i in Connection.Table<T>()
                        select i);
            }
            catch (Exception ex)
            {
                DisplayAlert("Alert", ex.Message, "OK");
            }
            return null;
        }

        public int SaveItem<T>(T item) where T : IBusinessEntity
        {
            try
            {
                if (item.Id != 0)
                {
                    Connection.Update(item);
                    return item.Id;
                }

                return Connection.Insert(item);
            }
            catch (Exception ex)
            {
                DisplayAlert("Alert", ex.Message, "OK");
            }
            return 0;
        }

        public void SaveItems<T>(IEnumerable<T> items) where T : IBusinessEntity
        {
            try
            {
                Connection.BeginTransaction();

                foreach (T item in items)
                {
                    SaveItem(item);
                }

                Connection.Commit();
            }
            catch (Exception ex)
            {
                DisplayAlert("Alert", ex.Message, "OK");
            }

        }

        public int DeleteItem<T>(T item) where T : IBusinessEntity, new()
        {
            try { 
                return Connection.Delete(item);
            }
            catch (Exception ex)
            {
                DisplayAlert("Alert", ex.Message, "OK");
            }
            return 0;
        }
    }
}
