using LeaveManagement.Data;

namespace LeaveManagement.Models
{
    public class EmployeeAllocationVM   :  EmployeeListVM
    {
        public List<LeaveAllocationVM> leaveAllocations { get; set; }
    }
}