using Academic.Application.DTOs.Dashboard;
using Academic.Application.Interfaces.IRepository;
using Academic.Application.Interfaces;
using Academic.Core.Entities;

namespace Academic.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ICommonRepository<ApplicationUser> _userRepository;
        private readonly ICommonRepository<Student> _studentRepository;
        private readonly ICommonRepository<Branch> _branchRepository;
        private readonly ICommonRepository<Supervisor> _supervisorRepository;
        private readonly ICommonRepository<Group> _groupRepository;
        private readonly ICommonRepository<Permission> _permissionRepository;

        public DashboardService(ICommonRepository<ApplicationUser> userRepository,
            ICommonRepository<Student> studentRepository, 
            ICommonRepository<Branch> branchRepository, 
            ICommonRepository<Supervisor> supervisorRepository,
            ICommonRepository<Group> groupRepository,
            ICommonRepository<Permission> permissionRepository)
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository;
            _branchRepository = branchRepository;
            _supervisorRepository = supervisorRepository;
            _groupRepository = groupRepository;
            _permissionRepository = permissionRepository;
        }

        public async Task<DashboardDTO> GetDashboardDataAsync()
        {
            var dashboardData = new DashboardDTO
            {
                UsersCount = await _userRepository.CountAsync(),
                StudentsCount = await _studentRepository.CountAsync(),
                BranchesCount = await _branchRepository.CountAsync(),
                SupervisorsCount = await _supervisorRepository.CountAsync(),
                GroupsCount = await _groupRepository.CountAsync(),
                PermissionCount = await _permissionRepository.CountAsync()

            };

            return dashboardData;
        }
    }
}
