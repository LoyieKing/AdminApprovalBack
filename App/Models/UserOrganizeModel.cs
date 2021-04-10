namespace AdminApprovalBack.Models
{
    public class UserOrganizeModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrganizeId { get; set; }
        public int DutyLevel { get; set; }
    }
}