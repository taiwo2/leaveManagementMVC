using System;
using System.Collections.Generic;
using LeaveManagement.Data;
using LeaveManagement.Models;
using AutoMapper;



namespace Leavemanagement.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
            // CreateMap<List<LeaveAllocation>, List<LeaveAllocationVM>>().ReverseMap();

            CreateMap<Employee, EmployeeAllocationVM>().ReverseMap();
            CreateMap<Employee, EmployeeListVM>().ReverseMap();
        }

    }
}