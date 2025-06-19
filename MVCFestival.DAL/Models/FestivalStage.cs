using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVCFestival.DAL.Models
{
    public class FestivalStage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int FestivalId { get; set; }

        //Navigation
        public Festival? Festival { get; set; }

        public ICollection<FestivalPerformance>? Performances { get; set; }


    }

}
