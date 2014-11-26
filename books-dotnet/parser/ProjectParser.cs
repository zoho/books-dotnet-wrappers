using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.parser
{
    /// <summary>
    /// Used to define the parser object of ProjectsApi.
    /// </summary>
    class ProjectParser
    {

        internal static string getMessage(HttpResponseMessage responce)
        {
            string message = "";
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }

        internal static ProjectsList getProjectsList(HttpResponseMessage responce)
        {
            var projectList = new ProjectsList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("projects"))
            {
                var projectsArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["projects"].ToString());
                foreach(var projectObj in projectsArray)
                {
                    var project = new Project();
                    project = JsonConvert.DeserializeObject<Project>(projectObj.ToString());
                    projectList.Add(project);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                projectList.page_context = pageContext;
            }
            return projectList;
        }

        internal static Project getProject(HttpResponseMessage responce)
        {
            var project = new Project();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("project"))
            {
                project = JsonConvert.DeserializeObject<Project>(jsonObj["project"].ToString());
            }
            return project;
        }

        internal static TaskList gatTaskList(HttpResponseMessage responce)
        {
            var taskList = new TaskList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("task"))
            {
                var tasksArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["task"].ToString());
                foreach(var taskObj in tasksArray)
                {
                    var task = new ProjectTask();
                    task = JsonConvert.DeserializeObject<ProjectTask>(taskObj.ToString());
                    taskList.Add(task);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                taskList.page_context = pageContext;
            }
            return taskList;
        }

        internal static ProjectTask gettask(HttpResponseMessage responce)
        {
            var task = new ProjectTask();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("task"))
            {
                task = JsonConvert.DeserializeObject<ProjectTask>(jsonObj["task"].ToString());
            }
            return task;
        }

        internal static UserList getUserList(HttpResponseMessage responce)
        {
            var userList = new UserList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("users"))
            {
                var usersArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["users"].ToString());
                foreach(var userObj in usersArray)
                {
                    var user = new User();
                    user = JsonConvert.DeserializeObject<User>(userObj.ToString());
                    userList.Add(user);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                userList.page_context = pageContext;
            }
            return userList;
        }

        internal static User getUser(HttpResponseMessage responce)
        {
            var user = new User();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("user"))
            {
                user = JsonConvert.DeserializeObject<User>(jsonObj["user"].ToString());
            }
            return user;
        }

        internal static TimeEntryList getTimeEntrieslist(HttpResponseMessage responce)
        {
            var timeEntryList = new TimeEntryList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("time_entries"))
            {
                var timeEntriesArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["time_entries"].ToString());
                foreach(var timeEntryObj in timeEntriesArray)
                {
                    var timeEntry = new TimeEntry();
                    timeEntry = JsonConvert.DeserializeObject<TimeEntry>(timeEntryObj.ToString());
                    timeEntryList.Add(timeEntry);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                timeEntryList.page_context = pageContext;
            }
            return timeEntryList;
        }

        internal static TimeEntry getTimeEntry(HttpResponseMessage responce)
        {
            var timeEntry = new TimeEntry();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("time_entry"))
            {
                timeEntry = JsonConvert.DeserializeObject<TimeEntry>(jsonObj["time_entry"].ToString());
            }
            return timeEntry;
        }
    }
}
