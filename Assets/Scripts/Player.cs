using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerControl m_playerControl;
    [SerializeField] private CameraControl m_cameraControl;

    public Player()
    {
        m_playerControl = new PlayerControl();
        m_cameraControl = new CameraControl();
    }

    void Start()
    {
        m_playerControl.Initialize(GetComponent<Rigidbody>());
        m_cameraControl.Initialize(Camera.main);
    }

    private void LateUpdate()
    {
        m_cameraControl.Update(transform);
    }

    private void FixedUpdate()
    {
        m_playerControl.Update(transform);
    }
}
