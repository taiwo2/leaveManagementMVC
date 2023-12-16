using LeaveManagement.Contracts;
using LeaveManagement.Data;

namespace LeaveManagement.Services
{
	public class LeaveTypeService : GenericService<LeaveType>, ILeaveType
	{
		public LeaveTypeService(ApplicationDbContext context) : base(context)
		{

		}
	}
}