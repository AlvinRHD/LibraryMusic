using LibraryMusicManagement.Data;
using LibraryMusicManagement.Models;

namespace LibraryMusicManagement.Repositories.Artis
{
    public class ArtistRepository : IArtistRepository
    {

        private readonly IDbDataAccess _dataAccess;

        public ArtistRepository(IDbDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<ArtisModel>> GetArtistAsync()
        {
            return await _dataAccess.GetDataAsync<ArtisModel, dynamic>(
                "spArtist_GetAll",
                new { }
                );
        }

        public async Task<ArtisModel?> GetArtistByIdAsync(int id)
        {
            var artist = await _dataAccess.GetDataAsync<ArtisModel, dynamic>(
                "spArtist_GetByID",
                new { ArtistID = id }
                );

            return artist.FirstOrDefault();
        }

        public async Task AddArtistAsync(ArtisModel artis)
        {
            await _dataAccess.SaveDataAsync(
                "spArtist_Insert",
                new { artis.ArtistName, artis.RealName, artis.RealLastName, artis.Country }
                );
        }

        public async Task EditArtistAsync(ArtisModel artis)
        {
            await _dataAccess.SaveDataAsync(
                "spArtist_Update",
                artis
                );
        }

        public async Task DeleteArtistAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "spArtist_Delete",
                new { ArtistID = id }
                );
        }


    }
}
