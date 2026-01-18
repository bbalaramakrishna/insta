using System.Data;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using WebApplication4.Dtoinstagram;
using WebApplication4.Iinstagram;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;


namespace WebApplication4.Logic
{
    public class instagramlogic: IinstagramLogic
    {
        static string connectionstring
       = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Student;Integrated Security=True;";
         
        public async Task<List<Instagramdto>> ECEData(int id)
        {
            IDbConnection conn = new SqlConnection(connectionstring); 
            conn.Open();
           var dto =   await conn.QueryAsync<Instagramdto>("select * from EceC where id = @Id",new{Id = id});
            conn.Close();
            return dto.ToList();

        }
        
        
        public async void InsertData(Instagramdto dtoinstagram)
        {

            IDbConnection conn = new SqlConnection(connectionstring);
              conn.Open();
            
              await conn.QueryAsync<Instagramdto>("Insert into ECEC(id,firstname,lastname,marks) " +
               "VALUES(@Id,@firstname,@lastname,@marks) "
               , new { Id = dtoinstagram.Id,
                       firstname = dtoinstagram.firstname,
                       lastname = dtoinstagram.lastname,
                       marks = dtoinstagram.marks
               });
              conn.Close();
        }
        public bool updateData(int id,string firstName)
        {
            IDbConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            // Use Execute for non-query command; returns number of rows affected
            var rows = conn.Execute("Update ECEC Set Firstname = @fname where id = @id", new { Id = id, fname = firstName });
            conn.Close();

            bool result = rows > 0;
            return result;
        }
        public bool DeleteData(int Id)
        {
            IDbConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            // Use Execute for non-query command; returns number of rows affected
            var rows = conn.Execute("DELETE FROM ECEC WHERE id = @Id", new { Id = Id });
            conn.Close();
            
             bool result =   rows > 0;
            return result;
        }
    }
}
