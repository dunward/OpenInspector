using UnityEngine;

namespace Dunward.OpenInspector
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class ButtonAttribute : PropertyAttribute
    {
        public string Name { get; private set; }

        public ButtonAttribute()
        {
            Name = string.Empty;
        }

        public ButtonAttribute(string name)
        {
            Name = name;
        }
    }
}
