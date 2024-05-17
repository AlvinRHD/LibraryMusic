using LibraryMusicManagement.Models;

namespace LibraryMusicManagement.Repositories.Artis
{
    public interface IArtisRepository
    {
        Task AddArtistAsync(ArtisModel artis);
        Task DeleteArtistAsync(int id);
        Task EditArtistAsync(ArtisModel artis);
        Task<IEnumerable<ArtisModel>> GetArtistAsync();
        Task<ArtisModel?> GetArtistByIdAsync(int id);
    }
}