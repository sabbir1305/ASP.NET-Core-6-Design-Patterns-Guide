namespace OperationDesignPatternAPI.SingleErrorWithValue
{
    public record class OperationResult
    {
        public bool Succeeded => string.IsNullOrWhiteSpace(ErrorMessage);
        public string? ErrorMessage { get; init; }
        public int? Value { get; init; }
    }
}
