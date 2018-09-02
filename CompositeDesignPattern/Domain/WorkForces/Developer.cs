using CompositeDesignPattern.Domain.Exceptions;
using CompositeDesignPattern.Domain.Tasks;
using System;

namespace CompositeDesignPattern.Domain.WorkForces
{
    public class Developer : BaseWorkForce, IWorkForce
    {
        public Developer(string name)=> 
            Name = name;

        public Developer(string name, ITask task)
        {
            Name = name;
            CurrentTask = task;
        }

        public override void Abandon(ITask task) =>
            throw new TaskManagerRightsException($"You don't have the rights to abandon {nameof(task)}");

        public override void Attribute(ITask task, IWorkForce name) =>
            throw new TaskManagerRightsException($"You don't have the rights to attribute {nameof(task)} to the {nameof(name)}");

        public override bool IsTaskManagable(ITask task)
        {
            return task.Equals(CurrentTask);
        }

        public override void Terminate(ITask task) =>
            throw new TaskManagerRightsException($"You don't have the rights to terminate {nameof(task)}");
    }
}