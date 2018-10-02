using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class DebugPlane : MonoBehaviour{

    public Transform m_debugPlane;
    public float m_YOffset;

	void Start () {

    }
	
	void Update () {
        m_debugPlane.position = new Vector3(m_debugPlane.position.x, transform.position.y + m_YOffset, transform.position.z);
    }
}
