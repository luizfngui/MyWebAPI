using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Models.DTOs
{
    public class UserView
    {
        /// <example>
        /// 00000000-0000-0000-0000-000000000000
        /// </example>
        public Guid Id { get; set; }
        /// <example>
        /// ryan@reynolds.com
        /// </example>
        public string Email { get; set; }
        /// <example>
        /// Ryan Reynolds
        /// </example>
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
