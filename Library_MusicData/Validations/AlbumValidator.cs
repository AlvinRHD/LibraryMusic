using FluentValidation;
using Library_MusicData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MusicData.Validations
{
    public class AlbumValidator : AbstractValidator<AlbumsModel>
    {
        public AlbumValidator() 
        {

            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El título del álbum es obligatorio")
                .MinimumLength(2).WithMessage("Debe contener mínimo 2 caracteres");

            RuleFor(x => x.ReleaseDate)
                .NotEmpty().WithMessage("La fecha de lanzamiento del álbum es obligatoria");

            RuleFor(x => x.Genre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El género del álbum es obligatorio")
                .MinimumLength(2).WithMessage("Debe contener mínimo 2 caracteres");

            RuleFor(x => x.ArtistID)
                .NotEmpty().WithMessage("El ID del artista es obligatorio");

        }
        
    }
}
