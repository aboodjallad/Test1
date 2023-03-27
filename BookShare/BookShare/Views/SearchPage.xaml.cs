﻿using BookShare.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookShare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        BookShareDB BookShareDB = new BookShareDB();

        public SearchPage()
        {
            InitializeComponent();

        }
       
        private void OnItemTapped(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked!");
        }

    }
}