using API.DTO;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace API.Controllers
{
    [ApiController]

    public class MusicController : ControllerBase
    {
        [HttpGet]
        [Route("/music")]
        public IActionResult Get([FromQuery] string? filtroNome)
        {
            var model = new UsuarioRepository();

            var data = model.GetId(id);

            if (data.Rows.Count <= 0) return BadRequest();


            var dataJson = JsonConvert.SerializeObject(data, Formatting.Indented);

            return Ok(dataJson);

        }

        [HttpPost]             
        [Route("/music")]
        public IActionResult Post([FromBody] Music music )
        {
            var model = new MusicaCompletaRepository();
                var constula = model.GetMusicsC(music.NomeMusica);


            if (model.AddMusic(music.NomeMusica, music.Cifra))


            if (!constula)   return BadRequest();

            // if (musicModel.GetMusicsC(music.NomeMusica) == false) return BadRequest("Não foi possivel adicionar a musica");

            return Created(music.NomeMusica,music.Cifra);            

        }


       
        [HttpPut]
        [Route("/music")]
        public IActionResult Put([FromBody]  Music music)
        {
            var model = new MusicaCompletaRepository();
            var constula = model.GetMusicsID(music.Id);

            if (!constula) return BadRequest();

            var data = model.PutMusics(music.Id, music.NomeMusica, music.Cifra);

            return Ok(data);
            
        }       
       

        [HttpPatch]
        [Route("/musiccifra")]
        public IActionResult PatchCifra([FromBody] Music music)
        {

            var model = new MusicaCompletaRepository();
            var constula = model.GetMusicsID(music.Id);
            if (!constula) return BadRequest();

            var data = model.PatchCifra(music.Id, music.Cifra);

            //if(musicModelSaved is null) BadRequest("Não foi possivel atualizar a musica");
            return Ok(data);
        }

        [HttpDelete]
        [Route("/music")]
        public IActionResult Delete(int id )
        {
            var model = new MusicaCompletaRepository();
            var constula = model.GetMusicsID(id);
            if (!constula) return BadRequest("Não deletar");

            var data = model.Delete(id); 


            return Ok(data);

        }
        


    }
}
