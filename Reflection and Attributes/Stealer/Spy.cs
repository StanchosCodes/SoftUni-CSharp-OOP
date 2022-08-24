namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsToInvestigate)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {className}");

            Type typeOfTheClass = Type.GetType(className);
            FieldInfo[] fields = typeOfTheClass.GetFields(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static |
                BindingFlags.Instance);

            Object instanceOfTheClass = Activator.CreateInstance(typeOfTheClass, new object[] { });

            foreach (FieldInfo field in fields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instanceOfTheClass)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
