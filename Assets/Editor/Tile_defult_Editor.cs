using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEditorInternal;

[CustomEditor(typeof(Tile_default))]
public class Tile_defult_Editor : Editor
{
    //受编辑器影响的脚本
    protected Tile_default tile_Default;
    public override void OnInspectorGUI()
    {
        tile_Default = (Tile_default)target;

        if (DrawDefaultInspector())
        {
            tile_Default.SetTileID();
        }
    }
}
