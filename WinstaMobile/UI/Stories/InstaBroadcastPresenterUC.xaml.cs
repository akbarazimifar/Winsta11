﻿using InstagramApiSharp.Classes.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinstaCore.Interfaces.Views.Profiles;
using WinstaCore.Services;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WinstaMobile.UI.Stories
{
    public sealed partial class InstaBroadcastPresenterUC : UserControl
    {
        public static readonly DependencyProperty BroadcastProperty = DependencyProperty.Register(
             nameof(Broadcast),
             typeof(InstaBroadcast),
             typeof(InstaBroadcastPresenterUC),
             new PropertyMetadata(null));

        public InstaBroadcast Broadcast
        {
            get { return (InstaBroadcast)GetValue(BroadcastProperty); }
            set { SetValue(BroadcastProperty, value); }
        }

        public RelayCommand<object> NavigateToUserProfileCommand { get; set; }

        public InstaBroadcastPresenterUC()
        {
            this.InitializeComponent();
            NavigateToUserProfileCommand = new(NavigateToUserProfile);
        }

        void NavigateToUserProfile(object obj)
        {
            var NavigationService = App.Container.GetService<NavigationService>();
            var UserProfileView = App.Container.GetService<IUserProfileView>();
            NavigationService.Navigate(UserProfileView, obj);
        }
    }
}
