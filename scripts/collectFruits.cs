using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectFruits : MonoBehaviour
{

    // Update is called once per frame
    public Animator animator;
    public static bool fruitsCollected = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            fruitsControl.numOfFruits--;
            if (fruitsControl.numOfFruits == 0)
            {
                Debug.Log("Bütün meyveler toplandý.");
                fruitsCollected=true;
            }
            animator.SetTrigger("collected");
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
    
}
