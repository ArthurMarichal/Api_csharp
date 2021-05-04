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
        private readonly ILogger<MusicController> _logger;
        private readonly MusicContext _musicContext;

        public MusicController(ILogger<MusicController> logger, MusicContext musicContext)
        {
            _logger = logger;
            _musicContext = musicContext;
        }

        // Ceci va chercher  tous  ce qu'il y a dans ma base de données.
        /// <summary>
        /// Trouve toutes les musique.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Action {ActionName} called", nameof(GetAll));
            return Ok(_musicContext.Musics.ToList());
        }

        //Je vais chercher un objet spécifique grâce à son ID.
        /// <summary>
        /// Trouve une musique spécifique via son ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Read([FromRoute] int id)
        {
            _logger.LogInformation("Action {ActionName} called with id = {Id}.", nameof(Read), id);
            var music = _musicContext.Musics.Find(id);
            if (music == null)
            {
                return NotFound();
            }

            return Ok(music);
        }

        //Création  d'un objet.
        /// <summary>
        /// Ajout d'une musique à la base de donnée.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Suppréssion d'une musique via son ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _logger.LogInformation("Action {ActionName} called with id = {Id}.", nameof(Delete), id);
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
        /// <summary>
        /// Modification d'une musique précise avec son ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody]CreateOrUpdateMusicRequest request)
        {
            _logger.LogInformation("Action {ActionName} called with id = {Id}, with body {RequestBody}", nameof(Update), id , request);
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