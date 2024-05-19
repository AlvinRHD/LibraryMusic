using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MusicData.Models
{
    public class SongsModel
    {
        public int SongID { get; set; }

        public string Title { get; set;}

        public string SongLanguage { get; set; }

        // ID del album al que pertenece esta canción
        public int AlbumID { get; set; }

    }
}
