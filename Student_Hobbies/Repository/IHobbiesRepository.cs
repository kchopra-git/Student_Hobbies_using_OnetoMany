using Student_Hobbies.Model;

namespace Student_Hobbies.Repository
{
    public interface IHobbiesRepository
    {
        IEnumerable<ReturnModel> GetAllHobbies();
        Hobbies GetHobbyById(int id);
        void AddHobby(Hobbies hobby);
        void UpdateHobby(Hobbies hobby);
        void DeleteHobby(int id);
    }
}
