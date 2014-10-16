using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace UsersApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{auth token}", "{organization id}");
                var usersApi = service.GetUsersApi();
                var parameters = new Dictionary<object, object>();
                //parameters.Add("filter_by", "Status.Invited");
                var userslist = usersApi.GetUsers(parameters);
                var users = userslist;
                var userId = users[1].user_id;
                foreach (var user in users)
                    Console.WriteLine("user id:{0},\nuser name:{1},\nuser role:{2}.\nstatus:{3}\n", user.user_id, user.name, user.user_role, user.status);
                var user1 = usersApi.Get(userId);
                Console.WriteLine("user id:{0},\nuser name:{1},\nuser role:{2}.\nstatus:{3}\n", user1.user_id, user1.name, user1.user_role, user1.status);
                var emails = user1.email_ids;
                foreach (var email in emails)
                    Console.WriteLine("{0},{1}", email.email, email.is_selected);
                var currentUser = usersApi.GetCurrentUser();
                Console.WriteLine("user id:{0},\nuser name:{1},\nuser role:{2}.\nstatus:{3}\n", currentUser.user_id, currentUser.name, currentUser.user_role, currentUser.status);
                var emails1 = currentUser.email_ids;
                foreach (var email in emails1)
                    Console.WriteLine("{0},{1}", email.email, email.is_selected);
                var newUserInfo = new User()
                {
                    name="hari",
                    email="hari12mcs@gmail.com",
                    user_role="timesheetstaff"
                };
                var newUser = usersApi.Create(newUserInfo);
                Console.WriteLine("user id:{0},\nuser name:{1},\nuser role:{2}.\nstatus:{3}\n", newUser.user_id, newUser.name, newUser.user_role, newUser.status);
                var updateInfo = new User()
                {
                    name="user name",
                    email="user email"
                };
                var updatedUser = usersApi.Update(userId, updateInfo);
                Console.WriteLine("user id:{0},\nuser name:{1},\nuser role:{2}.\nstatus:{3}\n", updatedUser.user_id, updatedUser.name, updatedUser.user_role, updatedUser.status);
                var deleteMsg = usersApi.Delete(users[3].user_id);
                Console.WriteLine(deleteMsg);
                var inviteMsg = usersApi.InviteUser(userId);
                Console.WriteLine(inviteMsg);
                var activeMsg = usersApi.MarkAsActive(userId);
                Console.WriteLine(activeMsg);
                var inactiveMsg = usersApi.MarkAsInactive(userId);
                Console.WriteLine(inactiveMsg);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
