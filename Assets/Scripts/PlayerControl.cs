using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerControl
{
    
    private Rigidbody m_rigidBody;
    private Collider m_collider;

    private int m_remainingAdditionnalJumps;

    [SerializeField] private int m_numberOfAdditionnalJumps;
    [SerializeField] private float m_forwardForce;
    [SerializeField] private float m_jumpForce;

    public void Initialize(Rigidbody rigidBody)
    {
        m_rigidBody = rigidBody;
        m_collider = m_rigidBody.GetComponent<Collider>();
        m_remainingAdditionnalJumps = m_numberOfAdditionnalJumps;
    }

    public void Update(Transform transform)
    {
        
        transform.position += Vector3.right * m_forwardForce * Time.deltaTime;
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if (isGrounded())
            {
                jump();
            }
            else if(m_remainingAdditionnalJumps > 0)
            {
                m_remainingAdditionnalJumps -= 1;
                jump();
            }
            
        }
    }

    public void jump()
    {
        m_rigidBody.AddForce(Vector3.up * m_jumpForce);
    }
    public bool isGrounded()
    {
        Ray ray = new Ray(m_collider.bounds.center, Vector3.down);
        if (Physics.Raycast(ray, m_collider.bounds.extents.y + 0.1f))
        {
            m_remainingAdditionnalJumps = m_numberOfAdditionnalJumps;
            return true;
        }
        return false;
    }
}
