using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using BannerTestApp.Models;
using BannerTestApp.Services;
using System.Windows.Input;

namespace BannerTestApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public BaseViewModel()
        {
            Message = "Hello banner";
            ActionButtonText = "Close";
            Icon = "@";
            BackgroundColor = Color.LightBlue;
            ActionButtonCommand = new Command(() => { Message = counter % 2 == 0 ? "Message 1" : "Message2"; counter++; });
        }

        int counter = 0;

        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public string ActionButtonText { get; set; }

        public string Icon { get; set; }

        public Color BackgroundColor { get; set; }

        public ICommand ActionButtonCommand { get; }
    }
}
