using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core
{
    public class Result<TValue, TError>
    {
        public readonly TValue? _value;
        public readonly TError? _error;

        public readonly bool _isSuccess;

        private Result(TValue value)
        {
            _isSuccess = true;
            _value = value;
            _error = default;
        }

        private Result(TError error)
        {
            _isSuccess = false;
            _value = default;
            _error = error;
        }

        public static implicit operator Result<TValue, TError>(TValue value) => new Result<TValue, TError>(value);

        public static implicit operator Result<TValue, TError>(TError error) => new Result<TValue, TError>(error);

        public Result<TValue, TError> Match()
        {
            if (_isSuccess)
            {
                return _value!;
            }
            return _error!;
        }
    }
}