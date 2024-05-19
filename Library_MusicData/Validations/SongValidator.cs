using FluentValidation;
using Library_MusicData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MusicData.Validations
{
    public class SongValidator : AbstractValidator<SongsModel>
    {
        public SongValidator() {

            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El título de la canción es obligatorio")
                .MinimumLength(2).WithMessage("Debe contener mínimo 2 caracteres");

            RuleFor(x => x.SongLanguage)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El idioma de la canción es obligatorio")
                .MinimumLength(2).WithMessage("Debe contener mínimo 2 caracteres");

            RuleFor(x => x.AlbumID)
                .NotEmpty().WithMessage("El ID del álbum es obligatorio");
        }
    }
}
