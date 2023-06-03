using System.Collections.Generic;

namespace Infrastructure.Common
{
    public class OperationResult<T>
    {
        public T Entity { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public bool Success { get; set; } = true;

        public OperationResult<T> AddError(string error)
        {
            this.Success = false;
            this.Errors.Add(error);
            return this;
        }

        public OperationResult<T> AddError(List<string> errors)
        {
            this.Success = false;
            this.Errors.AddRange(errors);
            return this;
        }
    }
}
