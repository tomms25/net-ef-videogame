using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Classes
{
    [Table("videogames")]
    public class Videogame
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public long SoftwareHouseId { get; set; }
        public SoftwareHouse SoftwareHouse { get; set; }

        public Videogame(string name, string overview, DateTime releaseDate, long softwareHouseId)
        {
            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            SoftwareHouseId = softwareHouseId;
        }
    }
}