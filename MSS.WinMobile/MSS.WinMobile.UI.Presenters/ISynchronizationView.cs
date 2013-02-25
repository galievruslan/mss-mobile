﻿namespace MSS.WinMobile.UI.Presenters
{
    public interface ISynchronizationView : IView
    {
        void Start();

        void UpdateStatus(string status);

        void UpdateProgress(int percents);

        void Cancel();
    }
}