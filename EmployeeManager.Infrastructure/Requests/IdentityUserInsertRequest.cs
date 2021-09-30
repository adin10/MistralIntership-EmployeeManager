namespace EmployeeManager.Infrastructure.Requests
{
    public class IdentityUserInsertRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
        public string Telephon { get; set; }

        public string Email { get; set; }
    }
}
