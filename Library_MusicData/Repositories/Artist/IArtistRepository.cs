using Library_MusicData.Models;

namespace Library_MusicData.Repositories.Artist
{
    public interface IArtistRepository
    {
        Task AddArtistAsync(ArtistModel artist);
        Task DeleteArtistAsync(int id);
        Task EditArtistAsync(ArtistModel artist);
        Task<IEnumerable<ArtistModel>> GetAllArtistAsync();
        Task<ArtistModel?> GetArtistByIdAsync(int id);
    }
}