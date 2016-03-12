using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.System;
using Twitzer.Core.Models;
using Twitzer.Strings;

namespace Twitzer.ViewModels
{
    public class TwitzViewModel : ViewModelBase
    {
        readonly Twitz _twitz;

        static readonly LocalizedStrings Strings = new LocalizedStrings();

        public string UserName => _twitz.user;

        public string Date => TryParseDate(_twitz.date);

        public string Text => CleanText(_twitz.text);

        public string ImageUrl => TryParseImageUrl(_twitz.img);

        public TwitzViewModel(Twitz twitz)
        {
            if(twitz == null)
                throw new ArgumentNullException(nameof(twitz));

            _twitz = twitz;
        }

        static string TryParseDate(string date)
        {
            var dateTime = new DateTime(1970, 1, 1);

            long seconds;
            if (long.TryParse(date, out seconds))
                dateTime = dateTime.AddSeconds(seconds);

            return dateTime.Date == DateTime.Today ? Strings.TodayDate : dateTime.ToString("MMM dd");
        }

        static string CleanText(string text)
        {
            var markupIndex = text.IndexOf("\">", StringComparison.OrdinalIgnoreCase);
            if (markupIndex > -1)
                text = text.Substring(markupIndex + 2);

            return new string(text.Take(140).ToArray()).Trim(' ', '\n');
        }

        static string TryParseImageUrl(string imgUrl)
        {
            Uri uri;
            return Uri.TryCreate(imgUrl, UriKind.Absolute, out uri) ? imgUrl : "Assets/DefaultAvatar.png";
        }

        public async Task ShowInBrowserAsync()
        {
            Uri uri;
            if (Uri.TryCreate(_twitz.url, UriKind.Absolute, out uri))
                await Launcher.LaunchUriAsync(uri);
        }
    }
}
