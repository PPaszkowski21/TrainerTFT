using System;
using System.Collections.Generic;
using System.Text;

namespace AT.Services.Helpers
{
    public class TraitManager
    {
        public string TraitKey { get; set; }
        public string Name { get; set; }
        public int Active { get; set; }
        public TraitManager(string key, string name)
        {
            this.TraitKey = key;
            this.Name = name;
            this.Active = 1;
        }
    }
}
