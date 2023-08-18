using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheJituBlog.Models;
using TheJituBlog.Service.IService;

namespace TheJituBlog.Service
{
    internal class UserService : IUserInterface
    {
        //communicate with the Api's
        private readonly HttpClient _httpClient;
        private readonly string _Url = "https://jsonplaceholder.typicode.com/";

        public UserService()
        {
            _httpClient = new HttpClient();
        }

        //Display all users by username
        public async Task<List<User>> ShowAllUsersAsync() 
        {
            var response = await _httpClient.GetAsync(_Url + "users");
            var users = JsonConvert.DeserializeObject<List<User>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return users;
            }
            throw new Exception("Failed to get Users");

        }

        //Display all posts
       public async Task<List<Post>> ShowAllPostsAsync() 
        {
            var response = await _httpClient.GetAsync(_Url + "posts");
            var posts = JsonConvert.DeserializeObject<List<Post>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return posts;
            }
            throw new Exception("Failed to get Users");
        }

        //Display posts by user 
        public async Task<List<Post>> ShowPostsByUserAsync(string userId) 
        {
            var response = await _httpClient.GetAsync(_Url + userId);
            var userPosts = JsonConvert.DeserializeObject<List<Post>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return userPosts;
            }
            throw new Exception("Failed to get Users");
        }

        //Display comments of a post
        public async Task<List<Comment>> ShowCommentOfPostsAsync(string postId) 
        {
            var response = await _httpClient.GetAsync(_Url + postId);
            var postComment = JsonConvert.DeserializeObject<List<Comment>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return postComment;
            }
            throw new Exception("Failed to get Users");
        }
    }
}
