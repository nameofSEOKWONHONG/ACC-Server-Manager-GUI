using ACCCServerApp.Shard.Models;
using System;
using System.Collections.Generic;
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
        public static readonly IEnumerable<TrackList> TrackList = new List<TrackList>()
        {
            new TrackList { Value = "monza",  UniquePitBoxes =29  ,   PrivateServerSlots= 60, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Monza.jpg"  },
            new TrackList { Value = "zolder",  UniquePitBoxes =34  ,   PrivateServerSlots= 50, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Zolder.jpg"  },
            new TrackList { Value = "brands_hatch",  UniquePitBoxes =32  ,   PrivateServerSlots= 50, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Brands-Hatch.png"  },
            new TrackList { Value = "silverstone",  UniquePitBoxes =36  ,   PrivateServerSlots= 50, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Silverstone.png"  },
            new TrackList { Value = "paul_ricard",  UniquePitBoxes =33  ,   PrivateServerSlots= 60, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Paul-Ricard.jpg"  },
            new TrackList { Value = "misano",  UniquePitBoxes =30  ,   PrivateServerSlots= 50, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Misano.jpg"  },
            new TrackList { Value = "spa",  UniquePitBoxes =82  ,   PrivateServerSlots= 82, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Spa-Francorchamps.png"  },
            new TrackList { Value = "nurburgring",  UniquePitBoxes =30  ,   PrivateServerSlots= 50, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Nurburgring.jpg" },
            new TrackList { Value = "barcelona",  UniquePitBoxes =29  ,   PrivateServerSlots= 50, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Barcelona.png"  },
            new TrackList { Value = "hungaroring",  UniquePitBoxes =27  ,   PrivateServerSlots= 50, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Hungarorin.jpg"  },
            new TrackList { Value = "zandvoort",  UniquePitBoxes =25  ,   PrivateServerSlots= 50, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Zandvoort.png"  },
            new TrackList { Value = "monza_2019",  UniquePitBoxes =29  ,   PrivateServerSlots= 60, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Monza.jpg"  },
            new TrackList { Value = "zolder_2019",  UniquePitBoxes =34  ,   PrivateServerSlots= 50, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Zolder.jpg"  },
            new TrackList { Value = "brands_hatch_2019",  UniquePitBoxes =32  ,   PrivateServerSlots= 50, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Brands-Hatch.png"  },
            new TrackList { Value = "silverstone_2019",  UniquePitBoxes =36  ,   PrivateServerSlots= 50, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Silverstone.png"  },
            new TrackList { Value = "paul_ricard_2019",  UniquePitBoxes =33  ,   PrivateServerSlots= 60, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Paul-Ricard.jpg"  },
            new TrackList { Value = "misano_2019",  UniquePitBoxes =30  ,   PrivateServerSlots= 50, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Misano.jpg"  },
            new TrackList { Value = "spa_2019",  UniquePitBoxes =82  ,   PrivateServerSlots= 82, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Spa-Francorchamps.png"  },
            new TrackList { Value = "nurburgring_2019",  UniquePitBoxes =30  ,   PrivateServerSlots= 50, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Nurburgring.jpg"  },
            new TrackList { Value = "barcelona_2019",  UniquePitBoxes =29  ,   PrivateServerSlots= 50, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Barcelona.png"  },
            new TrackList { Value = "hungaroring_2019",  UniquePitBoxes =27  ,   PrivateServerSlots= 50, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Nurburgring.jpg"  },
            new TrackList { Value = "zandvoort_2019",  UniquePitBoxes =25  ,   PrivateServerSlots= 50, ImageUrl = "https://www.assettocorsa.net/competizione/wp-content/uploads/Zandvoort.png"  },
            new TrackList { Value = "kyalami_2019",  UniquePitBoxes =40  ,   PrivateServerSlots= 50, ImageUrl = "http://i3.wp.com/assettocorsa.net/competizione/wp-content/uploads/1-1-1440x810.jpg"  },
            new TrackList { Value = "mount_panorama_2019",  UniquePitBoxes =36  ,   PrivateServerSlots= 50, ImageUrl = "http://i1.wp.com/assettocorsa.net/competizione/wp-content/uploads/19-1-1440x810.jpg"  },
            new TrackList { Value = "suzuka_2019",  UniquePitBoxes =51  ,   PrivateServerSlots= 105, ImageUrl = "http://i2.wp.com/assettocorsa.net/competizione/wp-content/uploads/3-1440x810.jpg" },
            new TrackList { Value = "laguna_seca_2019",  UniquePitBoxes =30  ,   PrivateServerSlots= 50, ImageUrl = "http://i0.wp.com/assettocorsa.net/competizione/wp-content/uploads/12-1-1440x810.jpg"  },
        };

        /// <summary>
        /// HOUR OF DAY (0 ~ 23)
        /// </summary>
        public static readonly IEnumerable<int> HourOfDay = Enumerable.Range(0, 23);

        /// <summary>
        /// DAY WEEK OF SESSION
        /// </summary>
        public static readonly Dictionary<string, int> DayOfWeeken = new Dictionary<string, int>()
        {
            {"Friday", 1 }, { "Saturday", 2}, {"Sunday", 3}
        };

        public static readonly IEnumerable<int> TimeMultiplier = Enumerable.Range(0, 24);

        /// <summary>
        /// SESSION TYPE
        /// </summary>
        public static readonly Dictionary<string, string> SessionType = new Dictionary<string, string>()
        {
            {"Practice", "P" }, { "Qualy", "Q"}, { "Race", "R" }
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
    }
}
