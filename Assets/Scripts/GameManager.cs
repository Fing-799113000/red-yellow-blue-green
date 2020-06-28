using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    float A = 1f;//透明度
    GameObject start;//Start对象
    GameObject finish;//Finish对象
    GameObject notswitch;//Not switch对象
    bool notswitching = false; //Not switch进行时判断
    GameObject _obj;//当前对象

    //开始显示   获取组件
    public void Start()
    {
        foreach(Transform t in this.GetComponentInChildren<Transform>())
        {
            if(t.name.Contains("Start"))
            {
                start = t.gameObject;
            }else if (t.name.Contains("Finish"))
            {
                finish = t.gameObject;
            }else if(t.name.Contains("Not switch"))
            {
                notswitch = t.gameObject; 
            }
        }
        _obj = start;
        StartCoroutine(attenuation());
    }
    //变浅效果
    IEnumerator attenuation()
    {
        if (A == 1f && _obj == start ) yield return new WaitForSeconds(1f);
        if (A >= 0f)
        {
            A -= 0.02f;
            _obj.GetComponent<Text>().color =
                new Color(_obj.GetComponent<Text>().color.r,
                _obj.GetComponent<Text>().color.g,
                _obj.GetComponent<Text>().color.b,
                A);
            yield return new WaitForFixedUpdate();
            StartCoroutine(attenuation());
        }
        else
        {
            _obj.SetActive(false);
            if(notswitching == true)
            {
                notswitching = false;
            }
        }
        
    }
    //加深效果
    IEnumerator increasing()
    {
        if (A <= 1f)
        {
            A += 0.02f;
            _obj.GetComponent<Text>().color =
                new Color(_obj.GetComponent<Text>().color.r,
                _obj.GetComponent<Text>().color.g,
                _obj.GetComponent<Text>().color.b,
                A);
            yield return new WaitForFixedUpdate();
            StartCoroutine(increasing());
        }
        else if(_obj == finish)
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(0);
        }else if(_obj == notswitch)
        {
            StartCoroutine(attenuation());
        }
    }

    //完成显示
    public void _Finish()
    {
        _obj = finish;
        _obj.SetActive(true);
        StartCoroutine(increasing());
    }

    //不可切换显示
    public void _NotSwitch()
    {
        
        if (notswitching == false)
        {
            notswitching = true;
            _obj = notswitch;
            _obj.SetActive(true);
            StartCoroutine(increasing());
        }
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
