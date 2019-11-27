using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MenuApp.ViewModels
{
    public class BaseViewModel<T> : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MobileEXPApp.ViewModels.BaseViewModel`1"/> class.
        /// </summary>
        /// <param name="model">model</param>
        public BaseViewModel(T model)
        {
            Model = model;
        }

        /// <summary>
        /// the model of this view model
        /// </summary>
        public T Model
        {
            get => model;
            set => SetProperty(ref model, value);
        }
        private T model;
    }

    /// <summary>
    /// a base view model for a page
    /// </summary>
    public class BasePageViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MobileEXPApp.ViewModels.BasePageViewModel"/> class.
        /// </summary>
        /// <param name="title">title of this page</param>
        public BasePageViewModel(string title)
        {
            Title = title;
        }

        /// <summary>
        /// title of this page
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        string title = string.Empty;
    }

    /// <summary>
    /// base class for view models
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
