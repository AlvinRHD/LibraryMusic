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

        public async Task<IEnumerable<ArtistModel>> GetArtistAsync()
        {
            return await _dataAccess.GetDataAsync<ArtistModel, dynamic>(
                "spArtist_GetAll",
                new { }
                );
        }

        public async Task<ArtistModel?> GetArtistByIdAsync(int id)
        {
            var artist = await _dataAccess.GetDataAsync<ArtistModel, dynamic>(
                "spArtist_GetByID",
                new { ArtistID = id }
                );

            return artist.FirstOrDefault();
        }

        public async Task AddArtistAsync(ArtistModel artist)
        {
            await _dataAccess.SaveDataAsync(
                "spArtist_Insert",
                new { artist.ArtistName, artist.RealName, artist.RealLastName, artist.Country }
                );
        }

        public async Task EditArtistAsync(ArtistModel artist)
        {
            await _dataAccess.SaveDataAsync(
                "spArtist_Update",
                artist
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
