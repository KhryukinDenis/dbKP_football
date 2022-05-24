using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace dbKP_football
{
    public static class Data
    {
        public static int League_Id { get; set; }
        public static int Team_Id { get; set; }
        public static int FootPlayers_Id { get; set; }
        public static int Stadium_Id { get; set; }
        public static int Coach_Id { get; set; }

        public static List<teams> SearchInTeams(db_KP_FootballEntities db, string search)
        {
            var s = new SqlParameter("@s", search);
            return db.teams.SqlQuery("select * from teams where (t_name like concat('%',@s,'%') or " +
                "t_tournier like concat('%',@s,'%') or " +
                "cast(t_quafootplayers as nvarchar) like concat('%',@s,'%') or " +
                "cast(t_yearoffound as nvarchar) like concat('%',@s,'%') or " +
                "s_id in (select s_id from stadiums where s_name like concat('%',@s,'%')) or " +
                "c_id in (select c_id from coaches where c_surname like concat('%',@s,'%')))", s).ToList();
        }

       public static List<footplayers> SearchInFootplayers(db_KP_FootballEntities db, string search)
        {
            var s = new SqlParameter("@s", search);
            return db.footplayers.SqlQuery("select * from footplayers where " +
                "fp_surname like concat('%',@s,'%') or " +
                "fp_name like concat('%',@s,'%') or " +
                "fp_nationality like concat('%',@s,'%') or " +
                "fp_position like concat('%',@s,'%') or " +
                "cast(fp_teamnumber as nvarchar) like concat('%',@s,'%') or " +
                "cast(fp_growth as nvarchar) like concat('%',@s,'%') or " +
                "cast(fp_weight as nvarchar) like concat('%',@s,'%') or " +
                "cast(fp_dateofbirth as nvarchar) like concat('%',@s,'%') or " +
                "fp_workingleg like concat('%',@s,'%')", s).ToList();

        }

        public static List<stadiums> SearchInStadiums(db_KP_FootballEntities db, string search)
        {
            var s = new SqlParameter("@s", search);
            return db.stadiums.SqlQuery("select * from stadiums where " +
            "s_name like concat('%',@s,'%') or " +
            "cast(s_capacity as nvarchar) like concat('%',@s,'%') or " +
            "cast(s_yearopening as nvarchar) like concat('%',@s,'%') or " +
            "s_locationcity like concat('%',@s,'%')", s).ToList();
        }

        public static List<coaches> SearchInCoaches(db_KP_FootballEntities db, string search)
        {
            var s = new SqlParameter("@s", search);
            return db.coaches.SqlQuery("select * from coaches where " +
            "c_surname like concat('%',@s,'%') or " +
            "c_name like concat('%',@s,'%') or " +
            "c_nationality like concat('%',@s,'%') or " +
            "cast(c_dateofbirth as nvarchar) like concat('%',@s,'%')", s).ToList();
        }
    }
}
