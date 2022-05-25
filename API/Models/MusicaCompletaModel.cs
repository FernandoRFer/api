﻿using API.DTO;
using System.Data;
using System.Data.SqlClient;

namespace API.Models
{
    public class MusicaCompletaModel
    {
        private Sql sql { get; set; }

        public MusicaCompletaModel()
        {
            sql = new Sql();
        }

        public DataTable GetMusics(string? filtroNome)
        {
            var query = "Select * From MusicaCompleta WHERE NomeMusica LIKE '%" + filtroNome + "%'";

            var data = sql.ExecuteSelect(query);

            return data;
        }

        public bool PatchDelete(int id)
        {
            var query = "DELETE FROM MusicaCompleta  WHERE id = '" + id + "' ";
            var data = sql.ExecuteSelect(query);

            return true;

        }

        public bool PutMusics(int id ,string nomeMuisca , string cifra)

        {           

            var query = "update MusicaCompleta set NomeMusica = '" + nomeMuisca +"', cifra = '"+cifra+ "'  WHERE id = '"+id+"' ";

            var data = sql.ExecuteSelect(query);

            return true;
        }

        public bool PatchNome(int id, string nomeMuisca)

        {

            var query = "update MusicaCompleta set NomeMusica = '" + nomeMuisca + "'  WHERE id = '" + id + "' ";

            var data = sql.ExecuteSelect(query);

            return true;
        }

        public bool PatchCifra(int id, string Cifra)

        {

            var query = "update MusicaCompleta set NomeMusica = '" + Cifra + "'  WHERE id = '" + id + "' ";

            var data = sql.ExecuteSelect(query);

            return true;
        }

        public bool GetMusicsC(string? consulta)
        {
            var query = "Select * From MusicaCompleta WHERE NomeMusica = '" + consulta + "'";

            var data = sql.ExecuteSelect(query);

            if (data.Rows.Count > 0) return false;

            return true;
        }



        public bool AddMusic(string NomeMusica, string Cifra)
        {
            var query = "INSERT INTO MusicaCompleta (NomeMusica, Cifra) VALUES ('" + NomeMusica + "', '" + Cifra + "')";

            var data = sql.ExecuteInsertUpdate(query);

            return data;
        }
    }
}
