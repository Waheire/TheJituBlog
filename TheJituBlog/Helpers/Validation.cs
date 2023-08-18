using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheJituBlog.Helpers
{
    internal class Validation
    {
        public static bool Validate(List<string> inputs)
        {
            var valid = false;
            foreach (var input in inputs) 
            {
                if (!string.IsNullOrEmpty(input)) 
                {
                    valid = true;
                    break;
                }
                else  
                {
                    valid = false;
                }
            }
            return valid;
        }
    }
}
