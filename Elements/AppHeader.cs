using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestHive.ToolKit.Elements
{
    public struct AppHeader
    {
        public string Banner { get;}
        public string Description { get;}
        public string Version { get;}

        public AppHeader(string banner, string description, string version)
        {
            this.Banner = banner;
            this.Description = description;
            this.Version = version;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(Banner);
            Console.WriteLine(Description);
            Console.WriteLine($"version: {this.Version}");
        }
    }
}
