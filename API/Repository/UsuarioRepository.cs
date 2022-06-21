using System.Data;

namespace API.Repository
{
    public class UsuarioRepository
    {
        private Sql sql { get; set; }

        public UsuarioRepository()
        {
            sql = new Sql();
        }
        public bool Add(string nome, string login,string senha, DateTime datacatastro)
        {
            var query = "INSERT INTO Usuario (Nome, login, senha, datacadastro ) VALUES ('" + nome + "', '" + login + "', '" + senha + "', '" + datacatastro + "')";

            var data = sql.ExecuteInsertUpdate(query);

            return data;
        }

        public bool ConsultaId(int id)
        {
            var query = "Select * From Usuario Where Id = '" + id + "'";

            var data = sql.ExecuteSelect(query);

            if (data.Rows.Count > 0) return false;

            return true;

        }

        public DataTable GetId(int id)
        {
            var query = "Select * From Usuario Where Id = '" + id + "'";

            var data = sql.ExecuteSelect(query);

            
            return data;

        }




        public DataTable GetLogin(string? login)
        {
            var query = "Select * From Usuario WHERE Login = '" + login + "'";

            var data = sql.ExecuteSelect(query);

            return data;
        }

        public bool GetLoginConsulta(string login)
        {
            var query = "Select * From Usuario Where Id = '" + login + "'";

            var data = sql.ExecuteSelect(query);

            if (data.Rows.Count > 0) return false;

            return true;

        }

        public bool Delete (int id)
        {
            var query = "DELETE FROM usuario WHERE id = '" + id + "' ";

            sql.ExecuteSelect(query);

            return true;
        }


        public bool Put(int id,string nome, string login, string senha)
        {
            var query = "update Usiario set Nome = '" + nome + "', login = '" + login + "', senha = '" +senha+ "' WHERE id = '" + id + "' ";
            
            var data = sql.ExecuteInsertUpdate(query);


            return data;
        }

    }
}
