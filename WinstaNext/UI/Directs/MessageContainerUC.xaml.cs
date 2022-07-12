﻿using InstagramApiSharp.Classes.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinstaNext.Abstractions.Direct.Models;
using WinstaNext.Services;
using WinstaNext.UI.Flyouts.Directs;
using WinstaNext.Views.Profiles;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WinstaNext.UI.Directs
{
    [AddINotifyPropertyChangedInterface]
    public partial class MessageContainerUC : UserControl
    {
        public static readonly DependencyProperty DirectItemProperty = DependencyProperty.Register(
             nameof(DirectItem),
             typeof(InstaDirectInboxItemFullModel),
             typeof(MessageContainerUC),
             new PropertyMetadata(null));

        public static readonly DependencyProperty DirectUserProperty = DependencyProperty.Register(
             nameof(DirectUser),
             typeof(InstaUserShort),
             typeof(MessageContainerUC),
             new PropertyMetadata(null));

        [OnChangedMethod(nameof(OnDirectItemChanged))]
        public InstaDirectInboxItemFullModel DirectItem
        {
            get { return (InstaDirectInboxItemFullModel)GetValue(DirectItemProperty); }
            set { SetValue(DirectItemProperty, value); }
        }

        public InstaUserShort DirectUser
        {
            get { return (InstaUserShort)GetValue(DirectUserProperty); }
            set { SetValue(DirectUserProperty, value); }
        }

        public RelayCommand<object> NavigateUserProfileCommand { get; set; }

        public MessageContainerUC()
        {
            NavigateUserProfileCommand = new RelayCommand<object>(NavigateToProfile);
            this.InitializeComponent();
        }

        private void NavigateToProfile(object parameter)
        {
            var nav = App.Container.GetService<NavigationService>();
            nav.Navigate(typeof(UserProfileView), parameter);
        }

        protected virtual void OnDirectItemChanged()
        {

        }

        private void UserControl_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            //DirectMessageItemMenuFlyout.ShowAttachedFlyout(this);
        }

        private void UserControl_Holding(object sender, HoldingRoutedEventArgs e)
        {
            //DirectMessageItemMenuFlyout.ShowAttachedFlyout(this);
        }
    }
}
