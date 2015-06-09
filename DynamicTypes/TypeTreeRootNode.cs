using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicTypes
{
    public class TypeTreeRootNode
    {
        public TypeTreeRootNode(object reference, string definition)
        {
            var fieldNames = definition.Split(',').OrderBy(f => f);
            var fields = new Dictionary<string, Type>();

            foreach (var name in fieldNames.Where(f => !f.Contains('\\')))
            {
                fields.Add(name, reference.GetType().GetProperty(name).PropertyType);
            }

            foreach (var field in fields)
            {
                if (String.IsNullOrEmpty(ClassName))
                {
                    ClassName = String.Format("{0}:{1}", field.Key, field.Value.Name);
                }
                else
                {
                    ClassName = String.Format("{0};{1}:{2}", ClassName, field.Key, field.Value.Name);
                }
            }
        }

        public string ClassName { get; private set; }
    }
}
