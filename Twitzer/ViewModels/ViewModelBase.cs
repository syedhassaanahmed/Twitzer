using System;
using System.ComponentModel;
using System.Threading;

namespace Twitzer.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public static SynchronizationContext Context { private get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propertyName)
        {
            if(PropertyChanged != null)
                InvokeOnSynchronizationContext(() => PropertyChanged(this, new PropertyChangedEventArgs(propertyName)));
        }

        static void InvokeOnSynchronizationContext(Action action)
        {
            if (Context == SynchronizationContext.Current)
                action();
            else
                Context.Post(a => action(), null);
        }
    }
}
