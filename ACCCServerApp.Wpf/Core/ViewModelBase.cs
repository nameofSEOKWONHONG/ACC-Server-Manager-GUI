using ACCServerApp.Shard;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ACCServerApp.Wpf.Core
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private LanguageResource _languageResource = LanguageHandler.Instance["ko-KR"];
        public LanguageResource LanguageResource { 
            get
            {
                return _languageResource;
            }
            set 
            {
                _languageResource = value;
                OnPropertyChanged("LanguageResource");
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool Set<T>(ref T field, T newValue = default(T), [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return false;
            }

            field = newValue;

            this.OnPropertyChanged(propertyName);

            return true;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
