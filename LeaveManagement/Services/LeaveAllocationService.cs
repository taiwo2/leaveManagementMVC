using AutoMapper;
using AutoMapper.QueryableExtensions;
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
		private readonly ApplicationDbContext _context;
		private readonly UserManager<Employee> _userManager;
		private readonly ILeaveType _leaveType;
		private readonly AutoMapper.IConfigurationProvider _configurationProvider;
		private readonly IMapper _mapper;
		

		public LeaveAllocationService(ApplicationDbContext context,
			UserManager<Employee> userManager, ILeaveType leaveType, IMapper mapper,
			AutoMapper.IConfigurationProvider configurationProvider) : base(context)
		{
			_leaveType = leaveType;
			_mapper = mapper;
			_context = context;
			_configurationProvider = configurationProvider;
			_userManager = userManager;
		}

		public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
		{
			return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId && q.Period == period);
		}

		public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId)
		{
			var allocations = await _context.LeaveAllocations
				.Include(q => q.LeaveType)
				.Where(q => q.EmployeeId == employeeId)
				.ProjectTo<LeaveAllocationVM>(_configurationProvider)
				.ToListAsync();
				
			var employee = await _userManager.FindByIdAsync(employeeId);

			var employeeAllocationModel = _mapper.Map<EmployeeAllocationVM>(employee);
			employeeAllocationModel.LeaveAllocations = _mapper.Map<List<LeaveAllocationVM>>(allocations);
			// employeeAllocationModel.LeaveAllocations = _mapper.Map<List<LeaveAllocationVM>>(allocations);

			return employeeAllocationModel;
		}

public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id)
        {
            var allocation = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .ProjectTo<LeaveAllocationEditVM>(_configurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if(allocation == null)
            {
                return null;
            }

            var employee = await _userManager.FindByIdAsync(allocation.EmployeeId);

            var model = _mapper.Map<LeaveAllocationEditVM>(allocation);
            model.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(allocation.EmployeeId));

            return model;
        }

		public async Task LeaveAllocation(int leaveTypeId)
		{
			var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
			var period = DateTime.Now.Year;
			var leaveType = await _leaveType.GetAsync(leaveTypeId);
			var allocations = new List<LeaveAllocation>();
			var employeesWithNewAllocations = new List<Employee>();

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
				employeesWithNewAllocations.Add(employee);
				
			}
					await AddRangeAsync(allocations);
					foreach (var employee in employeesWithNewAllocations)
            {
                // await emailSender.SendEmailAsync(employee.Email, $"Leave Allocation Posted for {period}", $"Your {leaveType.Name} " +
                //     $"has been posted for the period of {period}. You have been given {leaveType.DefaultDays}.");
            }
		}

		 public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model)
        {
            var leaveAllocation = await GetAsync(model.Id);
            if (leaveAllocation == null)
            {
                return false;
            }
            leaveAllocation.Period = model.Period;
            leaveAllocation.NumberOfDays = model.NumberOfDays;
            await UpdateAsync(leaveAllocation);

            // var user = await _userManager.FindByIdAsync(leaveAllocation.EmployeeId);

            // await emailSender.SendEmailAsync(user.Email, $"Leave Allocation Updated for {leaveAllocation.Period}",
            //     "Please review your leave allocations.");

            return true;
        }

        public async Task<LeaveAllocation> GetEmployeeAllocation(string employeeId, int leaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId);
        }
	}
}