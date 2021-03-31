﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0);
        }
    }
}
