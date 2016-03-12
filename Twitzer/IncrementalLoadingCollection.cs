using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Twitzer
{
    public class IncrementalLoadingCollection<T> : ObservableCollection<T>, ISupportIncrementalLoading
        where T : INotifyPropertyChanged
    {
        readonly Func<Task<List<T>>> _onLoadMoreItems;

        public bool HasMoreItems { get; private set; }

        public IncrementalLoadingCollection(Func<Task<List<T>>> onLoadMoreItems)
        {
            _onLoadMoreItems = onLoadMoreItems;
            HasMoreItems = true;
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            var dispatcher = Window.Current.Dispatcher;

            return Task.Run(async () =>
            {
                var items = await _onLoadMoreItems();

                HasMoreItems = items.Any();

                if (!HasMoreItems)
                    return new LoadMoreItemsResult();

                await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    foreach (var item in items)
                        Add(item);
                });

                return new LoadMoreItemsResult { Count = (uint)items.Count };

            }).AsAsyncOperation();
        }
    }
}
