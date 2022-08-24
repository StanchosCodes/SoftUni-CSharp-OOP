namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        public static void Main()
        {
            Type classType = Type.GetType("P01_HarvestingFields.HarvestingFields");
            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

            Queue<string> commands = new Queue<string>();

            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                commands.Enqueue(command);
            }

            foreach (string cmd in commands)
            {
                if (cmd == "private")
                {
                    foreach (FieldInfo field in fields.Where(f => f.Attributes == FieldAttributes.Private))
                    {
                        Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                    }
                }
                else if (cmd == "public")
                {
                    foreach (FieldInfo field in fields.Where(f => f.Attributes == FieldAttributes.Public))
                    {
                        Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                    }
                }
                else if (cmd == "protected")
                {
                    foreach (FieldInfo field in fields.Where(f => f.Attributes == FieldAttributes.Family))
                    {
                        Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                    }
                }
                else if (cmd == "all")
                {
                    foreach (FieldInfo field in fields)
                    {
                        if (field.Attributes == FieldAttributes.Family)
                        {
                            Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                        }
                        else
                        {
                            Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                        }
                    }
                }
            }
        }
    }
}