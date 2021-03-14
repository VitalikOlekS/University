using System.Configuration;

namespace UniversityManager.Helpers
{
    public static class Constants
    {
        public static string ImagePath
        {
            get { return ConfigurationManager.AppSettings["ImagePath"]; }
        }
    }
}