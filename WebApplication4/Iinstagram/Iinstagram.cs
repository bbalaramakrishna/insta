using System.Data;
using WebApplication4.Dtoinstagram;

namespace WebApplication4.Iinstagram
{
    public interface IinstagramLogic
    {
        Task<List<Instagramdto>> ECEData(int id);
        public void InsertData(Instagramdto dtoinstagram);
        public bool updateData(int id, string firstName);
        public bool DeleteData(int Id);

    }
}
