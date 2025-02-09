using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Shared.Abstraction.Domain
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        public Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
            {
                throw new ArgumentException("invalid Error", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, Error.None);

        public static Result<TValue> Success<TValue> (TValue value) => new(value, true, Error.None);

        public static Result Failure(Error error) => new(false, error);

        public static Result<TValue> Failure<TValue> (Error error) => new(default, false, error);
    }

    public class Result<TValue> : Result
    {
        private readonly TValue? value;

        public Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error) 
        {
            this.value = value;
        }

        [NotNull]
        public TValue Value => IsSuccess
            ? value!
            : throw new InvalidOperationException("The value of a failure result can't be accessed.");

        public static implicit operator Result<TValue>(TValue? value) => value is not null ? Success(value) : Failure<TValue>(Error.NullValue);

        public static Result<TValue> ValidationFailure(Error error) =>
            new(default, false, error);
    }
}
