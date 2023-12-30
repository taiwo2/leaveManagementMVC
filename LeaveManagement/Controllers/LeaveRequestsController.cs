using LeaveManagement.RolesEntities;
using LeaveManagement.Contracts;
using LeaveManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveManagement.Web.Controllers
{
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        private readonly ILeaveRequest _leaveRequest;
        private readonly ILeaveType _leaveType;

        public LeaveRequestsController(ILeaveRequest leaveRequest, ILeaveType leaveType)
        {
            _leaveRequest = leaveRequest;
            _leaveType = leaveType;
        }

        [Authorize(Roles = Roles.Administrator)]
        // GET: LeaveRequests
        public async Task<IActionResult> Index()
        {
            var model = await _leaveRequest.GetAdminLeaveRequestList();
            return View(model);
        }

        public async Task<ActionResult> MyLeave()
        {
            var model = await _leaveRequest.GetMyLeaveDetails();
            return View(model);
        }

        // GET: LeaveRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var model = await _leaveRequest.GetLeaveRequestAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveRequest(int id, bool approved)
        {
            try
            {
                await _leaveRequest.ChangeApprovalStatus(id, approved);
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                await _leaveRequest.CancelLeaveRequest(id);
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction(nameof(MyLeave));
        }

        // GET: LeaveRequests/Create
        public async Task<IActionResult> Create()
        {
            var model = new LeaveRequestCreateVM
            {
                LeaveTypes = new SelectList(await _leaveType.GetAllAsync(), "Id", "Name")
            };
            return View(model);
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isValidRequest = await _leaveRequest.CreateLeaveRequest(model);
                    if (isValidRequest)
                    {
                        return RedirectToAction(nameof(MyLeave));
                    }
                    ModelState.AddModelError(string.Empty, "You have exceeded your allocation with this request.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An Error Has Occurred. Please Try Again Later");
            }

            model.LeaveTypes = new SelectList(await _leaveType.GetAllAsync(), "Id", "Name", model.LeaveTypeId);
            return View(model);
        }
    }
}