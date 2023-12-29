using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LeaveManagement.Data;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using LeaveManagement.Models;
using LeaveManagement.Contracts;
using LeaveManagement.Services;
using LeaveManagement.RolesEntities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Leavemanagement.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocation _leaveAllocation;
        private readonly ILeaveType _leaveType;
        public EmployeesController(UserManager<Employee> userManager,IMapper mapper, ILeaveAllocation leaveAllocation, ILeaveType leaveType)
        {
            _userManager = userManager;
            _mapper = mapper;
            _leaveAllocation = leaveAllocation;
            _leaveType = leaveType;

        }
        // GET: EmployeesController
        public async Task<IActionResult> Index() 
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var model = _mapper.Map<List<EmployeeListVM>>(employees);
            return View(model);
        }

        // GET: EmployeesController/ViewAllocations/employeeId
        public async Task<ActionResult> ViewAllocations(string id)
        {
            var model = await _leaveAllocation.GetEmployeeAllocations(id);
            return View(model);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public async Task<ActionResult> EditAllocation(int id)
        {
            var model = await _leaveAllocation.GetEmployeeAllocation(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ActionResult EditAllocation(int id, LeaveAllocationEditVM model)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var leaveAllocation = await _leaveAllocation.GetAllAsync(Model.Id);
                    if (leaveAllocation == null)
                    {
                        return NotFound();
                    }

                    leaveAllocation.Period = model.Period;
                    leaveAllocation.NumberOfDays = model.NumberOfDays;
                    await _leaveAllocation.UpdateAsync(leaveAllocation);

                    return RedirectToAction(nameof(ViewAllocations), new { id = model.EmployeeId });

                }
            }
            catch(Exception ex)
            {  
                 ModelState.AddModelError(string.Empty, "An Errorr Has Occured. Please Try Agian Later");
            }
            model.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(model.EmployeeId));
            model.LeaveType = _mapper.Map<LeaveTypeVM>(await _leaveType.GetAsync(model.LeaveTypeId));
            return View(model);
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}