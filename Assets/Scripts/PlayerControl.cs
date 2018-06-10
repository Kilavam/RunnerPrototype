using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerControl
{
    private Rigidbody m_rigidBody;

    [SerializeField] private float m_forwardForce;
    [SerializeField] private float m_jumpForce;

    public void Initialize(Rigidbody rigidBody)
    {
        m_rigidBody = rigidBody;
    }

    public void Update(Transform transform)
    {
        transform.position += Vector3.right * m_forwardForce * Time.deltaTime;
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("asdfasdfasdfasdf");
            m_rigidBody.AddForce(Vector3.up * m_jumpForce);
        }
    }
}
