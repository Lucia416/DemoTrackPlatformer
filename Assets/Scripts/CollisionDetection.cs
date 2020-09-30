using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private LayerMask m_platformMask;

    public bool m_isOnTheGround;

    private void OnTriggerStay2D(Collider2D collider)
    {
        m_isOnTheGround = collider != null && (((1 << collider.gameObject.layer) & m_platformMask) != 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_isOnTheGround = false;
    }
}
