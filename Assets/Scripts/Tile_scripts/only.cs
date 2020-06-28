using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class only : MonoBehaviour
{
    private GameObject _tile;//当前方块
    private void Start()
    {
        _tile = this.gameObject;
    }
    private void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.name.CompareTo(GetTileID(_tile.name)) != 0)
        {
            coll.gameObject.GetComponent<player_move>().m_ani.Play("Crash");
        }
    }

    //区分与砖块颜色不一的目标
    private string GetTileID (string name)
    {
        if(name.Contains("red"))
        {
            return "RedPlayer";
        }
        else if (name.Contains("yellow"))
        {
            return "YellowPlayer";
        }
        else if (name.Contains("blue"))
        {
            return "BluePlayer";
        }
        else if (name.Contains("green"))
        {
            return "GreenPlayer";
        }else
             return "";
    }
}
