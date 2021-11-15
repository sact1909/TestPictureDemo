using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestPictureDemo.Database.SQLiteSettings.DbEntities
{
    public class PrincipalPost
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserIcon { get; set; }
        public string PictureComment { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public bool Like { get; set; }
        public bool Love { get; set; }
        public bool Funny { get; set; }
        public string TotalComents { get; set; }
        public int CountReactions { get; set; }
    }
}
