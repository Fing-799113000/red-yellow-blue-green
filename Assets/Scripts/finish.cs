using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    GameManager GameManager;
    GameObject redplayer;
    GameObject yellowplayer;
    GameObject blueplayer;
    GameObject greenplayer;

    private bool red_finish = false;
    private bool yellow_finish = false;
    private bool blue_finish = false;
    private bool green_finish = false;
    private void Start()
    {
        GameManager = GameObject.FindObjectOfType<GameManager>();
        redplayer = GameObject.Find("RedPlayer");
        yellowplayer = GameObject.Find("YellowPlayer");
        blueplayer = GameObject.Find("BluePlayer");
        greenplayer = GameObject.Find("GreenPlayer");
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.gameObject == redplayer)
        {
            red_finish = true;
        }
        else if (coll.collider.gameObject == yellowplayer)
        {
            yellow_finish = true;
        }
        else if (coll.collider.gameObject == blueplayer)
        {
            blue_finish = true;
        }
        else if (coll.collider.gameObject == greenplayer)
        {
            green_finish = true;
        }
        if(red_finish && yellow_finish && blue_finish && green_finish)
        {
            GameManager._Finish();
        }
    }

}
