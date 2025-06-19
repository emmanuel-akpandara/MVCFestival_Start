using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFestival.DAL.Data;
using MVCFestival.DAL.Models;
using MVCFestival.Helpers;
using System.Net.Sockets;
using System;
using MVCFestival.DAL;

namespace MVCFestival.Controllers
{
    public class FestivalController : Controller
    {

        private IUnitOfWork _uow;

        public FestivalController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
          
            
            var festivalContext = _uow.FestivalRepository.Get( includes : s => s.Stages );
            
            return View(festivalContext.ToList());
        }

        public IActionResult Edit(int id)
        {
            var stage = _uow.FestivalStageRepository.Get(filter: s => s.Id == id).FirstOrDefault();

            return View(stage);
        }

        // POST: Ratings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Capacity")] FestivalStage stage)
        {
            // _context.FestivalStages.Attach(stage);

            var existingStage= _uow.FestivalStageRepository.GetByID(id);

            if (existingStage != null)
            {
                existingStage.Name = stage.Name;
                existingStage.Capacity = stage.Capacity;
                _uow.FestivalStageRepository.Update(existingStage);
                _uow.Save();
            }
          

            return RedirectToAction("Index");   
        }


    }
}
