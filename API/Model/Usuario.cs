﻿using System.Data;

namespace API.Model
{
    public class Usuario
    {
        


        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
       


    }
}
