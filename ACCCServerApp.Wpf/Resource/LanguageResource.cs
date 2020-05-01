using System;
using System.Collections.Generic;
using System.Text;

namespace ACCCServerApp.Wpf.Resource
{
    public class LanguageResource
    {
        public string TITLE { get; set; }

        #region [MainWindow]
        public string MAIN { get; set; }
        public string SETTINGS { get; set; }

        public string CONFIGURATION { get; set; }
        public string EVENT { get; set; }
        public string SETTING { get; set; }
        #endregion

        public string SERVER_START { get; set; }

        #region [CONFIGURATION]
        public string CHK_UDP_PORT { get; set; }
        public string CHK_TCP_PORT { get; set; }
        public string MAX_CONNECTION { get; set; }
        public string CONFIG_VERSION { get; set; }
        #endregion
    }
}
