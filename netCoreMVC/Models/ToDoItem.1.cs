using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netCoreMVC.Models;

namespace netCoreMVC.Models


{
    public class TaskRepo
    {
        public TaskRepo()
        {}

        public int id { get; set; }
        public bool isDone { get; set; }
        public string task { get; set; }

    }
}

