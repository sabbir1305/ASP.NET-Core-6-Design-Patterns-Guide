namespace OperationDesignPatternAPI.SingleError
{
    public class Executor
    {
        public OperationResult Operation()
        {
            // Randomize the success indicator
            // This should be real logic
            var randomNumber = new Random().Next(100);
            var success = randomNumber % 2 == 0;

            // Return the operation result
            return success
                ? new()
                : new() { ErrorMessage = $"Something went wrong with the number '{randomNumber}'." };
        }
    }
}
