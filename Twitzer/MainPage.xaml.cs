// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

using System;
using Windows.UI.Xaml;
using Twitzer.Strings;
using Twitzer.ViewModels;

namespace Twitzer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        MainViewModel ViewModel { get; }

        public readonly LocalizedStrings Strings = new LocalizedStrings();

        public MainPage()
        {
            InitializeComponent();
            ViewModel = (MainViewModel)DataContext;
            Loaded += MainPage_Loaded;
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await TwitzList.LoadMoreItemsAsync();
        }

        async void OnRefreshClicked()
        {
            TwitzList.ItemsSource = null;
            ViewModel.ClearTwitzes();
            TwitzList.ItemsSource = ViewModel.Twitzes;
            await TwitzList.LoadMoreItemsAsync();
        }

        async void OnTwitzSelected()
        {
            if (TwitzList.SelectedItem == null)
                return;

            var twitzViewModel = (TwitzViewModel)TwitzList.SelectedItem;
            await twitzViewModel.ShowInBrowserAsync();
        }
    }
}
