﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IMotorCare
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreen : ContentPage
    {
        public SplashScreen()
        {
            InitializeComponent();
            var sub = new AbsoluteLayout();
            AbsoluteLayout.SetLayoutFlags(SplashScreenImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(SplashScreenImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SplashScreenImage.ScaleTo(1, 200);
            SplashScreenImage.ScaleTo(0.9, 1500, Easing.Linear);
            SplashScreenImage.ScaleTo(150, 1200, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}