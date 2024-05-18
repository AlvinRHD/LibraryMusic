using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_MusicData.Data;
using Library_MusicData.Models;

namespace Library_MusicData.Repositories.Artist
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly IDbDataAccess _dataAccess;

        public ArtistRepository(IDbDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<ArtistModel>> GetAllArtistAsync()
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
