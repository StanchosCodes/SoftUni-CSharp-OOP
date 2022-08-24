namespace ValidationAttributes.Utilities
{
    using Attributes;
    using System;
    using System.Linq;
    using System.Reflection;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objectType = obj.GetType();
            PropertyInfo[] properties = objectType
                .GetProperties()
                .Where(pi => pi.CustomAttributes.Any(att => att.AttributeType.BaseType == typeof(MyValidationAttribute)))
                .ToArray();

            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj);

                foreach (CustomAttributeData customAttribute in property.CustomAttributes)
                {
                    Type customAttributeType = customAttribute.AttributeType;

                    object atributeInstance = property.GetCustomAttribute(customAttributeType);

                    MethodInfo validationMethod = customAttributeType
                        .GetMethods()
                        .First(m => m.Name == "IsValid");

                    bool result = (bool)validationMethod.Invoke(atributeInstance, new object[] { propValue });

                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
