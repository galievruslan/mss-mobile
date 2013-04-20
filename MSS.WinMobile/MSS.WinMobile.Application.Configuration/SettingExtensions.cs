using System;

namespace MSS.WinMobile.Application.Configuration
{
    public static class SettingExtensions
    {
        public static int AsInt(this Setting setting) {
            return Int32.Parse(setting.Value);
        }

        public static long AsLong(this Setting setting)
        {
            return Int64.Parse(setting.Value);
        }
    }
}
