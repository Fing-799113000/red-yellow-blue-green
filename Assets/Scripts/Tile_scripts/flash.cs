using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour
{
    private GameObject _tile;//获取脚本对象
    private float A = 0.5f;//透明度变量
    private Material _material; //材质
    private bool myIn = false;//方块激活状态
    private bool attenuation = false;//方块衰减状态

    //获取材质修改当前颜色
    private void Start()
    {
        _tile = this.gameObject;
        _material = this.gameObject.GetComponent<MeshRenderer>().material;
        _material.color = new Color(1f, 1f, 1f, A); //修改颜色透明度
    }

    //碰撞开始
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.CompareTo(GetTileID(_tile.name)) != 0 && A <= 0.5f)//与颜色不一目标 || 透明度小于等于50%进入
        {
            coll.gameObject.GetComponent<player_move>().m_ani.Play("Brake"); //执行Brake动画
        }
        else if(coll.gameObject.name.CompareTo(GetTileID(_tile.name)) == 0)//颜色对应目标进入
        {
            myIn = true;//激活
            A = 1f; //设置透明度为100%
            _material.color = new Color(1f, 1f, 1f, A); //修改颜色透明度
        }
    }

    //碰撞结束
    private void OnCollisionExit(Collision coll)
    {
        if(coll.gameObject.name.CompareTo(GetTileID(_tile.name)) == 0)//颜色对应目标进入
        {
            myIn = false;//取消激活
            if (attenuation == false)//衰减没有进行时
            {
                StartCoroutine(A_attenuation());//携程衰减
            }
        }
    }

    //携程衰减变回透明
    IEnumerator A_attenuation()
    {
        if (A > 0.5f && myIn == false)//透明度小于50% || 非激活
        {
            A -= 0.04f; //透明度减少10%
            attenuation = true; //衰减进行时
            _material.color = new Color(1f, 1f, 1f, A); //修改颜色透明度
            yield return new WaitForSeconds(0.25f); //等待1秒
            StartCoroutine(A_attenuation()); //返回衰减携程
        }
        else
        {
            attenuation = false; //衰减结束
        }
    }

    //区分与砖块颜色不一的目标
    private string GetTileID(string name)//通过名字返回对应色号
    {
        if (name.Contains("red"))
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
        }
        else
            return "";
    }
}
