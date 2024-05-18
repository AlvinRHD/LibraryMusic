using Library_MusicData.Data;
using Library_MusicData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MusicData.Repositories.Song
{
    public class SongRepository
    {
        private readonly IDbDataAccess _dataAccess;

        public SongRepository(IDbDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

    }
}
