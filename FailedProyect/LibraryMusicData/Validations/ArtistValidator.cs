﻿using FluentValidation;
using LibraryMusicManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMusicData.Validations
{
    public class ArtistValidator : AbstractValidator<ArtistModel>
    {
        public ArtistValidator() 
        {
            RuleFor(x => x.ArtistName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El Nombre artístico es obligatorio")
                .MinimumLength(2).WithMessage("Debe contener minimo 2 letras");

            RuleFor(x => x.RealName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El Nombre real es obligatorio")
                .MinimumLength(4).WithMessage("Debe contener mínimo 4 letras");

            RuleFor(x => x.ArtistName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El Nombre artístico es obligatorio")
                .MinimumLength(2).WithMessage("Debe contener mínimo 2 letras");

            RuleFor(x => x.RealLastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El apellido del artista es obligatorio")
                .MinimumLength(4).WithMessage("Debe contener mínimo 4 letras");

            RuleFor(x => x.Country)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El país del artista es obligatorio")
                .MinimumLength(4).WithMessage("Debe contener mínimo 4 letras");
        }
        

    }
}
