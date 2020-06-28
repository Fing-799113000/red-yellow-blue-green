using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile_Map : MonoBehaviour
{
    //地图编号
    //private int mapdata = 0;
    //存储生成的所有方块
    List<GameObject> tiles = new List<GameObject>();
    //定义一个二维的变量设置方块的排列
    private Vector2Int map_size =new Vector2Int(10,30);
    //定义一个预制体方块
    public GameObject tilePrefab;
    //方块大小
    float tile_size =1;
    //方块的距离
    float tile_dis = 0.2f;
    //父节点统一更新用
    Transform mapHolder;
    //创建地图

    //方块材质
    public Material[] mat;
    private void OnEnable()
    {
        
    }
    public void Createmap()
    {
        //删除该对象以及其子对象，用于实时更新
        tiles.Clear();
        if (mapHolder != null)DestroyImmediate(mapHolder.gameObject);
        //创建一个名为Map Holder的对象
        mapHolder = new GameObject("Map Holder").transform;
        for( int i=0; i < map_size.x; i++)
        {
            for(int k = 0; k < map_size.y; k++)
            {
                //方块之间的距离
                float distance = tile_size + tile_dis;
                //实例一个方块的位置
                Vector3 spawnPos = new Vector3(i * distance, 0, k * distance);
               //实例一个方块
                GameObject tile = Instantiate(tilePrefab, spawnPos,Quaternion.identity);
                //方块设置父节点
                tile.transform.parent = mapHolder;
                //将预制体添加到列表中
                tiles.Add(tile);
            }
        }

    }
}
public enum tileID
{
    //白方块
    write = 0,
    
    //only方块
    red = 1,
    yellow = 2,
    blue = 3,
    green = 4,
    //Flash方块
    red_flash = 5,
    yellow_flash = 6,
    blue_flash = 7,
    green_flash = 8,
    //空气墙
    airwall = 9,
    //复活方块
    help = 10,
}