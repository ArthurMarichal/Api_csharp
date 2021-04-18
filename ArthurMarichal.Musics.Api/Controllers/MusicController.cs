using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ArthurMarichal.Musics.Api.Controllers
{
    [ApiController]
    [Route("api/musics")]
    public class MusicController  :  ControllerBase
    {
        private readonly ILogger<MusicController> _logger;

        public MusicController(ILogger<MusicController> logger)
        {
            _logger = logger;
        }
        // Ceci va chercher 
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Action {ActionName} called", nameof(GetAll));
            return Ok();
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Read([FromRoute]int id)
        {
            _logger.LogInformation("Action {ActionName} called with parameter id = {Id}.", nameof(Read), id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Create([FromBody]CreateOrUpdateMusicRequest request)
        {
            _logger.LogInformation("Action {ActionName} called with body {ResquestBody}.", nameof(Create), request);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            _logger.LogInformation("Action {ActionName} called with parameter id = {Id}.", nameof(Delete), id);
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody]CreateOrUpdateMusicRequest request)
        {
            _logger.LogInformation("Action {ActionName} called with parameter id = {Id}, with body {RequestBody}", nameof(Update), id , request);
            return Ok();
        }
        
        
    }
}