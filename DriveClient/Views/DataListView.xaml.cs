﻿using DriveClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DriveClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataListView : ContentPage
    {
        public DataListView()
        {
            InitializeComponent();
            this.BindingContext = new DataListViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as DataListViewModel).OnAppearing();
        }
    }
}