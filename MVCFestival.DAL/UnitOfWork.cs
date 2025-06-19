using MVCFestival.DAL.Data;
using MVCFestival.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFestival.DAL
{
    public class UnitOfWork:IUnitOfWork
    {



        private FestivalDbContext _context;
        private IRepository<FestivalStage> festivalStageRepository;
        private IRepository<Festival> festivalRepository;
        public UnitOfWork(FestivalDbContext context)
        {
            _context = context;
        }

        public void Save()
        {

            _context.SaveChanges();
        }

        public IRepository<FestivalStage> FestivalStageRepository
        {

            get
            {
                if (festivalStageRepository == null)
                {

                    festivalStageRepository = new GenericRepository<FestivalStage>(_context);
                }

                return festivalStageRepository;
            }

        }

        public IRepository<Festival> FestivalRepository
        {

            get
            {
                if (festivalRepository == null)
                {

                    festivalRepository = new GenericRepository<Festival>(_context);
                }

                return festivalRepository;
            }

        }
    }
}
