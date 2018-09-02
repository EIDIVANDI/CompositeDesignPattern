namespace CompositeDesignPattern.Domain
{
    public enum TaskStatus
    {
        None = 0,
        Ready ,
        InProgress,
        InValidation,
        Validated,
        Terminated,
        Abandon
    }
}