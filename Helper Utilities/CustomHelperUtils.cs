using UnityEngine;
using System.Collections;
using System;
using System.Reflection;
using System.Linq.Expressions;


public class CustomHelperUtils : MonoBehaviour
{
    //Call this method to clear Unity's development console on runtime. Mostly used from Editor classes for debugging purposes.
    public void ClearDeveloperConsole()
    {
        var logEntries = System.Type.GetType("UnityEditorInternal.LogEntries,UnityEditor.dll");
        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        clearMethod.Invoke(null, null);
    }

    //Copy a component's values and assign them to destination game object using reflection
    public T CopyComponent<T>(T original, GameObject destination) where T : Component
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy as T;
    }
}
