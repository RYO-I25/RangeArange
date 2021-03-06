using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballet : MonoBehaviour {

    public Vector3 m_velocity = Vector3.zero;
    public float speed = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += m_velocity * speed;
	}

    public void SetVelocity(Vector3 velocity)
    {
        m_velocity = velocity;
    }
}
