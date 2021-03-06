using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject bullet;
    public GameObject muzzle;
    public float attackTime = 1.5f;

    private bool m_isAttacking = false;
    private GameObject m_player;
    private float m_timer = 0.0f;

	// Use this for initialization
	void Start () {
        m_player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (m_isAttacking)
        {
            m_timer += Time.deltaTime;
            if (m_timer > attackTime)
            {
                m_timer = 0.0f;
                GameObject gun = Instantiate(bullet, muzzle.transform) as GameObject;
                Vector3 target = m_player.transform.position;
                target.y = 0.0f;
                Vector3 direction = (m_player.transform.position - gun.transform.position).normalized;
                if (gun.GetComponent<ballet>())
                {
                    gun.GetComponent<ballet>().SetVelocity(direction);
                }
            }
        }
        else
        {
            m_timer = 0.0f;
        }
	}

    public void ChangeMode(bool isAttacking)
    {
        m_isAttacking = isAttacking;
    }
}
