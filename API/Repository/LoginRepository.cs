using System.Data;

namespace API.Repository
{
    public class LoginRepository
    {
        private Sql sql { get; set; }

        public LoginRepository()
        {
            sql = new Sql();
        }

        public DataTable Post(string login,string senha )
        {
            string query = "Select top 1 * From Usuario Where login = '" + login + "' and senha = '"+ senha + "'";


            var data = sql.ExecuteSelect(query);

            

            return data;


        }


    }
}
