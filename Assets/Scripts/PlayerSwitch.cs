using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSwitch : MonoBehaviour
{
    private Transform _transform; //切换灯对象
    private Light _light;//灯组件
    GameManager GameManager;

    //人物的跟随相机的代码
    player_move moveScript_red;
    player_move moveScript_yellow;
    player_move moveScript_blue;
    player_move moveScript_green;

    //人物的动画组件
    Animator red_ani;
    Animator yellow_ani;
    Animator blue_ani;
    Animator green_ani;

    //跟随相机
    GameObject redCam;
    GameObject yellowCam;
    GameObject blueCam;
    GameObject greenCam;

    public GameObject[] MainPlayer;
    public GameObject nowMainPlayer;// 主要角色

    [SerializeField]
    private int iCharcaterCount = 0;



    void Start()
    {
        GameManager = GameObject.FindObjectOfType<GameManager>();
        _transform = this.transform;
        _light = _transform.GetComponent<Light>();

        redCam = GameObject.Find("CM FreeLook1");
        yellowCam = GameObject.Find("CM FreeLook2");
        blueCam = GameObject.Find("CM FreeLook3");
        greenCam = GameObject.Find("CM FreeLook4");

        moveScript_red = MainPlayer[0].GetComponent<player_move>();
        red_ani = MainPlayer[0].GetComponent<Animator>();
        moveScript_yellow = MainPlayer[1].GetComponent<player_move>();
        yellow_ani = MainPlayer[1].GetComponent<Animator>();
        moveScript_blue = MainPlayer[2].GetComponent<player_move>();
        blue_ani = MainPlayer[2].GetComponent<Animator>();
        moveScript_green = MainPlayer[3].GetComponent<player_move>();
        green_ani = MainPlayer[3].GetComponent<Animator>();
    }



    void Update()
    {
        ChangeCharacter();
    }



    void OfScripts()
    {
        
    }



    void ChangeCharacter()//角色切换
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            AnimatorStateInfo stateInfo = nowMainPlayer.GetComponent<player_move>().m_ani.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.Idle") || stateInfo.fullPathHash == Animator.StringToHash("Base Layer.Walking"))
            {
                iCharcaterCount++;
                if (iCharcaterCount >= MainPlayer.Length)
                {
                    iCharcaterCount = 0;
                }
                nowMainPlayer = null;
            }
            else
            {
                GameManager._NotSwitch();
                Debug.Log("No No No");
            }
        }

        switch (iCharcaterCount)
        {
            case 0://当前控制红人 
                {
                    if (nowMainPlayer == null) { nowMainPlayer = MainPlayer[0]; Debug.Log(nowMainPlayer.name); }
                    //OfScripts();
                    //相机控制
                    yellowCam.SetActive(false);
                    blueCam.SetActive(false);
                    greenCam.SetActive(false);
                    redCam.SetActive(true);
                    //移动和动画控制
                    yellow_ani.Play("Idle");
                    blue_ani.Play("Idle");
                    green_ani.Play("Idle");  
                    moveScript_yellow.enabled = false;
                    moveScript_blue.enabled = false;
                    moveScript_green.enabled = false;
                    moveScript_red.enabled = true;
                    nowMainPlayerLight();
                }
                break;
            case 1://当前控制黄人
                {
                    if (nowMainPlayer == null) { nowMainPlayer = MainPlayer[1]; Debug.Log(nowMainPlayer.name); }
                    //OfScripts(); 
                    blueCam.SetActive(false);
                    greenCam.SetActive(false);
                    redCam.SetActive(false);
                    yellowCam.SetActive(true);
                    red_ani.Play("Idle");
                    blue_ani.Play("Idle");
                    green_ani.Play("Idle");
                    moveScript_red.enabled = false;
                    moveScript_blue.enabled = false;
                    moveScript_green.enabled = false;
                    moveScript_yellow.enabled = true;
                    nowMainPlayerLight();
                }
                break;
            case 2://当前控制蓝人
                {
                    if (nowMainPlayer == null) { nowMainPlayer = MainPlayer[2]; Debug.Log(nowMainPlayer.name); }
                    //OfScripts();
                    greenCam.SetActive(false);
                    redCam.SetActive(false);
                    yellowCam.SetActive(false);
                    blueCam.SetActive(true);
                    red_ani.Play("Idle");
                    yellow_ani.Play("Idle");
                    green_ani.Play("Idle");
                    moveScript_red.enabled = false;                   
                    moveScript_yellow.enabled = false;                                   
                    moveScript_green.enabled = false;
                    moveScript_blue.enabled = true;
                    nowMainPlayerLight();
                }
                break;
            case 3://当前控制绿人
                {
                    if (nowMainPlayer == null) { nowMainPlayer = MainPlayer[3]; Debug.Log(nowMainPlayer.name); }
                    //OfScripts();
                    redCam.SetActive(false);
                    yellowCam.SetActive(false);
                    blueCam.SetActive(false);
                    greenCam.SetActive(true);
                    red_ani.Play("Idle");
                    yellow_ani.Play("Idle");
                    blue_ani.Play("Idle");
                    moveScript_red.enabled = false;                    
                    moveScript_yellow.enabled = false;                   
                    moveScript_blue.enabled = false;                   
                    moveScript_green.enabled = true;
                    nowMainPlayerLight();
                }
                break;

            default:
                break;
        }
    }



    void IsRedCam()
    {
        redCam.SetActive(false);
        redCam.SetActive(true);
    }


    void IsYellowCam()
    {
        yellowCam.SetActive(false);
        yellowCam.SetActive(true);
    }

    public void nowMainPlayerLight()
    {
        if(nowMainPlayer.name.Contains("Red"))
        {
            _light.color = new Color(1, 0, 0);
        }
        else if (nowMainPlayer.name.Contains("Yellow"))
        {
            _light.color = new Color(1, 1, 0);
        }
        else if (nowMainPlayer.name.Contains("Blue"))
        {
            _light.color = new Color(0, 0, 1);
        }
        else if (nowMainPlayer.name.Contains("Green"))
        {
            _light.color = new Color(0, 1, 0);
        }
        //_transform.parent = nowMainPlayer.transform;
        _transform.position = nowMainPlayer.transform.position + new Vector3(0, 0.75f, 0);
    }
}