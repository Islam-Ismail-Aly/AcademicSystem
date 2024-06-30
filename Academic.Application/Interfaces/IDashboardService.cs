using Academic.Application.DTOs.Dashboard;

namespace Academic.Application.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardDTO> GetDashboardDataAsync();
    }
}
