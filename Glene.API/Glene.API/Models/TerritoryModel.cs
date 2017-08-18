using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Glene.API.Models
{
    public class Territory
    {
        public string TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
       // public Region Region { get; set; }
        public int RegionID { get; set; }
    }
}