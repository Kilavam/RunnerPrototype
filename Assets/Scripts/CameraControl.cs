using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CameraControl
{
    private Camera m_camera;

    [SerializeField] private float m_distance = 10;

    public void Initialize(Camera camera)
    {
        m_camera = camera;
    }

    public void Update(Transform target)
    {
        Vector3 desiredPosition = target.position - Vector3.forward * m_distance;

        m_camera.transform.position = desiredPosition; // Vector3.Lerp(m_camera.transform.position, desiredPosition, 0.1f);
    }
}
