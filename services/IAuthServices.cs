using EmployeeAPI.Models;

namespace EmployeeAPI.services
{
    public interface IAuthServices
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
    }
}
