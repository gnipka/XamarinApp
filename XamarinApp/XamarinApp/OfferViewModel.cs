using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using XamarinApp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace XamarinApp
{
    public class OfferViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public OfferViewModel(Offer offer)
        {
            OfferInfo = Encoding.Unicode.GetString(Encoding.Default.GetBytes("```" + offer.JsonConent)); 
        }

        private string _offerInfo;
        public string OfferInfo
        {
            get { return _offerInfo; }
            set
            {
                _offerInfo = value;
                OnPropertyChanged("OfferInfo");
            }
        }
    }
}
