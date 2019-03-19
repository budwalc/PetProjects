using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;  
using System.IO;
using netCoreMVC.Models;

namespace netCoreMVC.Models

{
    public class Data
    {
        public int id { get; set; }
        public string launchDate  { get; set; }
        public string missionData { get; set; }
        public string missionDesc { get; set; }

    }
}