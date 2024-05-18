using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MusicData.Models
{
    public class AlbumsModel
    {
        public int AlbumID { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }
        
        public string Genre { get; set; }

        public int ArtistID { get; set; }

    }
}
