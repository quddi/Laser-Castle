using UnityEditor;

namespace LaserSystem2D
{
    public interface IEditorFactory<in T>
    {
        IDrawable Create(SerializedObject serializedObject, T target);
    }
}