using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionControl : MonoBehaviour
{
    [SerializeField] public static bool isGrounded;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        playerMovements.anim.SetBool("isJumping", false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        playerMovements.anim.SetBool("isJumping", true);
    }
}
