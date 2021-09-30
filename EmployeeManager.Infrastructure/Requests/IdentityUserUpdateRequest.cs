namespace EmployeeManager.Infrastructure.Requests
{
    public class IdentityUserUpdateRequest
    {
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string Password { get; set; }

    }
}
