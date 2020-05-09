using System;
using System.Collections.Generic;
using System.Text;

namespace ACCCServerApp.Shard
{
    public class LanguageResource
    {
        #region [APP]
        public string TITLE { get; set; }
        public string LANGUAGE { get; set; }
        #endregion

        #region [MENU]
        public string MAIN { get; set; }
        public string SETTINGS { get; set; }

        public string CONFIGURATION { get; set; }
        public string EVENT { get; set; }
        public string SESSION { get; set; }
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
        public String MAX_CAR_SLOTS { get; set; }
        public String MAX_CAR_SLOTS_TOOLTIP { get; set; }
        public String DUMP_LEADERBOARDS { get; set; }
        public String DUMP_LEADERBOARDS_TOOLTIP { get; set; }
        public String IS_RACE_LOCKED { get; set; }
        public String IS_RACE_LOCKED_TOOLTIP { get; set; }
        public String RANDOMIZE_TRACK_WHEN_EMPTY { get; set; }
        public String RANDOMIZE_TRACK_WHEN_EMPTY_TOOLTIP { get; set; }
        public String CENTRAL_ENTRY_LIST_PATH { get; set; }
        public String CENTRAL_ENTRY_LIST_PATH_TOOLTIP { get; set; }
        public String ALLOW_AUTO_DQ { get; set; }
        public String ALLOW_AUTO_DQ_TOOLTIP { get; set; }
        public String SHORT_FORMATIONLAP { get; set; }
        public String SHORT_FORMATIONLAP_TOOLTIP { get; set; }
        public String DUMP_ENTRY_LIST { get; set; }
        public String DUMP_ENTRY_LIST_TOOLTIP { get; set; }
        public String FORMATIONLAP_TYPE { get; set; }
        public String FORMATIONLAP_TYPE_TOOLTIP { get; set; }


        #endregion

        #region [RaceSession]
        public String HOUR_OF_DAY { get; set; }
        public String HOUR_OF_DAY_TOOLTIP { get; set; }
        public String DAY_OF_WEEKEND { get; set; }
        public String DAY_OF_WEEKEND_TOOLTIP { get; set; }
        public String TIME_MULTIPLIER { get; set; }
        public String TIME_MULTIPLIER_TOOLTIP { get; set; }
        public String SESSION_TYPE { get; set; }
        public String SESSION_TYPE_TOOLTIP { get; set; }
        public String SESSION_DURATION_MINUTES { get; set; }
        public String SESSION_DURATION_MINUTES_TOOLTIP { get; set; }
        #endregion
    }
}
