using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LeaveManagement.Models
{
    public class LeaveAllocationEditVM: LeaveAllocationVM
    {
        public string EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public EmployeeListVM? Employee{ get; set; }
    
    }
}