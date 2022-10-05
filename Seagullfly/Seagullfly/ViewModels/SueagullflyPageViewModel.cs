using MvvmHelpers.Commands;
using Seagullfly.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Seagullfly.ViewModels
{
    public class SueagullflyPageViewModel : ViewModelBase
    {
        public SueagullflyPageViewModel()
        {
            ScrapDataCommand = new AsyncCommand(OnScrapping);
            ClearDataCommand = new Command(ClearData);
            data = "Data";
            Title = "Scrapping page";
        }

        public ICommand ScrapDataCommand { get; }
        public ICommand ClearDataCommand { get; }

        string buttonName = "Scrap data!";
        public string ButtonName
        {
            get => buttonName;
            set => SetProperty(ref buttonName, value);
        }
        string data = "Data";
        public string Data
        {
            get => data;
            set => SetProperty(ref data, value);
        }

        async Task OnScrapping()
        {
            //var requester = new HttpService();
            //var html = await requester.GetHtmlFromUrl("https://www.esky.pl/flights/select/roundtrip/ap/wro/ap/waw?departureDate=2022-09-26&returnDate=2022-09-27&pa=1&py=0&pc=0&pi=0&sc=economy");
            //Data = html;
            //ButtonName = "Data scrapped!";
        }

        void ClearData()
        {
            data = "Data cleared";
        }
    }
}
