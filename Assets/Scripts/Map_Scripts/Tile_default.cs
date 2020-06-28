using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile_default : MonoBehaviour
{
    Transform m_transform;
    //定义瓦片的类型
    public tileID tileID;
    //获取脚本
    Tile_Map map;
    
    public void SetTileID()
    {
        m_transform = this.transform;
        Renderer renderer = transform.GetComponent<MeshRenderer>();
        map = GameObject.FindObjectOfType<Tile_Map>();
        switch ((int)tileID)
        {
            case 0:
                {
                    renderer.material = new Material(Shader.Instantiate(map.mat[0]));
                    transform.name = "write_tile";
                }
                break;
                //Only方块
            case 1:
                {
                    renderer.material = new Material(Shader.Instantiate(map.mat[1]));
                    transform.name = "red_only";
                }
                break;
            case 2:
                {
                    renderer.material = new Material(Shader.Instantiate(map.mat[2]));
                    transform.name = "yellow_only";
                }
                break;
            case 3:
                {
                    renderer.material = new Material(Shader.Instantiate(map.mat[3]));
                    transform.name = "blue_only";
                }
                break;
            case 4:
                {
                    renderer.material = new Material(Shader.Instantiate(map.mat[4]));
                    transform.name = "green_only";
                }
                break;
                //Flash方块
            case 5:
                {
                    renderer.material = new Material(Shader.Instantiate(map.mat[5]));
                    transform.name = "red_flash";
                }
                break;
            case 6:
                {
                    renderer.material = new Material(Shader.Instantiate(map.mat[6]));
                    transform.name = "yellow_flash";
                }
                break;
            case 7:
                {
                    renderer.material = new Material(Shader.Instantiate(map.mat[7]));
                    transform.name = "blue_flash";
                }
                break;
            case 8:
                {
                    renderer.material = new Material(Shader.Instantiate(map.mat[8]));
                    transform.name = "green_flash";
                }
                break;
            case 9://透明方块
                {
                    renderer.material = new Material(Shader.Instantiate(map.mat[9]));
                    transform.name = "Airwall";
                }
                break;
                
            default://复活方块
                {
                    renderer.material = new Material(Shader.Instantiate(map.mat[10]));
                    transform.name = "help";
                }
                break;
        }
    }

    private void Awake()
    {
        if (this.gameObject.name.Contains("only"))
        {
            this.gameObject.AddComponent<only>();
        }else if (this.gameObject.name.Contains("flash"))
        {
            this.gameObject.AddComponent<flash>();
        }
        else if (this.gameObject.name.Contains("Airwall"))
        {
            this.gameObject.AddComponent<airwall>();
        }
        else if (this.gameObject.name.Contains("help"))
        {
            this.gameObject.AddComponent<help>();
        }
    }
}



