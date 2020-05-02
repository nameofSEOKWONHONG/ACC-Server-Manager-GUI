using System;
using System.Collections.Generic;
using System.Text;

namespace ACCCServerApp.Wpf.Resource
{
    public class LanguageResource
    {
        public string TITLE { get; set; }
        public string LANGUAGE { get; set; }

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

        #region [SETTINGS]
        public String SERVER_NAME { get; set; }
        public String SERVER_NAME_TOOLTIP { get; set; }
        public String ADMIN_PASS { get; set; }
        public String ADMIN_PASS_TOOLTIP { get; set; }

        public String TRACKMEDALS_REQUIREMENT { get; set; }
        public String TRACKMEDALS_REQUIREMENT_TOOLTIP { get; set; }
        public String SAFETYRATING_REQUIREMENT { get; set; }
        public String SAFETYRATING_REQUIREMENT_TOOLTIP { get; set; }
        public String RACECRAFTRATING_REQUIREMENT { get; set; }
        public String RACECRAFTRATING_REQUIREMENT_TOOLTIP { get; set; }
        public String PASSWORD { get; set; }
        public String PASSWORD_TOOLTIP { get; set; }
        public String SPECTATOR_PASSWORD { get; set; }
        public String SPECTATOR_PASSWORD_TOOLTIP { get; set; }
        #endregion
    }
}
