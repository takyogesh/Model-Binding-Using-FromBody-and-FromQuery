namespace WebApiUriBody
{
    public class EmployeeOrganization
    {
        public int Id { get; set; }
        public string? OrganizationName { get; set; } = null;
        public DateOnly JoiningDate { get; set; }
    }
}
