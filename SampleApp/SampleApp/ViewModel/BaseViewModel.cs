using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleApp.ViewModel
{
    public class BaseViewModel : BindableObject
    {
        private INavigation _Navigation;
        public INavigation Navigation
        {
            get { return _Navigation; }
            set
            {
                if (_Navigation != value)
                {
                    _Navigation = value;
                    OnPropertyChanged("Navigation");
                }
            }
        }

        public bool IsInitialized { get; set; }

        public BaseViewModel(INavigation navigation = null)
        {
            try
            {
                Navigation = navigation;
            }
            catch (Exception ex)
            { }
        }
        public Acr.UserDialogs.IUserDialogs UserDialog
        {
            get
            {
                return Acr.UserDialogs.UserDialogs.Instance;
            }
        }
        public async Task PushModalAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(page);
        }

        public async Task PopModalAsync()
        {
            if (Navigation != null)
                await Navigation.PopModalAsync(false);
        }

        public async Task PushAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(page);
        }

        public async Task PopAsync()
        {
            if (Navigation != null)
                await Navigation.PopModalAsync();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }
    }
}
