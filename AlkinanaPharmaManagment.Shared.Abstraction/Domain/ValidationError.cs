﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Shared.Abstraction.Domain
{
    public sealed record ValidationError : Error
    {
        public Error[] Errors { get; }

        public ValidationError(Error[] errors)
           : base(
            "Validation.General",
            "One or more validation errors occurred",
            ErrorType.Validation
            )
        {
            Errors = errors;
        }

        public static ValidationError FromResults(IEnumerable<Result> results) =>
            new(results.Where(r => r.IsFailure).Select(r => r.Error).ToArray());
    }
}
