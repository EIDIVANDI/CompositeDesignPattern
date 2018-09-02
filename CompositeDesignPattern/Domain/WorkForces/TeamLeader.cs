using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CompositeDesignPattern.Domain.Tasks;

namespace CompositeDesignPattern.Domain.WorkForces
{
    public class TeamLeader : BaseWorkForce, IWorkForce
    {
        private readonly IEnumerable<IWorkForce> team;

        public TeamLeader(string name)
            : this(name, null) { }

        public TeamLeader(string name, IEnumerable<IWorkForce> team)
            : this(name, team, null)
        { }

        public TeamLeader(string name, IEnumerable<IWorkForce> team, ITask task)
        {
            this.Name = name;
            this.team = team;
            CurrentTask = task;
        }

        public override void Abandon(ITask task)
        {
            if (IsTaskManagable(task))
            {
                task.Comments.Add("The task shall be abandoned based on priority");
                task.TaskStatus = TaskStatus.Abandon;
            }
        }

        public override void Attribute(ITask task, IWorkForce name)
        {
            if (IsTaskManagable(task))
            {
                task.TaskStatus = TaskStatus.InProgress;
                task.Comments.Add("The task shall be taken in charge asap based on priority");
                name.CurrentTask = task;
            }
        }

        public override bool IsTaskManagable(ITask task)
        {
            return team.Any(t => t.CurrentTask.Equals(task));
        }

        public override void Terminate(ITask task)
        {
            if (IsTaskManagable(task))
            {
                task.Comments.Add("Task terminated , the team work is considered as valid");
                task.Comments.Add("No product unhandled usecase detected");
                task.TaskStatus = TaskStatus.Terminated;
            }
        }
    }
}
