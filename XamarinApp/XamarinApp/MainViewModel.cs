using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }
        private Page _page;

        public MainViewModel(Page page) 
        {
            _page = page;
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private List<Offer> _offers;
        public List<Offer> Offers
        {
            get { return _offers; }
            set
            {
                _offers = value;
                OnPropertyChanged("Offers");
            }
        }

        private Offer _selectOffer;
        public Offer SelectOffer
        {
            get { return _selectOffer; }
            set
            {
                _selectOffer = value;
                if (_selectOffer != null)
                    OpenOffer();
                OnPropertyChanged("SelectOffer");
            }
        }

        public async Task GetOffers()
        {
            //try
            //{
            //    HttpClient httpClient = new HttpClient();
            //    var answer = await httpClient.GetAsync("http://partner.market.yandex.ru/pages/help/YML.xml");
            //    answer.EnsureSuccessStatusCode();
            //    var response = await answer.Content.ReadAsByteArrayAsync();
            //    XmlDocument xDoc = new XmlDocument();
            //    var responseStr = Encoding.GetEncoding(1251).GetString(response);
            //    xDoc.LoadXml(responseStr);
            //    var xNodeOffer = xDoc.DocumentElement.SelectSingleNode("shop").SelectSingleNode("offers");

            //    var list = new List<Offer>();

            //    foreach (XmlNode node in xNodeOffer)
            //    {
            //        string jsonText = JsonConvert.SerializeXmlNode(node, Newtonsoft.Json.Formatting.Indented);

            //        list.Add(new Offer { Id = node.Attributes.GetNamedItem("id").Value, JsonConent = jsonText });
            //    }

            //    Offers = list;
            //}
            //catch(HttpRequestException)
            //{
            //    _page.DisplayAlert("Error", "No response from the server", "Ok");
            //}

            IEnumerable<Offer> offers = await OfferService.Get();

            while (Offers.Any())
                Offers.RemoveAt(Offers.Count - 1);

            // добавляем загруженные данные
            foreach (Offer f in offers)
                Offers.Add(f);
        }

        private async void OpenOffer()
        {
            await Navigation.PushAsync(new OfferPage(SelectOffer));
        }
    }
}
