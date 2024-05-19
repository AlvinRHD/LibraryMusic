using Library_MusicData.Data;
using Library_MusicData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MusicData.Repositories.Song
{
    public class SongRepository : ISongRepository
    {
        private readonly IDbDataAccess _dataAccess;

        public SongRepository(IDbDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<IEnumerable<SongsModel>> GetAllSongsAsync()
        {
            return await _dataAccess.GetDataAsync<SongsModel, dynamic>(
                "spSongs_GetAll",
                new { }
            );
        }

        public async Task<SongsModel?> GetSongByIdAsync(int id)
        {
            var songs = await _dataAccess.GetDataAsync<SongsModel, dynamic>(
                "spSongs_GetByID",
                new { SongID = id }
            );

            return songs.FirstOrDefault();
        }

        public async Task AddSongAsync(SongsModel song)
        {
            await _dataAccess.SaveDataAsync(
                "spSongs_Insert",
                new { song.Title, song.SongLanguage, song.AlbumID }
            );
        }

        public async Task EditSongAsync(SongsModel song)
        {
            await _dataAccess.SaveDataAsync(
                "spSongs_Update",
                new { song.SongID, song.Title, song.SongLanguage, song.AlbumID }
            );
        }

        public async Task DeleteSongAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "spSongs_Delete",
                new { SongID = id }
            );
        }

    }
}
