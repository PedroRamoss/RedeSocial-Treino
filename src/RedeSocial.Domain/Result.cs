
namespace RedeSocial.Doman
{
    public record Result
    {
        public bool IsSuccess { get; set; }
        public Error? Error { get; }

        public Result()
        {

        }
        protected Result(bool isSuccess, Error? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new (true, null);
        public static Result Failure(Error error) => new(false, error ?? throw new ArgumentNullException(nameof(error)));

        public static implicit operator Result(Error error) => Failure(error);
    }

    public record Result<T> : Result
    {
        public T? Response { get; }

        private Result(T value) : base(true, null) => Response = value;
        private Result(Error error) : base(false, error) { }

        public static Result<T> Success(T value) => new(value);
        public static Result<T> Failure(Error error) => new(error);

        public static implicit operator Result<T>(T value) => Success(value);
        public static implicit operator Result<T>(Error error) => Failure(error);
    }

    public enum ErrorType
    {
        NotFound = 204,
        Unauthorized = 401,
        BadRequest = 400,
        UnprocessableEntity = 422,
        Forbbiden = 403
    }

    public record Error(string Id, ErrorType Type, string Description);

    public record ErrorDescription(string error, string description);

    public static class Errors
    {
        public static Error AccountNotFound { get; } = new("AccountNotFound", ErrorType.NotFound, "Account not found.");
        public static Error Unauthorized { get; } = new("Login Fail", ErrorType.Unauthorized, "Failure when trying to login.");
        public static Error BadRequest { get; } = new("Bad Request", ErrorType.BadRequest, "Failure when creating user.");
        public static Error UnprocessableEntity { get; } = new("Unprocessable Entity", ErrorType.UnprocessableEntity, "Failure when update user.");
    }
}
