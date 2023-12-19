using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Data;
using AutoMapper;
using LeaveManagement.Models;
using LeaveManagement.Contracts;
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.RolesEntities;
using LeaveManagement.Services;

namespace Leavemanagement.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveType _leaveType;
        private readonly ILeaveAllocation _leaveAllocation;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveType leaveType, IMapper mapper, ILeaveAllocation leaveAllocation)
        {
            _leaveType = leaveType;
            _leaveAllocation= leaveAllocation;
            _mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var leaveType= _mapper.Map<List<LeaveTypeVM>>(await _leaveType.GetAllAsync());

            return View(leaveType);
            
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
        
            var leaveType = await _leaveType.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTypes = _mapper.Map<LeaveTypeVM>(leaveType);
            return View(leaveTypes);
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
        public async Task<IActionResult> Create(LeaveTypeVM leaveTypeVM)
        {
            if (ModelState.IsValid)
            {
               var leaveType = _mapper.Map<LeaveType>(leaveTypeVM);
               await  _leaveType.AddAsync(leaveType);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           var leaveType = await _leaveType.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var leaveTypes = _mapper.Map<LeaveTypeVM>(leaveType);
            return View(leaveTypes);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeVM leaveTypeVM)
        {
            if (id != leaveTypeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = _mapper.Map<LeaveType>(leaveTypeVM);
                    await  _leaveType.UpdateAsync(leaveType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    // !LeaveTypeExistsAsync(leaveTypeVM.Id)
                    if (!await _leaveType.Exists(leaveTypeVM.Id))
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
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null || _context.LeaveTypes == null)
        //     {
        //         return NotFound();
        //     }

        //     var leaveType = await _context.LeaveTypes
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (leaveType == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(leaveType);
        // }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
            await _leaveType.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AllocateLeave(int id)
        {
            await _leaveAllocation.LeaveAllocation(id);
			return RedirectToAction(nameof(Index));
		}
	
    }
}