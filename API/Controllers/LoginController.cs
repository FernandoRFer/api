using API.DTO;
using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Web;


namespace API.Controllers
{
    
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("/login")]
        public IActionResult Post([FromBody] LoginDTO loginDTO)
        {
           

            var model = new LoginRepository();

            var data = model.Post(loginDTO.Login, loginDTO.Senha);
                                            

            if (data.Rows.Count == 0) return Unauthorized();



            var usuario = new Usuario
            {
                Id = int.Parse(data.Rows[0]["id"].ToString()),
                Nome = data.Rows[0]["Nome"].ToString(),
                Login = data.Rows[0]["Login"].ToString(),
                Senha = data.Rows[0]["senha"].ToString(),
                DataCadastro = DateTime.Parse(data.Rows[0]["datacadastro"].ToString()),


            };



            var dataJson = JsonConvert.SerializeObject(usuario, Formatting.Indented);

            //usuario = JsonConvert.SerializeObject(data);

            //var dJson = JsonConvert.DeserializeAnonymousType(data,usuario);


            return Ok(dataJson);


        }
    }
}
