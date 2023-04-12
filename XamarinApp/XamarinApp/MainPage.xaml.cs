using Xamarin.Forms;

namespace XamarinApp
{
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new MainViewModel() { Navigation = this.Navigation };
            this.BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetOffers();
            base.OnAppearing();
        }
    }
}
