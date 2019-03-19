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
    public class SpaceFlight
    {
        public ICollection GetData()
        {
            #region HTML Config
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://spaceflightnow.com/launch-schedule/");

            var dateName = document.DocumentNode.SelectNodes("//div[@class='entry-content clearfix']//div[@class='datename']");
            var missionData = document.DocumentNode.SelectNodes("//div[@class='entry-content clearfix']//div[@class='missiondata']");
            var missionDescription = document.DocumentNode.SelectNodes("//div[@class='entry-content clearfix']//div[@class='missdescrip']");

            #endregion

            /// This Will create the DataRepository
            Data[] DataRepo;
            DataRepo = new Data[dateName.Count];


            for (int i = 0; i < dateName.Count; i++)
            {
                DataRepo[i] = new Data
                {
                    id = i + 1,
                    launchDate = dateName[i].InnerText,
                    missionData = missionData[i].InnerText,
                    missionDesc = missionDescription[i].InnerText
                };
            }

            return DataRepo;

        }
    }
}