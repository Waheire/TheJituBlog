using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TheJituBlog.Helpers;
using TheJituBlog.Models;
using TheJituBlog.Service;
using static System.Reflection.Metadata.BlobBuilder;

namespace TheJituBlog.Controller
{
    internal class UserController
    {
        //communicate with the service
        UserService userService = new UserService();

        public async static Task Init()
        {
            Console.WriteLine("Hello Welcome to theJitu Blog");
            Console.WriteLine("1. View Users");
            Console.WriteLine("2. View posts");
            Console.WriteLine("3. View POst Comments");
            Console.WriteLine("9. Exit");

            var input = Console.ReadLine();
            var validationResults = Validation.Validate(new List<string> { input });
            if (!validationResults)
            {
                await UserController.Init();
            }
            else
            {
                await new UserController().MenuRedirect(input);
            }
        }

        //main menu
        public async Task MenuRedirect(string id)
        {
            switch (id)
            {
                case "1":
                    await ShowUsers();
                    break;
                    case "2":
                     await ShowPosts() ; 
                    break;
                    case "3":
                    await ShowComments();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        public async Task ShowUsers()
        {
            try
            {
                var users = await userService.ShowAllUsersAsync();
                foreach (var user in users)
                {
                    await Console.Out.WriteLineAsync($"{user.id}. {user.username}");
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //display menu to select a user and view selected user posts
        public async Task ShowUsersPostsMenu() 
        {
            Console.WriteLine("Select a user to view posts");
            Console.WriteLine("1. Enter user Id");
            var selection = Console.ReadLine();


            switch (selection) 
            {
                case "1":
                    await ShowPostsByUser(selection);
                    break;
                    default:
                    await UserController.Init();
                    break;
    
            }
        }

        //Display user selected posts
        public async Task ShowPostsByUser(string userId) 
        {
            try
            {
                var posts = await userService.ShowPostsByUserAsync(userId);
                foreach (var post in posts)
                {
                    await Console.Out.WriteLineAsync(post.id);
                    await Console.Out.WriteLineAsync(post.title);
                    await Console.Out.WriteLineAsync(post.body);
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



       

        //Select a post 
        public async Task ShowPostsMenu()
        {
            Console.WriteLine("Select a post to view posts");
            Console.WriteLine("1. Enter post Id");
            var selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    await ShowCommentsOfPosts(selection);
                    break;

            }
        }

        //show comments of selected post
        public async Task ShowCommentsOfPosts(string postId)
        {
            try
            {
                var comments = await userService.ShowCommentOfPostsAsync(postId);
                foreach (var comment in comments)
                {
                    await Console.Out.WriteLineAsync(comment.id);
                    await Console.Out.WriteLineAsync(comment.name);
                    await Console.Out.WriteLineAsync(comment.email);
                    await Console.Out.WriteLineAsync(comment.body);
                }
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
