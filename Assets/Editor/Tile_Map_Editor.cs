using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditorInternal;

[CustomEditor(typeof(Tile_Map))]//与脚本Tile_Map链接
public class Tile_Map_Editor : Editor
{
    protected Tile_Map tile_Map;
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();//重新设置GUI组件面板信息

        tile_Map = (Tile_Map)target;

        if (DrawDefaultInspector())//如果修改GUI组件面板信息
        {
            tile_Map.Createmap();
        }
    }
}
