﻿using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Presenters.Views
{
    public interface ISynchronizationView : IView
    {
        SynchronizationViewModel ViewModel { get; }

        void ShowProgressBar();
        void UpdateStatus(string status);
        void UpdateProgress(int percents);

        void MakeInactive();
        void MakeActive();
        void ReturnToMenu();
    }
}
