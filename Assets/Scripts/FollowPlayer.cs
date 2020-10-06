using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public PlayerController m_player;
    public float m_offset;

//checking player position and follow it with camera
    void LateUpdate()
    {
        if (m_player && m_player.m_dies == false)
        {
            transform.position = new Vector3 (m_player.transform.position.x, m_player.transform.position.y, transform.position.z );
        }
    }
}
