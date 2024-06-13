using OzelDersApp.Entity.Concrete.Identity;
using OzelDersApp.Entity.Concrete;

namespace OzelDersApp.WebUI.Models.ViewModels
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public string Graduation { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Student> TeacherStudents { get; set; }
        public List<Branch> TeacherBranches { get; set; }
        public string ImageUrl { get; set; }
    }
}
