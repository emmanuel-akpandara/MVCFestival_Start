using MVCFestival.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFestival.DAL
{
    public interface IUnitOfWork
    {
        IRepository<FestivalStage> FestivalStageRepository { get; }
        IRepository<Festival> FestivalRepository { get; }

        void Save();


    }
}
