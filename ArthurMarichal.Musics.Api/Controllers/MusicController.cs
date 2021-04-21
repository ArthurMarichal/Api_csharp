using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ArthurMarichal.Musics.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ArthurMarichal.Musics.Api.Controllers
{
    [ApiController]
    [Route("api/musics")]
    public class MusicController : ControllerBase
    {
        //"_logger" permet de fournir des fonctionnalités par defaut pour les enregistreurs qui traitent les évements déclenchés par le moteur de génération.
        // Il va nous servir à voir difféntes choses tel que le bon fonctionnement.
        private readonly ILogger<MusicController> _logger;
        private readonly MusicContext _musicContext;

        public MusicController(ILogger<MusicController> logger, MusicContext musicContext)
        {
            _logger = logger;
            _musicContext = musicContext;
        }

        // Ceci va chercher  tous  ce qu'il y a dans ma base de données.
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Action {ActionName} called", nameof(GetAll));
            return Ok(_musicContext.Musics.ToList());
        }

        //Je vais chercher un objet spécifique grâce à son ID.
        [HttpGet]
        [Route("{id}")]
        public IActionResult Read([FromRoute] int id)
        {
            _logger.LogInformation("Action {ActionName} called with parameter id = {Id}.", nameof(Read), id);
            var music = _musicContext.Musics.Find(id);
            if (music == null)
            {
                return NotFound();
            }

            return Ok(music);
        }

        //Création  d'un objet.
        [HttpPost]
        public IActionResult Create([FromBody] CreateOrUpdateMusicRequest request)
        {
            _logger.LogInformation("Action {ActionName} called with body {ResquestBody}.", nameof(Create), request);
            _musicContext.Musics.Add(new Music()
            {
                Album = request.Album,
                Artist = request.Artist,
                Title = request.Title
            });
            _musicContext.SaveChanges();
            return Ok();
        }

        //Suppréssion d'un objet.
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _logger.LogInformation("Action {ActionName} called with parameter id = {Id}.", nameof(Delete), id);
            var music = _musicContext.Musics.Find(id);
            if (music == null)
            {
                return NotFound();
            }

            _musicContext.Remove(music);
            _musicContext.SaveChanges();
            return Ok();
        }
    
        //Modification d'un objet.
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody]CreateOrUpdateMusicRequest request)
        {
            _logger.LogInformation("Action {ActionName} called with parameter id = {Id}, with body {RequestBody}", nameof(Update), id , request);
            var music = _musicContext.Musics.Find(id);
            if (music == null)
            {
                return NotFound();
            }

            music.Album = request.Album;
            music.Title = request.Title;
            music.Artist = request.Artist;
            _musicContext.SaveChanges();
            
            return Ok();
        }
    }
        
        
}