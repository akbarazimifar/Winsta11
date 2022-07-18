﻿using Core.Collections.IncrementalSources.Directs;
using InstagramApiSharp.Classes.Models;
using Microsoft.Toolkit.Uwp;
using Resources;
using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using WinstaNext.Core.Dialogs;

namespace WinstaNext.ViewModels.Directs
{
    internal class DirectsListViewModel : BaseViewModel
    {
        public override string PageHeader { get; protected set; } = LanguageManager.Instance.Instagram.Directs;

        IncrementalDirectInbox Instance { get; }
        public IncrementalLoadingCollection<IncrementalDirectInbox, InstaDirectInboxThread> Inbox { get; }

        public DirectsListViewModel()
        {
            Instance = new IncrementalDirectInbox();
            Inbox = new IncrementalLoadingCollection<IncrementalDirectInbox, InstaDirectInboxThread>
                (Instance, onStartLoading: LoadingStarted, onEndLoading: LoadEnded, onError: OnError);
        }

        private void OnError(Exception obj)
        {
            UIContext.Post(new SendOrPostCallback(async (e) =>
            {
                await MessageDialogHelper.ShowAsync(obj.Message);
            }), null);
        }

        private void LoadEnded()
        {

        }

        private void LoadingStarted()
        {

        }

        public override async Task OnNavigatedToAsync(NavigationEventArgs e)
        {
            if (Inbox.Count == 0)
                await Inbox.LoadMoreItemsAsync(1);
            await base.OnNavigatedToAsync(e);
        }
    }
}
