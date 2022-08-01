using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace TestEditor
{
    //Change the way any short variables are displayed
    [CustomPropertyDrawer(typeof(short))]
    public class TestEditor : PropertyDrawer
    {
        //Create an array of colours to use to style the properties
        Color32[] colors = new Color32[] { Color.red, Color.blue };
        //create a style variable to modify the look of the editor properties
        private GUIStyle _editorStyle;
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //If GUI style doesn't contain anything make it equal the Unity default style from Pane Options
            if (_editorStyle == null)
            {
                _editorStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                _editorStyle.imagePosition = ImagePosition.ImageOnly;
            }
            //Begin and create a label for the property
            label = EditorGUI.BeginProperty(position, label, property);
            //Make sure the value of the property sits in the desired range
            property.intValue = Mathf.Clamp(property.intValue, 10, 100);
            //If name of property contains player colour it blue
            if (property.name.ToString().Contains("player"))
            {
                GUI.backgroundColor = colors[1];
            }
            //If name of property contains enemy colour it red
            else if (property.name.ToString().Contains("enemy"))
            {
                GUI.backgroundColor = colors[0];
            }
            //Create a slider to adjust the value of the property
            EditorGUI.IntSlider(position, property, 10, 100);
            //Indent the property
            int _indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            EditorGUI.indentLevel = _indent;
            //End the property field
            EditorGUI.EndProperty();            
        }
    }

    //Change the way GameObject variables are displayed
    [CustomPropertyDrawer(typeof(GameObject))]
    public class CustomGameObject : PropertyDrawer
    {
        //Create an array of colours to use to style the properties
        Color32[] colors = new Color32[] { Color.red, Color.blue, Color.green };
        //create a style variable to modify the look of the editor properties
        private GUIStyle _editorStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //If editor style is empty make it the default unity editor style
            if (_editorStyle == null)
            {
                _editorStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                _editorStyle.imagePosition = ImagePosition.ImageOnly;
            }
            //Begin and label the property
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);
            //If property name contains player colour it blue
            if (property.name.ToString().Contains("player"))
            {
                GUI.backgroundColor = colors[1];
            }
            //If property name contains enemy colour it red
            else if (property.name.ToString().Contains("enemy"))
            {
                GUI.backgroundColor = colors[0];
            }
            //If property name contains plane colour it green
            else if (property.name.ToString().Contains("plane"))
            {
                GUI.backgroundColor = colors[2];
            }
            //Create the box to add the gameobject in the editor
            EditorGUI.PropertyField(position, property, GUIContent.none);
            //Indent the property field
            int _indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            EditorGUI.indentLevel = _indent;
            //End the property
            EditorGUI.EndProperty();
        }
    }
    //Custom Editor to add the button for playmode tint
    [CustomEditor(typeof(ModifiedTestCode))]
    public class PlaymodeTint : Editor
    {
        public override void OnInspectorGUI()
        {
            //Draw the default editor properties for the script first
            DrawDefaultInspector();
            //Create a reference to the spawning test script so we can access a function
            var myScript = target as ModifiedTestCode;
            //If user clicks the button activate the ChangeTint method so playmode tint changes
            if (GUILayout.Button("Change Tint"))
            {
                myScript.ChangeTint();
            } 
            //This Checks the isCreated boolean in the ModifiedTestCode...
            if(myScript.isCreated == false)
            {
                //...and then if it's false, makes the gui button the "create all" button and function
                if (GUILayout.Button("Create All"))
                {
                    myScript.CreateAll();
                }
            }
            else if(myScript.isCreated == true)
            {//...or if it's false, it makes the gui button the "destroy all" button and function, simple innit?
                if(GUILayout.Button("Destroy All"))
                {
                    myScript.DestroyAll();
                }
            }
            //this simply adds a button that will reset values to a "default"
            if(GUILayout.Button("Reset Values"))
            {
                myScript.ResetValues();
            }

        }
    }
    
    
}
