using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class GravitySensor : MonoBehaviour, ITrackableEventHandler
{

    public TrackableBehaviour m_trackableBehaviour;
    private bool m_tracking = false;
    private Vector3 m_gravitySensor;
    private Rigidbody m_rigidbody;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        // Register event
        m_trackableBehaviour.RegisterTrackableEventHandler(this);

        // Enable gravity by gyroscope
        Input.gyro.enabled = true;
    }

    void Update()
    {

        // Stop moving if there is no tracking
        if (m_tracking == false)
        {
            m_rigidbody.velocity = Vector3.zero;
            return;
        }

        // Use a gravity sensor and convert vector 
        m_gravitySensor = Input.gyro.gravity;
        Vector3 TransGravity = new Vector3(m_gravitySensor.x, m_gravitySensor.z, m_gravitySensor.y);
        m_rigidbody.velocity = TransGravity;
    }


    // Reference DefaultTrackableEventHandler
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            m_tracking = true;
        }
        else
        {
            m_tracking = false;
        }
    }

}
