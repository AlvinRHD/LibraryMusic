using Library_MusicData.Models;

namespace Library_MusicData.Repositories.Album
{
    public interface IAlbumRepository
    {
        Task AddAlbumAsync(AlbumsModel album);
        Task DeleteAlbumAsync(int id);
        Task EditAlbumAsync(AlbumsModel album);
        Task<AlbumsModel?> GetAlbumByIdAsync(int id);
        Task<IEnumerable<AlbumsModel>> GetAllAlbumsAsync();
        Task<IEnumerable<SongsModel>> GetSongsByAlbumIdAsync(int AlbumID);
    }
}