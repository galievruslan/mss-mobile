﻿namespace MSS.WinMobile.UI.Presenters.Views
{
    public interface ISynchronizationView : IView
    {
        void UpdateStatus(string status);

        void UpdateProgress(int percents);
    }
}
