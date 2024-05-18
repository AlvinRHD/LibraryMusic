using Library_MusicData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MusicData.Repositories.Album
{
    public class AlbumRepository
    {
        private readonly IDbDataAccess _dataAccess;

        public AlbumRepository(IDbDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

    }
}
