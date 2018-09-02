namespace CompositeDesignPattern.Domain.WorkForces
{
    using CompositeDesignPattern.Domain.Tasks;

    public interface IWorkForce
    {
        string Name { get; set; }
        ITask CurrentTask { get; set; }
        bool IsTaskManagable(ITask task);
        void Attribute(IWorkForce name);
        void Attribute(ITask task, IWorkForce name);
        void TakeInCharge(ITask task);
        void Abandon();
        void Abandon(ITask task);
        void AskValidatation();
        void Validate();
        void Validate(ITask task);
        void Terminate();
        void Terminate(ITask task);
    }

}
