using System.Data;

namespace API.Repository
{    
        public class PlayListRepository
        {
            private Sql sql { get; set; }

            public PlayListRepository()
            {
                sql = new Sql();
            }
            public bool Add(int id,int idUsuario ,string nome, DateTime datacatastro, DateTime alteracao)
            {
                var query = "INSERT INTO PlayList (id, idusuario, Nome, login, senha, datacadastro,  ) VALUES ('" + id + "','" + idUsuario + "','" + nome + "', '" + datacatastro + "' , '" + alteracao +"')";

                var data = sql.ExecuteInsertUpdate(query);

                return data;
            }

            public bool ConsultaId(int id)
            {
                var query = "Select * From PlayList Where Id = '" + id + "'";

                var data = sql.ExecuteSelect(query);

                if (data.Rows.Count > 0) return false;

                return true;

            }

            public DataTable GetId(int id)
            {
                var query = "Select * From PlayList Where Id = '" + id + "'";

                var data = sql.ExecuteSelect(query);


                return data;

            }


            public bool Delete(int id)
            {
                var query = "DELETE FROM usuario WHERE id = '" + id + "' ";

                sql.ExecuteSelect(query);

                return true;
            }


            public bool Put(int id, string nome, DateTime ateracao)
            {
                var query = "update playlist set Nome = '" + nome + "', ateracao = '" + ateracao + "'WHERE id = '" + id + "' ";

                var data = sql.ExecuteInsertUpdate(query);


                return data;
            }

        }
    }
