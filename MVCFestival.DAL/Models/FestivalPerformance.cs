namespace MVCFestival.DAL.Models
{

    public class FestivalPerformance
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Performer { get; set; }
        public int StageId { get; set; }

        //Navigation
        public FestivalStage? Stage { get; set; }
    }
}

