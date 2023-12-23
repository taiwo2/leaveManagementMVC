using System.Reflection.Metadata.Ecma335;

namespace LeaveManagement.Models
{
    public class LeaveAllocationVM
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public int Period { get; set; }
        public LeaveTypeVM LeaveType { get; set; }

    }
}