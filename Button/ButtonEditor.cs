using UnityEngine;
using UnityEditor;
using System.Reflection;

#if UNITY_EDITOR
namespace Dunward.OpenInspector
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class ButtonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var targetObject = target;
            var targetObjectType = targetObject.GetType();

            var methods = targetObjectType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var method in methods)
            {
                var buttonAttribute = method.GetCustomAttribute<ButtonAttribute>();
                if (buttonAttribute != null)
                {
                    var buttonText = string.IsNullOrEmpty(buttonAttribute.Name) ? method.Name : buttonAttribute.Name;
                    if (GUILayout.Button(buttonText))
                    {
                        method.Invoke(targetObject, null);
                    }
                }
            }
        }
    }
}
#endif