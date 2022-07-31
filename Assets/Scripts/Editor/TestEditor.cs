using UnityEngine;
using UnityEditor;

namespace TestEditor
{
    [CustomPropertyDrawer(typeof(short))]
    public class TestEditor : PropertyDrawer
    {
        private GUIStyle _editorStyle;
        Color32[] colors = new Color32[] { Color.red, Color.blue };

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (_editorStyle == null)
            {
                _editorStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                _editorStyle.imagePosition = ImagePosition.ImageOnly;
            }

            label = EditorGUI.BeginProperty(position, label, property);

            property.intValue = Mathf.Clamp(property.intValue, 10, 200);
            if (property.name.ToString().Contains("player"))
            {
                GUI.backgroundColor = colors[1];
            }
            else if (property.name.ToString().Contains("enemy"))
            {
                GUI.backgroundColor = colors[0];
            }

            EditorGUI.IntSlider(position, property, 10, 200);

            int _indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            EditorGUI.indentLevel = _indent;
            EditorGUI.EndProperty();
            
        }
    }

    [CustomPropertyDrawer(typeof(GameObject))]

    public class CustomGameObject : PropertyDrawer
    {
        private GUIStyle _editorStyle;
        Color32[] colors = new Color32[] { Color.red, Color.blue };

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (_editorStyle == null)
            {
                _editorStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                _editorStyle.imagePosition = ImagePosition.ImageOnly;
            }

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            if (property.name.ToString().Contains("player"))
            {
                GUI.backgroundColor = colors[1];
            }
            else if (property.name.ToString().Contains("enemy"))
            {
                GUI.backgroundColor = colors[0];
            }
            else if (property.name.ToString().Contains("plane"))
            {
                GUI.backgroundColor = Color.green;
            }

            EditorGUI.PropertyField(position, property, GUIContent.none);

            int _indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            EditorGUI.indentLevel = _indent;
            EditorGUI.EndProperty();
        }
    }

    [CustomEditor(typeof(TestProperties))]
    public class PlaymodeTint : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var myScript = target as TestProperties;
            if (GUILayout.Button("Change Tint"))
            {
                myScript.ChangeTint();
            }
        }
    }
}
