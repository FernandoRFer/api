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
            var musicModel = new MusicaCompletaModel();

            var data = musicModel.GetMusics(filtroNome);

            if (data == null) return BadRequest();

            var dataJson = JsonConvert.SerializeObject(data, Formatting.Indented);

            return Ok(dataJson);
        }

        [HttpPost]             
        [Route("/music")]
        public IActionResult Post([FromBody] Music music )
        {
            var musicModel = new MusicaCompletaModel();
                var constula = musicModel.GetMusicsC(music.NomeMusica);


            if (musicModel.AddMusic(music.NomeMusica, music.Cifra))


            if (!constula)   return BadRequest("Não foi possivel adicionar a musica");

            // if (musicModel.GetMusicsC(music.NomeMusica) == false) return BadRequest("Não foi possivel adicionar a musica");

            return Created(music.NomeMusica,music.Cifra);            

        }


       
        [HttpPut]
        [Route("/music")]
        public IActionResult Put([FromBody]  Music music)
        {
            var musicModel = new MusicaCompletaModel();
            var constula = musicModel.GetMusicsID(music.Id);

            if (!constula) return BadRequest("Não foi possivel adicionar a musica");

            var data = musicModel.PutMusics(music.Id, music.NomeMusica, music.Cifra);

            return Ok(data);
            
        }
       
       [HttpPatch]
       [Route("/music")]
       public IActionResult PatchNomeMusica([FromBody] Music music)
        {

            var musicModel = new MusicaCompletaModel();
            var constula = musicModel.GetMusicsID(music.Id);
            if (!constula) return BadRequest("Não foi possivel adicionar a musica");

            var data = musicModel.PatchNomeMusica(music.Id, music.NomeMusica);

            //if(musicModelSaved is null) BadRequest("Não foi possivel atualizar a musica");
            return Ok(data);
        }

        [HttpPatch]
        [Route("/musiccifra")]
        public IActionResult PatchCifra([FromBody] Music music)
        {

            var musicModel = new MusicaCompletaModel();
            var constula = musicModel.GetMusicsID(music.Id);
            if (!constula) return BadRequest("Não foi possivel adicionar a musica");

            var data = musicModel.PatchCifra(music.Id, music.Cifra);

            //if(musicModelSaved is null) BadRequest("Não foi possivel atualizar a musica");
            return Ok(data);
        }

        [HttpDelete]
        [Route("/music")]
        public IActionResult Delete(int id )
        {
            var musicModel = new MusicaCompletaModel();
            var constula = musicModel.GetMusicsID(id);
            if (!constula) return BadRequest("Não foi possivel adicionar a musica");

            var data = musicModel.PatchDelete(id); 


            return Ok(data);

        }
        


    }
}
