using AutoMapper;
using LeaveManagement.web.Data;
using LeaveManagement.web.Models;
namespace LeaveManagement.web.Configuration
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeV>().ReverseMap();

        
        
        }
    
    }
}
