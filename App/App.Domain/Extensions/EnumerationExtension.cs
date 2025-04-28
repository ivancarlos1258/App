using System.ComponentModel;
using System.Reflection;

namespace App.Domain.Extensions
{
    public static class EnumerationExtension
    {
        public static string Description(this Enum value)
        {
            // get attributes  
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes(false);

            // Description is in a hidden Attribute class called DisplayAttribute
            // Not to be confused with DisplayNameAttribute
            dynamic displayAttribute = null;

            if (attributes.Any())
            {
                displayAttribute = attributes.ElementAt(0);
            }

            // return description
            return displayAttribute?.Description ?? "Description Not Found";
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
           where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class MessageNotificationAttribute : DescriptionAttribute
    {
        public MessageNotificationAttribute(string description, string value)
        {
            Description = description;
            Value = value;
        }

        public string Description { get; set; }
        public string Value { get; set; }
    }
}
