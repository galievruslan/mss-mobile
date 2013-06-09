using System;
using System.Threading;
using System.Windows.Forms;

namespace Updater {
    public partial class Updater : Form {
        public Updater() {
            InitializeComponent();
        }

        private UpdaterConfig _config;

        public Updater(UpdaterConfig config)
            : this() {
            _config = config;
        }

        private Thread _worker = new Thread(new ParametrizateThreadStart);
        private void UpdaterLoad(object sender, EventArgs e) {
            if (_config == null) {
                using (var configuration = new Configuration()) {
                    if (DialogResult.OK == configuration.ShowDialog()) {
                        _config = configuration.Config;
                    }
                    else {
                        Close();
                        Dispose();
                    }
                }
            }
        }

        private static void Run() {
        }
    }
}