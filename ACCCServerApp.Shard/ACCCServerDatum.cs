using ACCCServerApp.Shard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCCServerApp.Shard
{
    /// <summary>
    /// ACCC SERVER CONFIGURATION DATASET CLASS
    /// </summary>
    public class ACCCServerDatum
    {
        /// <summary>
        /// TRACK LIST (IMPORT DLC TRACKS)
        /// </summary>
        public static readonly IEnumerable<RaceTrack> TrackList = new List<RaceTrack>()
        {
            new RaceTrack { Value = "monza",  UniquePitBoxes =29  ,   PrivateServerSlots= 60, ImagePath = "/Resource/Image/Tracks/Monza.jpg"  },
            new RaceTrack { Value = "zolder",  UniquePitBoxes =34  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Zolder.jpg"  },
            new RaceTrack { Value = "brands_hatch",  UniquePitBoxes =32  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Brands-Hatch.png"  },
            new RaceTrack { Value = "silverstone",  UniquePitBoxes =36  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Silverstone.png"  },
            new RaceTrack { Value = "paul_ricard",  UniquePitBoxes =33  ,   PrivateServerSlots= 60, ImagePath = "/Resource/Image/Tracks/Paul-Ricard.jpg"  },
            new RaceTrack { Value = "misano",  UniquePitBoxes =30  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Misano.jpg"  },
            new RaceTrack { Value = "spa",  UniquePitBoxes =82  ,   PrivateServerSlots= 82, ImagePath = "/Resource/Image/Tracks/Spa-Francorchamps.png"  },
            new RaceTrack { Value = "nurburgring",  UniquePitBoxes =30  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Nurburgring.jpg" },
            new RaceTrack { Value = "barcelona",  UniquePitBoxes =29  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Barcelona.png"  },
            new RaceTrack { Value = "hungaroring",  UniquePitBoxes =27  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Hungarorin.jpg"  },
            new RaceTrack { Value = "zandvoort",  UniquePitBoxes =25  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Zandvoort.png"  },
            new RaceTrack { Value = "monza_2019",  UniquePitBoxes =29  ,   PrivateServerSlots= 60, ImagePath = "/Resource/Image/Tracks/Monza.jpg"  },
            new RaceTrack { Value = "zolder_2019",  UniquePitBoxes =34  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Zolder.jpg"  },
            new RaceTrack { Value = "brands_hatch_2019",  UniquePitBoxes =32  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Brands-Hatch.png"  },
            new RaceTrack { Value = "silverstone_2019",  UniquePitBoxes =36  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Silverstone.png"  },
            new RaceTrack { Value = "paul_ricard_2019",  UniquePitBoxes =33  ,   PrivateServerSlots= 60, ImagePath = "/Resource/Image/Tracks/Paul-Ricard.jpg"  },
            new RaceTrack { Value = "misano_2019",  UniquePitBoxes =30  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Misano.jpg"  },
            new RaceTrack { Value = "spa_2019",  UniquePitBoxes =82  ,   PrivateServerSlots= 82, ImagePath = "/Resource/Image/Tracks/Spa-Francorchamps.png"  },
            new RaceTrack { Value = "nurburgring_2019",  UniquePitBoxes =30  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Nurburgring.jpg"  },
            new RaceTrack { Value = "barcelona_2019",  UniquePitBoxes =29  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Barcelona.png"  },
            new RaceTrack { Value = "hungaroring_2019",  UniquePitBoxes =27  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Nurburgring.jpg"  },
            new RaceTrack { Value = "zandvoort_2019",  UniquePitBoxes =25  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Zandvoort.png"  },
            // DLC
            new RaceTrack { Value = "kyalami_2019",  UniquePitBoxes =40  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Kyalami.jpg"  },
            new RaceTrack { Value = "mount_panorama_2019",  UniquePitBoxes =36  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Mount_panorama.jpg"  },
            new RaceTrack { Value = "suzuka_2019",  UniquePitBoxes =51  ,   PrivateServerSlots= 105, ImagePath = "/Resource/Image/Tracks/Suzuka.jpg" },
            new RaceTrack { Value = "laguna_seca_2019",  UniquePitBoxes =30  ,   PrivateServerSlots= 50, ImagePath = "/Resource/Image/Tracks/Laguna_seca.jpg"  },
        };

        /// <summary>
        /// HOUR OF DAY (0 ~ 23)
        /// </summary>
        public static readonly IEnumerable<int> HourOfDay = Enumerable.Range(0, 23);

        /// <summary>
        /// DAY WEEK OF SESSION
        /// </summary>
        public static readonly List<KeyValueSimpleModel> DayOfWeeken = new List<KeyValueSimpleModel>()
        {
            new KeyValueSimpleModel() {Key = "Friday", Value = "1" },
            new KeyValueSimpleModel() {Key = "Saturday", Value = "2" },
            new KeyValueSimpleModel() {Key = "Sunday", Value = "3" },
        };

        public static readonly IEnumerable<int> TimeMultiplier = Enumerable.Range(0, 24);

        /// <summary>
        /// SESSION TYPE
        /// </summary>
        public static readonly List<KeyValueSimpleModel> SessionType = new List<KeyValueSimpleModel>()
        {
            new KeyValueSimpleModel() {Key = "Practice", Value = "P" },
            new KeyValueSimpleModel() {Key = "Qualifying", Value = "Q" },
            new KeyValueSimpleModel() {Key = "Race", Value = "R" },
        };

        /// <summary>
        /// MEDAL REQUIRE (LIMIT REQUIRE)
        /// </summary>
        public static readonly IEnumerable<int> TrackMedalsRequirement = Enumerable.Range(0, 3);

        /// <summary>
        /// SAFITY RATE (LIMIT REQUIRE)
        /// </summary>
        public static readonly IEnumerable<int> SafetyRatingRequirement = Enumerable.Range(-1, 99);

        /// <summary>
        /// RACE RATING (LIMIT REQUIRE)
        /// </summary>
        public static readonly IEnumerable<int> RacecraftRatingRequirement = Enumerable.Range(-1, 99);

        public enum DAY_OF_WEEKEND_TYPES
        {
            FRIDAY = 1,
            SATURDAY = 2,
            SUNDAY = 3
        }

        public enum SESSION_TYPES
        {
            [Description("P")]
            PRACETICE,
            [Description("Q")]
            QUALIFYING,
            [Description("R")]
            RACE
        }
    }

    public class KeyValueSimpleModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
