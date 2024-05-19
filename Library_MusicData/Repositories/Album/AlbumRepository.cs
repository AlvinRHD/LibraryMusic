using Library_MusicData.Data;
using Library_MusicData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MusicData.Repositories.Album
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly IDbDataAccess _dataAccess;

        public AlbumRepository(IDbDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        

        public async Task<IEnumerable<AlbumsModel>> GetAllAlbumsAsync()
        {
            var albums = await _dataAccess.GetDataAsync<AlbumsModel, dynamic>(
                "spAlbums_GetAll",
                new { }
            );

            foreach (var album in albums)
            {
                album.Songs = (List<SongsModel>)await GetSongsByAlbumIdAsync(album.AlbumID);
            }

            return albums;
        }


        public async Task<AlbumsModel?> GetAlbumByIdAsync(int id)
        {
            var album = await _dataAccess.GetDataAsync<AlbumsModel, dynamic>(
                "spAlbums_GetByID",
                new { AlbumID = id }
            );

            if (album.Any())
            {
                var albumModel = album.First();
                albumModel.Songs = (List<SongsModel>)await GetSongsByAlbumIdAsync(id);
                return albumModel;
            }

            return null;
        }

        public async Task AddAlbumAsync(AlbumsModel album)
        {
            await _dataAccess.SaveDataAsync(
                "spAlbums_Insert",
                new { album.Title, album.ReleaseDate, album.Genre, album.ArtistID }
            );
        }

        public async Task EditAlbumAsync(AlbumsModel album)
        {
            await _dataAccess.SaveDataAsync(
                "spAlbums_Update",
                new { album.AlbumID, album.Title, album.ReleaseDate, album.Genre, album.ArtistID }
            );
        }


        public async Task DeleteAlbumAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "spAlbums_Delete",
                new { AlbumID = id }
            );
        }

        public async Task<IEnumerable<SongsModel>> GetSongsByAlbumIdAsync(int id)
        {
            return await _dataAccess.GetDataAsync<SongsModel, dynamic>(
                "spSongs_GetByAlbumID",
                new { AlbumID = id }
            );
        }
        

    }
}
