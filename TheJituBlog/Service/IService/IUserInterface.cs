using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheJituBlog.Models;

namespace TheJituBlog.Service.IService
{
    internal interface IUserInterface
    {
        //Define structure of all the methods in my service

        //Display users by Username 
        Task<List<User>> ShowAllUsersAsync();
        //Display posts
        Task<List<Post>> ShowAllPostsAsync();
        //Select User and show users posts
        Task<List<Post>> ShowPostsByUserAsync(string userId);
        //Select post and show all comments
        Task<List<Comment>> ShowCommentOfPostsAsync(string postId);
    }
}
