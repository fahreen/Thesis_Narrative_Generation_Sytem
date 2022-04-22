using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class SystemTool : EditorWindow
{

    [MenuItem("NarrativeGenerationTool/Edit")]
    public static void OpenWindow()
    {
        GetWindow<SystemTool>();
    }
}
