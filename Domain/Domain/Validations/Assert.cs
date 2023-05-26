namespace Domain.Validations
{
    internal static class Assert
    {
        internal static void NotNull(object item, string name = "item")
        {
            if (item is null)
            {
                throw new ArgumentNullException($"{name} can't be null.");
            }
        }
    }
}