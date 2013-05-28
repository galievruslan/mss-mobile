namespace MSS.WinMobile.Resources {
    public static class Localizator {
        public static void SetupLocalization(Localization localization) {
            Localization = localization;
        }

        public static Localization Localization { get; private set; }
    }
}
