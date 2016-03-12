using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Twitzer.Core;

namespace Twitzer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        static readonly TwitzerRequest Request = new TwitzerRequest();

        bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading;}
            private set
            {
                _isLoading = value;
                Notify(nameof(IsLoading));
            }
        }

        bool _isEmpty;
        public bool IsEmpty
        {
            get { return _isEmpty; }
            private set
            {
                _isEmpty = value;
                Notify(nameof(IsEmpty));
            }
        }

        public IncrementalLoadingCollection<TwitzViewModel> Twitzes { get; private set; }

        public MainViewModel()
        {
            ClearTwitzes();
        }

        async Task<List<TwitzViewModel>> LoadTwitzesAsync()
        {
            IsLoading = true;

            try
            {
                var result = (await Request.RunAsync())
                    .Select(x => new TwitzViewModel(x))
                    .Where(x => !string.IsNullOrWhiteSpace(x.Text)).ToList();

                IsEmpty = !result.Any();

                return result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                IsEmpty = true;
                return new List<TwitzViewModel>();
            }
            finally
            {
                IsLoading = false;
            }
        }

        public void ClearTwitzes()
        {
            Twitzes = new IncrementalLoadingCollection<TwitzViewModel>(LoadTwitzesAsync);
        }
    }
}
