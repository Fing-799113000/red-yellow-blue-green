using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public float moveSpeed = 2f;//移动速度

    [HideInInspector]
    public Animator m_ani;

    private bool comeback = false;//撤退状态

    public CharacterController controller;//角色控制器
    public Transform cam;
    public float turnSmoothTime = 0.1f;//转弯平滑时间
    float turnSmoothVelocity;


    void Start()
    {
        m_ani = this.GetComponent<Animator>();
    }



    void Update()
    {
        AnimatorStateInfo stateInfo = m_ani.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.Idle") || stateInfo.fullPathHash == Animator.StringToHash("Base Layer.Walking"))
        {
            Move();
        }

    }



    void Move()
    {
        float h = Input.GetAxis("Horizontal");//左右
        float v = Input.GetAxis("Vertical");//上下
        Vector3 direction = new Vector3(h, 0f, v).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);//targetAngle改为angle
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);//direction改为moveDir.normalized
            m_ani.SetBool("walk", true);
            m_ani.SetBool("idle", false);
        }
        else
        {
            m_ani.SetBool("walk", false);
            m_ani.SetBool("idle", true);
        }
    }

    IEnumerator comebacking()//携程后退
    {
        transform.Translate(Vector3.forward * -1 * 0.005f);
        yield return new WaitForFixedUpdate();
        if(comeback == true)
        StartCoroutine(comebacking());
    }

    void comeback_open()//后退开始
    {
        comeback = true;
        StartCoroutine(comebacking());
    }
    void comeback_over()//后退结束
    {
        comeback = false;
    }
}
