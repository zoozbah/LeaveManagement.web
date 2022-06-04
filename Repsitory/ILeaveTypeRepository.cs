using LeaveManagement.web.Contracts;
using LeaveManagement.web.Data;

namespace LeaveManagement.web.Repsitory
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task GetAsync(LeaveType leaveType);
        bool Exists(int id);
    }
}
