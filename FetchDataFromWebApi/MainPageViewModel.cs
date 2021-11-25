using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FetchDataFromWebApi
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            GetEmployees();
        }

        public async void GetEmployees()
          {
            using (var client = new HttpClient())
            {
                // send a GET request              
                var uri = "http://localhost:3005/api/Masters/GetEmployees";

                var result = await client.GetStringAsync(uri);            
                var EmployeeList = JsonConvert.DeserializeObject<List<Employee>>(result);
                Employees = new ObservableCollection<Employee>(EmployeeList);
                IsRefreshing = false;
            }
        }

        public Command RefreshData
        {
            get
            {
                return new Command(() =>
                {
                    GetEmployees();
                });
            }
        }

        bool _isRefreshing;
        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
    }
}
