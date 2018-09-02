using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompositeDesignPattern.Domain.Tasks;

namespace CompositeDesignPattern.Domain.WorkForces
{
    public class ProjectManager : BaseWorkForce, IWorkForce
    {
        private readonly IEnumerable<IWorkForce> members;
        private readonly IEnumerable<Project> projects;

        public ProjectManager(string name)
            : this(name, null)
        { }

        public ProjectManager(string name, IEnumerable<Project> projects)
            : this(name, projects, null)
        { }

        public ProjectManager(string name, IEnumerable<Project> projects, IEnumerable<IWorkForce> members)
            : this(name, projects, members, null)
        { }

        public ProjectManager(string name, IEnumerable<Project> projects, IEnumerable<IWorkForce> members, ITask task)
        {
            Name = name;
            CurrentTask = task;
            this.projects = projects;
            this.members = members;
        }

        public override void Abandon(ITask task)
        {
            if (IsTaskManagable(task))
            {
                task.Comments.Add($"The task shall be abandoned based on {nameof(task.Project)} product priority");
                task.TaskStatus = TaskStatus.Abandon;
            }
        }

        public override void Attribute(ITask task, IWorkForce name)
        {
            if (IsTaskManagable(task))
            {
                task.TaskStatus = TaskStatus.Ready;
                task.Comments.Add($"The task shall be taken in charge asap based on {nameof(task.Project)} product priority");
                name.CurrentTask = task;
            }
        }

        public override bool IsTaskManagable(ITask task)
        {
            return projects.Any(p => p.Equals(task.Project)) && members.Any(m => m.CurrentTask == task || m.IsTaskManagable(task));
        }

        public override void Terminate(ITask task)
        {
            if (IsTaskManagable(task))
            {
                task.Comments.Add("Task recognized as terminated");
                task.Comments.Add("No product unhandled usecase detected");
                task.TaskStatus = TaskStatus.Terminated;
            }

        }
    }
}
