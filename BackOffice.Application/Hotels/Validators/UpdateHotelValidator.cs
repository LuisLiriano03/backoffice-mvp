using BackOffice.Application.Hotels.DTOs;
using FluentValidation;

namespace BackOffice.Application.Hotels.Validators
{
    public class UpdateHotelValidator : AbstractValidator<UpdateHotel>
    {
        public UpdateHotelValidator() 
        {
            RuleFor(x => x.HotelName)
                .NotEmpty().WithMessage("The Hotel name is required.")
                .MaximumLength(20).WithMessage("The hotel name cannot exceed 50 characters.")
                .Matches("^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$")
                    .WithMessage("The Hotel name only accepts letters.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("The city name is required.")
                .MaximumLength(20).WithMessage("The city name cannot exceed 100 characters.")
                .Matches("^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$")
                    .WithMessage("The City name only accepts letters.");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("The country name is required.")
                .MaximumLength(20).WithMessage("The country name cannot exceed 100 characters.")
                .Matches("^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$")
                    .WithMessage("The country name only accepts letters.");

            RuleFor(x => x.IsActive)
                .Must(v => v == 0 || v == 1)
                .WithMessage("IsActive only accepts values 0 (inactive) or 1 (active).");

        }

    }

}
