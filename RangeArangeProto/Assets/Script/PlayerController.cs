using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float MOVESPEED = 0.05f;
    private float JUMPPOWER = 7.5f;

    private Rigidbody m_rigidbody;
    public bool m_isGround = false;
    public GameObject stageManager;

    // Use this for initialization
    void Start () {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        float front = 0.0f;
        float right = 0.0f;
        float up = 0.0f;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            right = Input.GetAxis("Horizontal");
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            front = Input.GetAxis("Vertical");
        }
        if (Input.GetKeyDown(KeyCode.Space) && m_isGround)
        {
            up = JUMPPOWER;
            m_isGround = false;
        }
        m_rigidbody.position += new Vector3(right, up, front) * MOVESPEED;

        if (Input.GetKeyDown(KeyCode.A))
        {
            StageManger manager = stageManager.GetComponent<StageManger>();
            if (manager){
                manager.SetStageChangeMode();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground")
        {
            m_isGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //Debug.Log(m_rigidbody.velocity.y);
            if (m_rigidbody.velocity.y <= 0.0f)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
