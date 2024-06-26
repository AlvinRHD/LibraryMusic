﻿using LibraryMusicManagement.Models;

namespace LibraryMusicManagement.Repositories.Artist
{
    public interface IArtistRepository
    {
        Task AddArtistAsync(ArtistModel artist);
        Task DeleteArtistAsync(int id);
        Task EditArtistAsync(ArtistModel artist);
        Task<IEnumerable<ArtistModel>> GetArtistAsync();
        Task<ArtistModel?> GetArtistByIdAsync(int id);
    }
}