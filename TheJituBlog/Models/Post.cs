using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheJituBlog.Models
{
    internal class Post
    {
        //define structure of a post
        public string userId { get; set; } = string.Empty;
        public string id { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string body { get; set; } = string.Empty;
    }
}
