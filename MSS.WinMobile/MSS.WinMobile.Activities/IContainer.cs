using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSS.WinMobile.Activities
{
    public interface IContainer
    {
        void Register(IActivity activity);
    }
}
