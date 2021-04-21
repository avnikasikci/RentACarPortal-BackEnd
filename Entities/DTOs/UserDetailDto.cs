using Core.Entities;

namespace Entities.DTOs
{
    public class UserDetailDto : IDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public int userOperationClaimId { get; set; }
        public int OperationClaimId { get; set; }
        public string OperationClaimName { get; set; }
        public string RoleName { get; set; }

    }
}