using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MenuApp.ViewModels
{
    public class BaseViewModel<T> : BaseViewModel
    {
        /// <summary>
        /// initialise une nouvelle instance de la classe BaseViewModel.
        /// </summary>
        /// <param name="model">model</param>
        public BaseViewModel(T model)
        {
            Model = model;
        }

        /// <summary>
        /// le model du ViewModel
        /// </summary>
        public T Model
        {
            get => model;
            set => SetProperty(ref model, value);
        }
        private T model;
    }

    /// <summary>
    /// un BaseViewModel pour une page
    /// </summary>
    public class BasePageViewModel : BaseViewModel
    {
        /// <summary>
        /// initialise une nouvelle instance de la classe BasePageViewModel
        /// </summary>
        /// <param name="title">titre de la page</param>
        public BasePageViewModel(string title)
        {
            Title = title;
        }

        /// <summary>
        /// titre de la page
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        string title = string.Empty;
    }

    /// <summary>
    /// classe de base pour un ViewModel
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
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
    }
}
