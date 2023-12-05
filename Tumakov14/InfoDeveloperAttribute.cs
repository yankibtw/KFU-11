using System;

namespace Tumakov14
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DeveloperInfoAttribute : Attribute
    {
        public string DeveloperName { get; }
        public DateTime DevelopmentDate { get; }

        public DeveloperInfoAttribute(string developerName, string developmentDate)
        {
            DeveloperName = developerName;
            if (DateTime.TryParse(developmentDate, out DateTime result))
                DevelopmentDate = result;
            else
                throw new ArgumentException("Неверный формат даты!", nameof(developmentDate));
        }
    }
}
