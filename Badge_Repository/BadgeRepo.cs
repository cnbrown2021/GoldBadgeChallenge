using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class BadgeRepo
    {
        public readonly List<Badge> badgeDirectory = new List<Badge>();
        //BadgeId - Door
        static void Main(string[] args)
        {
            Badge[] history =
            {
                new Badge(7, "d1"),
                new Badge(8, "d2"),
                new Badge(9, "d3"),
                new Badge(6, "d4"),
            };
            Dictionary<int, string> accessDictionary = new Dictionary<int, string>();
            Dictionary<int,Badge> badgeDirectory = new Dictionary<int, Badge>();
            foreach (Badge badge in history)
            {
                badgeDirectory.Add(1, badge);
            }

            var key = int.Parse("d1");
            if (badgeDirectory.ContainsKey(key))
            {
            Badge employee = badgeDirectory[key];
            Console.WriteLine("Badge Number: {0}, Door Access: {1}", employee.BadgeId, employee.DoorAccess);
            }
            else
            {
                Console.WriteLine("Employee not found {0}", key);
            }


        }

        //CRUD
        //Create
        public bool AddBadge(Badge access)
        {
            int beginCount = badgeDirectory.Count;
            badgeDirectory.Add(access);

            bool wasAdded = (badgeDirectory.Count > beginCount) ? true : false;
            return wasAdded;
        }

        //Read
        public List<Badge> ShowAccess()
        {
            return badgeDirectory;
        }

        //Get by BadgeId
        public Badge GetBadge(int KomodoBadgeId)
        {
            foreach (Badge access in badgeDirectory)
            {
                if (access.BadgeId == KomodoBadgeId)
                {
                    return access;
                }
            }
            return null;
        }


        //Update
        public bool UpdateDoor(Badge existingAccess, Badge newAccess)
        {
            if(existingAccess != null)
            {
                
                existingAccess.DoorAccess = newAccess.DoorAccess;
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool AddDoor(Badge existingAccess, Badge newAccess)
        {
            if (existingAccess != newAccess)
            {
                existingAccess.DoorAccess = newAccess.DoorAccess;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteAccess(Badge existingAccess)
        {
            bool delete = badgeDirectory.Remove(existingAccess);
            return delete;
        }

        public bool DeleteDoor(Badge existingAccess)
        {
            bool delete = badgeDirectory.Remove(existingAccess);
            return delete;
        }
    }
}
