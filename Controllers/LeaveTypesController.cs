using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.web.Data;
using AutoMapper;
using LeaveManagement.web.Configuration;
using LeaveManagement.web.Models;
using LeaveTypeVM = LeaveManagement.web.Configuration.LeaveTypeVM;
using LeaveManagement.web.Repsitory;

namespace LeaveManagement.web.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;

        public LeaveTypesController(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this.leaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            //return _context.LeaveTypes != null ? 
            // View(await _context.LeaveTypes.ToListAsync()) : //select*from LeaveTypes


            var leaveTypes = mapper.Map<List<LeaveTypeV>>(await leaveTypeRepository.GetAllAsync());
            return View(leaveTypes);

            //Problem("Entity set 'ApplicationDbContext.LeaveTypes'  is null.");
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
          

            var leaveType = await leaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTypeV = mapper.Map<LeaveTypeV>(leaveType);

            return View(leaveTypeV);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeV leaveTypeV)
        {
            if (ModelState.IsValid)
            {
                var leaveType = mapper.Map<LeaveType>(leaveTypeV);
                await leaveTypeRepository.GetAsync(leaveType);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeV);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
         

            var leaveType = await leaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTypeV = mapper.Map<LeaveTypeV>(leaveType);

            return View(leaveTypeV);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeV leaveTypeV)
        {
            if (id != leaveTypeV.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = mapper.Map<LeaveType>(leaveTypeV);
                    await leaveTypeRepository.AddAsync(leaveType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await LeaveTypeExistsAsync(leaveTypeV.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeV);
        }

        private Task<bool> LeaveTypeExistsAsync(int id)
        {
            throw new NotImplementedException();
        }



        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await leaveTypeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

      
    }
}
