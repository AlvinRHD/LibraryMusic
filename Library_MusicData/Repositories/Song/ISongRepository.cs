using Library_MusicData.Models;

namespace Library_MusicData.Repositories.Song
{
    public interface ISongRepository
    {
        Task AddSongAsync(SongsModel song);
        Task DeleteSongAsync(int id);
        Task EditSongAsync(SongsModel song);
        Task<IEnumerable<SongsModel>> GetAllSongsAsync();
        Task<SongsModel?> GetSongByIdAsync(int id);
    }
}