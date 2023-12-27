using LeaveManagement.Data;

namespace LeaveManagement.Models
{
    public class EmployeeAllocationVM:  EmployeeListVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
    }
}