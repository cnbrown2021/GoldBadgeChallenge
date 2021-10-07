using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    //POCO
    public class Badge
    {
        public Badge () { }
        public int BadgeId { get; set; }
        public string DoorAccess { get; set; }

        public Badge(int badgeId, string doorAccess)
        {
            BadgeId = badgeId;
            DoorAccess = doorAccess;
        }
    }
}
