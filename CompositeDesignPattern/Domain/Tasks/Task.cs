using System;
using System.Collections.Generic;
using System.Text;

namespace CompositeDesignPattern.Domain.Tasks
{
    public class Task : ITask
    {
        private readonly Project project;

        public Task(Project project)
        {
            this.project = project;
            Comments = new List<string>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Comments { get; set; }
        public byte Priority { get; set; } = 0;
        public TaskStatus TaskStatus { get; set; } 
        public Project Project { get; private set; }
    }
}
