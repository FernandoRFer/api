using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{

    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("/usuario")]
        public IActionResult Get([FromQuery] string? login) 
            {
            var model = new UsuarioRepository();

            var data = model.GetLogin(login);

            if (data.Rows.Count <= 0) return BadRequest();


            var dataJson = JsonConvert.SerializeObject(data, Formatting.Indented);

            return Ok(dataJson);


        }



        [HttpPost]
        [Route("/usuario")]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            var model = new UsuarioRepository();
            var constula = model.GetLoginConsulta(usuario.Login);

            if (!constula)
            {
                return BadRequest();
            }

            if (model.Add(usuario.Nome, usuario.Login, usuario.Senha, usuario.DataCadastro))
            {
                return Ok(usuario);
            }

            return BadRequest();

        }



        [HttpPut]        
        [Route("/usuario")]
        public IActionResult Put([FromBody] Usuario usuario)
        {
            var model = new UsuarioRepository();
            var constula = model.ConsultaId(usuario.Id);
            if (!constula) return BadRequest();

            var data = model.Put(usuario.Id,usuario.Nome,usuario.Login,usuario.Senha);

            return Ok(data);


        }



        [HttpDelete]
        [Route("/usuario")]
        public IActionResult Delete(int id)
        {
            var model = new UsuarioRepository();
            var constula = model.ConsultaId(id);

            if (constula) return BadRequest();

            model.Delete(id);

            if(!constula) return Ok();

            return BadRequest();

        }



    }



}


