using System.ComponentModel.DataAnnotations;

namespace MVCFestival.DAL.Models
{
    public class Festival
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public int TicketsAvailable { get; set; }
        public ICollection<FestivalStage>? Stages { get; set; }

    }


}

