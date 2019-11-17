using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Level))]
public class LevelEditor : Editor
{
    //public override void OnInspectorGUI()
    //{

    //    base.OnInspectorGUI();

    //    if (GUILayout.Button("Generate cubes"))
    //    {
    //        Level level = (Level)target;

    //        if (level.number.x != 0)
    //        {
    //            level.CreateCopiesXYZ(ref level.position, (int)level.number.x, (int)level.number.y, (int)level.number.z);
    //        }
    //        else if (level.number.y != 0)
    //        {
    //            level.CreateCopiesYZ(ref level.position, (int)level.number.x, (int)level.number.y, (int)level.number.z);
    //        }
    //        else if (level.number.z != 0)
    //        {
    //            level.CreateCopiesZ(ref level.position, (int)level.number.x, (int)level.number.y, (int)level.number.z);
    //        }
    //    }
    //}
}
