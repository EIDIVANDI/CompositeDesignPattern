using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompositeDesignPattern.Domain.Tasks;

namespace CompositeDesignPattern.Domain.WorkForces
{
    public class TechnicalReference : BaseWorkForce, IWorkForce
    {
        private readonly IEnumerable<IWorkForce> developers;

        public TechnicalReference(string name)
            : this(name, null) { }

        public TechnicalReference(string name, IEnumerable<IWorkForce> developers)
            : this(name, developers, null)
        { }

        public TechnicalReference(string name, IEnumerable<IWorkForce> developers, ITask task)
        {
            this.Name = name;
            this.developers = developers;
            CurrentTask = task;
        }

        public override void Abandon(ITask task) 
            => task.TaskStatus = TaskStatus.Abandon;

        public override void Attribute(ITask task, IWorkForce name)
        {
            task.TaskStatus = TaskStatus.Ready;
            name.CurrentTask = task;
        }

        public override bool IsTaskManagable(ITask task)
        {
            return developers.Any(d => d.CurrentTask.Equals(task));
        }

        public override void Terminate(ITask task)
        {
            task.Comments.Add("Task terminated after technical quality validation, no product unhandled issue detected");
            task.TaskStatus = TaskStatus.Terminated;
        }
    }
}
