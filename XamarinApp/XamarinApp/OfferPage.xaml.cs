﻿using Xam.Forms.Markdown;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;

namespace XamarinApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OfferPage : ContentPage
    {
        public OfferPage(Offer offer)
        {
            InitializeComponent();
            //this.BindingContext = new OfferViewModel(offer) { Navigation = this.Navigation };
            var view = new MarkdownView();
            view.Markdown = "```" + offer.JsonConent;
            this.Content = view;
        }
    }
}