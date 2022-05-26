using System.Data;
using System.Data.SqlClient;

namespace API

{
    public class Sql
    {
        private SqlConnection cn;


        public Sql()
        {
            Conexao();
        }


        //string de conexão sql server c#
        private void Conexao()
        {
           
            string conec = "Data Source=FERNANDO\\SQLEXPRESS;Initial Catalog=Music;User ID=sa;Password=Api123456;Language=Portuguese";

            this.cn = new SqlConnection(conec);
        }


        //Abrir conexão
        private void AbrirConexao()
        {
            try
            {
                this.cn.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        private void FecharConexao()
        {
            try
            {
                this.cn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable ExecuteSelect(string sql)
        {
            try
            {
                AbrirConexao();

                SqlCommand sqlComm = new SqlCommand(sql, this.cn)
                {
                    CommandTimeout = 600
                };

                sqlComm.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(sqlComm);

                DataTable dt = new DataTable();
                da.Fill(dt);

                FecharConexao();

                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean ExecuteInsertUpdate(string sql)
        {
            try
            {
                AbrirConexao();
                SqlCommand sqlComm = new SqlCommand(sql, this.cn);

                sqlComm.ExecuteNonQuery();

                FecharConexao();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string ExecuteQueryComStringRetorno(string sql)
        {
            try
            {
                AbrirConexao();
                string dado;

                SqlCommand sqlComm = new SqlCommand(sql, this.cn);

                sqlComm.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(sqlComm);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dado = dt.Rows[0][0].ToString();

                FecharConexao();

                return dado;
            }
            catch
            {
                //throw e;
                FecharConexao();

                return "";
            }
        }

    }
}
