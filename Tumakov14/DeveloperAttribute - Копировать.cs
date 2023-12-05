using System;

namespace Tumakov14
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DeveloperAttribute : Attribute
    {
        public string DeveloperName { get; }
        public string OrganizationName { get; }

        public DeveloperAttribute(string developerName, string organizationName)
        {
            DeveloperName = developerName;
            OrganizationName = organizationName;
        }
    }
}
