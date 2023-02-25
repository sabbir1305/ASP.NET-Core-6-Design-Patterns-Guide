namespace OperationDesignPatternAPI.StaticFactoryMethod
{
    public abstract record class OperationResult
    {
        public OperationResult() { }

        public abstract bool Succeeded { get; }

        public static OperationResult Success(int? value = null)
        {
            return new SuccessfulOperationResult { Value = value };
        }

        public static OperationResult Failure(params OperationResultMessage[] errors)
        {
            return new FailedOperationResult(errors);
        }
    }
}
