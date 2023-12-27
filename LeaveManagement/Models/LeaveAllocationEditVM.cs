using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LeaveManagement.Models
{
    public class LeaveAllocationEditVM: LeaveAllocationVM
    {
    public EmployeeListVM Employee{ get; set; }
    
    }
}