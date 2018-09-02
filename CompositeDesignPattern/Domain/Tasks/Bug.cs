using System;
using System.Collections.Generic;
using System.Text;

namespace CompositeDesignPattern.Domain.Tasks
{
    public class Bug : Task, ITask
    {
        public Bug(Project project) 
            : base(project)
        { }
    }
}
