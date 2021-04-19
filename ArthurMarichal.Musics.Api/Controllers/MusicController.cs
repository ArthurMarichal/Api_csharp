using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ArthurMarichal.Musics.Api.Controllers
{
    [ApiController]
    [Route("api/musics")]
    public class MusicController  :  ControllerBase
    {
        //"_logger" permet de fournir des fonctionnalités par defaut pour les enregistreurs qui traitent les évements déclenchés par le moteur de génération.
        private readonly ILogger<MusicController> _logger;

        public MusicController(ILogger<MusicController> logger)
        {
            _logger = logger;
        }
        // Ceci va chercher  tous  ce qu'il y a dans ma base de données.
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Action {ActionName} called", nameof(GetAll));
            return Ok();
        }
        //Je vais chercher un objet spécifique grâce à son ID.
        [HttpGet]
        [Route("{id}")]
        public IActionResult Read([FromRoute]int id)
        {
            _logger.LogInformation("Action {ActionName} called with parameter id = {Id}.", nameof(Read), id);
            return Ok();
        }
        //Création  d'un objet.
        [HttpPost]
        public IActionResult Create([FromBody]CreateOrUpdateMusicRequest request)
        {
            _logger.LogInformation("Action {ActionName} called with body {ResquestBody}.", nameof(Create), request);
            return Ok();
        }
        //Suppréssion d'un objet.
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            _logger.LogInformation("Action {ActionName} called with parameter id = {Id}.", nameof(Delete), id);
            return Ok();
        }
        //Modification d'un objet.
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody]CreateOrUpdateMusicRequest request)
        {
            _logger.LogInformation("Action {ActionName} called with parameter id = {Id}, with body {RequestBody}", nameof(Update), id , request);
            return Ok();
        }
        
        
    }
}