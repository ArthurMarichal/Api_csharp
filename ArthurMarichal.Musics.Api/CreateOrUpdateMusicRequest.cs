using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

namespace ArthurMarichal.Musics.Api
{
    public class CreateOrUpdateMusicRequest
    {
        //Contenu de l'API
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
    }
}