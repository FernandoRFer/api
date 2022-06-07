using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("/playLista")]
        public IActionResult Get([FromQuery] int id)
        {
            var model = new PlayListRepository();
            var constula = model.ConsultaId(id);
            if (constula) return BadRequest();

            var data = model.GetId(id);

            var dataJson = JsonConvert.SerializeObject(data, Formatting.Indented);

            return Ok(dataJson);


        }



        [HttpPost]
        [Route("/playList")]
        public IActionResult Post([FromBody] PlayList playList)
        {
            var model = new PlayListRepository();
            var constula = model.ConsultaId(playList.Id);

            if (!constula)
            {
                return BadRequest();
            }

            if (model.Add(playList.Id, playList.IdUsuario, playList.Nome, playList.DataCadastro,playList.Alteracao))
            {
                return Ok(playList);
            }

            return BadRequest();

        }



        [HttpPut]
        [Route("/playList")]
        public IActionResult Put([FromBody] PlayList playList)
        {
            var model = new PlayListRepository();
            var constula = model.ConsultaId(playList.Id);

            if (!constula) return BadRequest();

            var data = model.Put(playList.Id,playList.Nome, playList.Alteracao);

            return Ok(data);


        }



        [HttpDelete]
        [Route("/playList")]
        public IActionResult Delete(int id)
        {
            var model = new UsuarioRepository();
            var constula = model.ConsultaId(id);

            if (constula) return BadRequest();

            model.Delete(id);

            if (!constula) return Ok();

            return BadRequest();

        }



    }



}