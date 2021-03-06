﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private float MOVESPEED = 0.05f;
    private float JUMPPOWER = 11.5f;
    private int m_HP = 3;

    private Rigidbody m_rigidbody;
    public bool m_isGround = false;
    public GameObject moveErea;
    public Slider HPSlider;


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
            if (moveErea)
            {
                if (moveErea.GetComponent<EreaChanger>().MoveErea())
                {
                    gameObject.transform.SetParent(moveErea.transform);
                }
            }
        }

        if(m_HP <= 0)
        {
            Scene loadScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(loadScene.name);
        }

        HPSlider.value =  ((float)m_HP / 3.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground")
        {
            m_isGround = true;
            
        }
        
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Erea")
        {
            moveErea = collision.gameObject;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Erea")
        {
            moveErea = null;
        }
        if(collision.tag == "ballet")
        {
            m_HP--;
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
