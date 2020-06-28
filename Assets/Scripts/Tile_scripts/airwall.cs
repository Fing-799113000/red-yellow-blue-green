using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airwall : MonoBehaviour
{
    private void OnCollisionEnter(Collision coll)
    {
            coll.gameObject.GetComponent<player_move>().m_ani.Play("Crash");
    }
}
