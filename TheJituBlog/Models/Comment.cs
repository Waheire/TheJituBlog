using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheJituBlog.Models
{
    internal class Comment
    {
        //define structure of a comment
        public string PostId { get; set; } = string.Empty;
        public string id { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string body { get; set; } = string.Empty;

    }
}
