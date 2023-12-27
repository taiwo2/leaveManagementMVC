using AutoMapper;
using LeaveManagement.RolesEntities;
using LeaveManagement.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Services
{
	public class LeaveAllocationService : GenericService<LeaveAllocation>, ILeaveAllocation
	{
		private readonly ILeaveType _leaveType;
		private readonly IMapper _mapper;
		private readonly ApplicationDbContext _context;
		private readonly UserManager<Employee> _userManager;

		public LeaveAllocationService(ApplicationDbContext context,
			UserManager<Employee> userManager, ILeaveType leaveType, IMapper mapper) : base(context)
		{
			_leaveType = leaveType;
			_mapper = mapper;
			_context = context;
			_userManager = userManager;
		}

		public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
		{
			return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId && q.Period == period);
		}

		public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId)
		{
			var allocations = _context.LeaveAllocations
				.Include(q => q.LeaveType)
				.Where(q => q.EmployeeId == employeeId)
				.ToListAsync();
				
			var employee = await _userManager.FindByIdAsync(employeeId);

			var employeeAllocationModel = _mapper.Map<EmployeeAllocationVM>(employee);
			employeeAllocationModel.LeaveAllocations = _mapper.Map<List<LeaveAllocationVM>>(allocations);

			return employeeAllocationModel;
		}

		public async Task LeaveAllocation(int leaveTypeId)
		{
			var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
			var period = DateTime.Now.Year;
			var leaveType = await _leaveType.GetAsync(leaveTypeId);
			var allocations = new List<LeaveAllocation>();

			foreach (var employee in employees)
			{
				if (await AllocationExists(employee.Id, leaveTypeId, period))

					continue;

					allocations.Add(new LeaveAllocation
					{
						EmployeeId = employee.Id,
						LeaveTypeId = leaveTypeId,
						Period = period,
						NumberOfDays = leaveType.DefaultDays,
					});

				
			}
					await AddRangeAsync(allocations);
		}
	}
}