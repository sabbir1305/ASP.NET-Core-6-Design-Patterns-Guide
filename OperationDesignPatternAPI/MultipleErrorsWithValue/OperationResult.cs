using System.Collections.Immutable;

namespace OperationDesignPatternAPI.MultipleErrorsWithValue
{
    public class OperationResult
    {
        public ImmutableList<string> Errors { get; init; }
        public int? Value { get; init; }
        public OperationResult()
        {
            Errors = ImmutableList<string>.Empty;
        }

        public OperationResult(params string[] errors)
        {
            this.Errors = errors.ToImmutableList();
        }

        public bool Succeeded => !HasErrors();

        public bool HasErrors()
        {
            return Errors?.Count > 0;
        }
    }
}
