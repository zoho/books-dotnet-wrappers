using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace ProjectsApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                var projectsApi = service.GetProjectsApi();
                var parameters = new Dictionary<object, object>();
                 parameters.Add("filter_by", "Status.Active");
                 var projectsList = projectsApi.GetProjects(null);
                 var projects = projectsList;
                 var projectId = projects[0].project_id;
                 foreach (var project in projects)
                     Console.WriteLine("{0},{1},{2}", project.project_name, project.billing_type, project.status);
                 var project1 = projectsApi.Get(projectId);
                 Console.WriteLine("{0},{1},{2}", project1.project_name, project1.tasks.Count, project1.users.Count);
                 var newPrjctInfo = new Project()
                 {
                     project_name="project-test-1",
                     customer_id = project1.customer_id,
                     billing_type = "fixed_cost_for_project",
                     rate=1000,
                 };
                 var newProject = projectsApi.Create(newPrjctInfo);
                 Console.WriteLine("{0},{1},{2}", newProject.project_name, newProject.billing_type, newProject.status);
                 var updateInfo = new Project()
                 {
                     project_name="project-test-updated",
                 };
                 var updatedprjct = projectsApi.Update(newProject.project_id, updateInfo);
                 Console.WriteLine("{0},{1},{2}", updatedprjct.project_name, updatedprjct.billing_type, updatedprjct.status);
                 var delprjct = projectsApi.Delete(updatedprjct.project_id);
                 Console.WriteLine(delprjct);
                 var inAct = projectsApi.Inactivate(projectId);
                 Console.WriteLine(inAct);
                 var act = projectsApi.Activate(projectId);
                 Console.WriteLine(act);
                 var clonePrjctInfo = new Project()
                 {
                     project_name="clone-test",
                     description="cloned for test"
                 };
                 var clonePrjct = projectsApi.Clone(projectId, clonePrjctInfo);
                 Console.WriteLine("{0},{1},{2}", clonePrjct.project_name, clonePrjct.billing_type, clonePrjct.status);
                 var parameters1 = new Dictionary<object, object>();
                 var taskslist = projectsApi.GetTasks(projectId, parameters1);
                 var tasks = taskslist;
                 var taskId = tasks[0].task_id;
                 foreach (var task in tasks)
                     Console.WriteLine("{0},{1}", task.task_name, task.billed_hours);
                 var task1 = projectsApi.GetATask(projectId, taskId);
                 Console.WriteLine("{0},{1}", task1.task_name, task1.rate);
                 var newTaskInfo = new ProjectTask()
                 {
                     task_name = "task new for test",
                     description = "new task to project",
                     
                 };
                 var newTask = projectsApi.AddATask(projectId, newTaskInfo);
                 Console.WriteLine("{0},{1}", newTask.task_name, newTask.rate);
                 var updateInfo1 = new ProjectTask()
                 {
                     task_name = "ta3",
                   
                 };
                 var updatedTask = projectsApi.UpdateTask(projectId, newTask.task_id, updateInfo1);
                 Console.WriteLine("{0},{1}", updatedTask.task_name, updatedTask.task_id);
                 var delTask = projectsApi.DeleteTask(projectId, updatedTask.task_id);
                 Console.WriteLine(delTask);
                 var usersList = projectsApi.GetUsers(projectId);
                 var users = usersList;
                 var userId = users[0].user_id;
                 foreach (var user in users)
                     Console.WriteLine("{0},{1},{2}", user.user_name, user.user_role, user.rate);
                 var user1 = projectsApi.GetAUser(projectId, userId);
                 Console.WriteLine("{0},{1},{2}", user1.user_name, user1.user_role, user1.rate);
                 var userstoAssign = new UsersToAssign()
                 {
                     users = new List<User>()
                     {
                         new User()
                         {
                             user_id=userId
                         }
                     }
                 };
                 var users1 = projectsApi.AssignUsers(projectId, userstoAssign);
                 foreach (var user in users1)
                     Console.WriteLine("{0},{1},{2}", user.user_name, user.user_role, user.rate);
                 var userInfo = new User()
                 {
                     user_name="name-twst",
                     email="email@host.com",
                     user_role="staff"
                 };
                 var user2 = projectsApi.InviteUser(projectId, userInfo);
                Console.WriteLine("{0},{1},{2}", user2.user_name, user2.user_role, user2.rate);
                 var updateInfo2 = new User()
                 {
                     user_name="name",
                     user_role = "admin"
                 };
                 var UpdatedUser = projectsApi.UpdateUser(projectId, user2.user_id, updateInfo2);
                 Console.WriteLine("{0},{1},{2}", UpdatedUser.user_name, UpdatedUser.user_role, UpdatedUser.rate);
                 var deleteUser = projectsApi.DeleteUser(projectId, UpdatedUser.user_id);
                 Console.WriteLine(deleteUser);
                 var parameters2 = new Dictionary<object, object>();
                 var timeEntrieslist = projectsApi.GetTimeEnries(parameters2);
                 var timeEntries = timeEntrieslist;
                 var timeEnteryId = timeEntries[0].time_entry_id;
                 foreach (var timeentry in timeEntries)
                      Console.WriteLine("time entry of id {0} for the project {1} of user {2} of log time:{3}\n",timeentry.time_entry_id,timeentry.project_name,timeentry.user_name,timeentry.log_time);
                  var timeentry1 = projectsApi.GetATimeEntry(timeEnteryId);
                  Console.WriteLine("time entry of id {0} for the project {1} of user {2} of log time:{3}\n", timeentry1.time_entry_id, timeentry1.project_name, timeentry1.user_name, timeentry1.log_time);
                  var newTimeentryInfo = new TimeEntry()
                  {
                      project_id =projectId,
                      task_id = taskId,
                      user_id = userId,
                      log_date="2014-11-13",
                      log_time="06:46"
                  };
                  var newTimeentry = projectsApi.LogTimeEntry(newTimeentryInfo);
                  Console.WriteLine("time entry of id {0} for the project {1} of user {2} of log time:{3}\n", newTimeentry.time_entry_id, newTimeentry.project_name, newTimeentry.user_name, newTimeentry.log_time);
                  var updateInfo3 = new TimeEntry()
                  {
                      project_id = projectId,
                      user_id = userId,
                      log_time="02:00",
                  };
                  var updatedTimeEntry = projectsApi.UpdateTimeEntry(newTimeentry.time_entry_id, updateInfo3);
                  Console.WriteLine("time entry of id {0} for the project {1} of user {2} of log time:{3}\n", updatedTimeEntry.time_entry_id, updatedTimeEntry.project_name, updatedTimeEntry.user_name, updatedTimeEntry.log_time);
                  var deleteMsg = projectsApi.DeleteTimeEntry(updatedTimeEntry.time_entry_id);
                  Console.WriteLine(deleteMsg);
                  var parameters3 = new Dictionary<object, object>();
                  parameters3.Add("time_entry_ids", timeEnteryId+","+updatedTimeEntry.time_entry_id);
                  var deleteEntries = projectsApi.DeleteTimeEntries(parameters3);
                  Console.WriteLine(deleteEntries);
                  var timer = projectsApi.GetTimer();
                  Console.WriteLine("time entry of id {0} for the project {1} of user {2} of log time:{3}\n", timer.time_entry_id, timer.project_name, timer.user_name, timer.log_time);
                 var timerStart = projectsApi.StartTimer(timeEnteryId);
                 Console.WriteLine("time entry of id {0} for the project {1} of user {2} of log time:{3}\n", timerStart.time_entry_id, timerStart.project_name, timerStart.user_name, timerStart.log_time);
                 var stopTimer = projectsApi.StopTimer();
                 Console.WriteLine("time entry of id {0} for the project {1} of user {2} of log time:{3}\n", stopTimer.time_entry_id, stopTimer.project_name, stopTimer.user_name, stopTimer.log_time);
                var commentsList = projectsApi.GetComments(projectId);
                var comments = commentsList;
                foreach (var comment in comments)
                    Console.WriteLine("{0},{1},{2}", comment.comment_id, comment.description, comment.commented_by);
                var newCommentInfo = new Comment()
                {
                    description = "manually added comment",
                };
                var newComment = projectsApi.AddComment(projectId, newCommentInfo);
                Console.WriteLine("{0},{1},{2}", newComment.comment_id, newComment.description, newComment.commented_by);
                var deleteComment = projectsApi.DeleteComment(projectId, newComment.comment_id);
                Console.WriteLine(deleteComment);
                var parameters4 = new Dictionary<object, object>();
                var invoicesList = projectsApi.GetInvoices(projectId, null);
                foreach (var invoice in invoicesList)
                    Console.WriteLine("{0},{1},{2}", invoice.invoice_number, invoice.total, invoice.status);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
