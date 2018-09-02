using System.Collections.Generic;
using System.ComponentModel;

namespace CompositeDesignPattern.Domain.Tasks
{
    public interface ITask
    {
        string Title { get; set; }
        string Description { get; set; }
        List<string> Comments { get; set; }
        byte Priority { get; set; }
        TaskStatus TaskStatus { get; set; }
        Project Project { get; }
    }
}