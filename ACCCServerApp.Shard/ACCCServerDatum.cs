using ACCCServerApp.Shard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCCServerApp.Shard
{
    public class ACCCServerDatum
    {
        public static readonly IEnumerable<TrackList> TrackList = new List<TrackList>()
        {
            new TrackList { Value = "monza",  UniquePitBoxes =29  ,   PrivateServerSlots= 60  },
            new TrackList { Value = "zolder",  UniquePitBoxes =34  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "brands_hatch",  UniquePitBoxes =32  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "silverstone",  UniquePitBoxes =36  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "paul_ricard",  UniquePitBoxes =33  ,   PrivateServerSlots= 60  },
            new TrackList { Value = "misano",  UniquePitBoxes =30  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "spa",  UniquePitBoxes =82  ,   PrivateServerSlots= 82  },
            new TrackList { Value = "nurburgring",  UniquePitBoxes =30  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "barcelona",  UniquePitBoxes =29  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "hungaroring",  UniquePitBoxes =27  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "zandvoort",  UniquePitBoxes =25  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "monza_2019",  UniquePitBoxes =29  ,   PrivateServerSlots= 60  },
            new TrackList { Value = "zolder_2019",  UniquePitBoxes =34  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "brands_hatch_2019",  UniquePitBoxes =32  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "silverstone_2019",  UniquePitBoxes =36  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "paul_ricard_2019",  UniquePitBoxes =33  ,   PrivateServerSlots= 60  },
            new TrackList { Value = "misano_2019",  UniquePitBoxes =30  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "spa_2019",  UniquePitBoxes =82  ,   PrivateServerSlots= 82  },
            new TrackList { Value = "nurburgring_2019",  UniquePitBoxes =30  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "barcelona_2019",  UniquePitBoxes =29  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "hungaroring_2019",  UniquePitBoxes =27  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "zandvoort_2019",  UniquePitBoxes =25  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "kyalami_2019",  UniquePitBoxes =40  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "mount_panorama_2019",  UniquePitBoxes =36  ,   PrivateServerSlots= 50  },
            new TrackList { Value = "suzuka_2019",  UniquePitBoxes =51  ,   PrivateServerSlots= 105 },
            new TrackList { Value = "laguna_seca_2019",  UniquePitBoxes =30  ,   PrivateServerSlots= 50  },
        };

        public static readonly IEnumerable<int> HourOfDay = Enumerable.Range(0, 23);

        public static readonly Dictionary<string, int> DayOfWeeken = new Dictionary<string, int>()
        {
            {"Friday", 1 }, { "Saturday", 2}, {"Sunday", 3}
        };

        public static readonly IEnumerable<int> TimeMultiplier = Enumerable.Range(0, 24);

        public static readonly Dictionary<string, string> SessionType = new Dictionary<string, string>()
        {
            {"Practice", "P" }, { "Qualy", "Q"}, { "Race", "R" }
        };

        public static readonly IEnumerable<int> TrackMedalsRequirement = Enumerable.Range(0, 3);

        public static readonly IEnumerable<int> SafetyRatingRequirement = Enumerable.Range(-1, 99);

        public static readonly IEnumerable<int> RacecraftRatingRequirement = Enumerable.Range(-1, 99);
    }
}
