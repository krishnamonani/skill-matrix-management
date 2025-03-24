using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.Shared
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public List<string> Errors { get; set; }

        private ServiceResponse()
        {
            Errors = new List<string>();
        }

        public static ServiceResponse<T> SuccessResult(T data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            return new ServiceResponse<T>
            {
                Success = true,
                Data = data,
                Errors = new List<string>()
            };
        }

        public static ServiceResponse<T> Failure(string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage))
                throw new ArgumentNullException(nameof(errorMessage));

            return new ServiceResponse<T>
            {
                Success = false,
                ErrorMessage = errorMessage,
                Errors = new List<string> { errorMessage }
            };
        }

        public static ServiceResponse<T> Failure(List<string> errors)
        {
            errors = errors?.Where(e => !string.IsNullOrEmpty(e)).ToList() ?? new List<string>();

            return new ServiceResponse<T>
            {
                Success = false,
                ErrorMessage = errors.Any() ? "Multiple errors occurred" : null,
                Errors = errors
            };
        }

        public static ServiceResponse<T> Failure(string errorMessage, List<string> errors)
        {
            if (string.IsNullOrEmpty(errorMessage))
                throw new ArgumentNullException(nameof(errorMessage));

            errors = errors?.Where(e => !string.IsNullOrEmpty(e)).ToList() ?? new List<string>();

            return new ServiceResponse<T>
            {
                Success = false,
                ErrorMessage = errorMessage,
                Errors = errors
            };
        }
    }
}
