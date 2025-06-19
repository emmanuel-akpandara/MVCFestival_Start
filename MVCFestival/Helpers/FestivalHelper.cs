using MVCFestival.DAL.Models;

namespace MVCFestival.Helpers
{
    public  class FestivalHelper
    {


        public static int CalculateTotalCapacity(ICollection<FestivalStage> stageList)
        {
            var total = 0;
            foreach(var stage in stageList)
                {
                total += stage.Capacity;
                }
            return total;
        }
    }
}
