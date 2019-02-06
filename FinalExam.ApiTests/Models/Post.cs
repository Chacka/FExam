using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.ApiTests.Models
{
    public struct Post
    {
        public string UserID { get; set; }

        public string ID { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}
