using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbKP_football
{
     static class Data
    {
        public static db_KP_FootballEntities db = new db_KP_FootballEntities();
        public static int League_Id { get; set; }

        public static ObservableCollection<leagues> GetLeagues()
        {
            var leagues = new ObservableCollection<leagues>(db.leagues);
            return leagues;
        }
        
    }
}
