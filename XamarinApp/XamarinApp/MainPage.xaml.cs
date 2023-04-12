using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinApp
{
    public partial class MainPage : ContentPage
    {
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
