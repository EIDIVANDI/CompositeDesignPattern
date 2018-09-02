using System;
using System.Collections.Generic;
using System.Text;
using CompositeDesignPattern.Domain.Tasks;

namespace CompositeDesignPattern.Domain.WorkForces
{
    public abstract class BaseWorkForce : IWorkForce
    {
        public string Name { get; set; }

        public ITask CurrentTask { get; set; }

        public abstract bool IsTaskManagable(ITask task);
        public abstract void Abandon(ITask task);

        public abstract void Attribute(ITask task, IWorkForce name);

        public abstract void Terminate(ITask task);

        public void AskValidatation() => CurrentTask.TaskStatus = TaskStatus.InValidation;

        public void Attribute(IWorkForce name)
        {
            CurrentTask.TaskStatus = TaskStatus.Ready;
            name.CurrentTask = CurrentTask;
        }

        public void TakeInCharge(ITask task) => this.CurrentTask = task;

        public void Terminate() => CurrentTask.TaskStatus = TaskStatus.InValidation;

        public void Validate() => CurrentTask.TaskStatus = TaskStatus.InValidation;

        public void Abandon() => CurrentTask.TaskStatus = TaskStatus.Abandon;

        public void Validate(ITask task) => task.TaskStatus = TaskStatus.Validated;
    }
}