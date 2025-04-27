using UnityEngine;
using UnityEditor;
using System.Reflection;

#if UNITY_EDITOR
namespace Dunward.OpenInspector
{
    [CustomPropertyDrawer(typeof(ButtonAttribute))]
    public class ButtonDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var targetObject = property.serializedObject.targetObject;
            var targetObjectClassType = targetObject.GetType();
            var methodName = property.name;
            var methodInfo = targetObjectClassType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            if (methodInfo != null)
            {
                var buttonAttribute = (ButtonAttribute)attribute;
                var buttonText = string.IsNullOrEmpty(buttonAttribute.Name) ? methodName : buttonAttribute.Name;
                
                if (GUI.Button(position, buttonText))
                {
                    methodInfo.Invoke(targetObject, null);
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }
    }
}
#endif