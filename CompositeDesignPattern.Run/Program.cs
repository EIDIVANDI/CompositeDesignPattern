using CompositeDesignPattern.Domain.Tasks;
using CompositeDesignPattern.Domain.WorkForces;
using System;
using System.Collections.Generic;

namespace CompositeDesignPattern.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Composite Pattern!");

            Project project = new Project("CompositeProject");

            ITask task = new Task(project);
            ITask bug = new Bug(project);
            ITask ValidateIntegeration = new Task(project);

            Developer teamMemberA = new Developer("Omid", task);
            Developer teamMemberB = new Developer("Alex", bug);


            TeamLeader reff =
                new TeamLeader(
                    "Antoin",
                    new List<IWorkForce> { teamMemberA, teamMemberB },
                    ValidateIntegeration);

            Console.WriteLine($"\ndeveloper validate it's current task {nameof(task)}");
            teamMemberA.Validate();
            Console.WriteLine(teamMemberA.CurrentTask.TaskStatus.ToString());

            Console.WriteLine($"\ndeveloper validate it's current task {nameof(bug)}");
            teamMemberB.Validate();
            Console.WriteLine(teamMemberB.CurrentTask.TaskStatus.ToString());

            Console.WriteLine($"\ndeveloper try to abandon the a task {nameof(bug)}");
            try
            {
                teamMemberA.Abandon(teamMemberB.CurrentTask);
                Console.WriteLine(teamMemberB.CurrentTask.TaskStatus.ToString());
            }
            catch
            {
                Console.WriteLine($"developer has no rights to abandon others tasks. \nthe task keep state {teamMemberB.CurrentTask.TaskStatus.ToString()}");
            }


            Console.WriteLine($"\ndeveloper validate other developer current task {nameof(bug)}");
            teamMemberA.Validate(teamMemberB.CurrentTask);
            Console.WriteLine(teamMemberB.CurrentTask.TaskStatus.ToString());

            Console.WriteLine($"The technical reference abandon the developer task {nameof(bug)}");
            reff.Abandon(bug);
            Console.WriteLine(teamMemberB.CurrentTask.TaskStatus.ToString());

            Developer teamMemberC = new Developer("Alex", bug);
            reff.Terminate(bug);
            Console.WriteLine(teamMemberB.CurrentTask.TaskStatus.ToString());

            Console.ReadKey();
        }
    }
}
