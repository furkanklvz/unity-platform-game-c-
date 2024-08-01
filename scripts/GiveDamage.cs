using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class GiveDamage : MonoBehaviour
{
    private const int V = 55;
    public GameObject hero;
    public Material playerMaterial;
    public static bool moveBan = false;
    private Color materialColor;
    private SpriteRenderer heroSR;
    private void Start()
    {
        heroSR = hero.GetComponent<SpriteRenderer>();
        materialColor = playerMaterial.color;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("boxTrap"))
        {
            StartCoroutine(respawn());
        }
        else
        {
            GameManager.hp--;
            Debug.Log("Tuzağa Çarptı. Kalan can: " + GameManager.hp);
            if (GameManager.hp == -1)
            {
                GameManager.hp = 1;
                StartCoroutine(respawn());
            }
            else
            {
                StartCoroutine(damageAnim());
            }
        }
    }
    IEnumerator damageAnim()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        hero.GetComponent<Animator>().SetTrigger("hitted");
        hero.GetComponent<Animator>().SetBool("isRunning", false);
        hero.GetComponent<Animator>().SetBool("isJumping", false);
        hero.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3.7f);
        yield return new WaitForSecondsRealtime(0.35f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    IEnumerator respawn()
    {
        Debug.Log("respawn");
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                hero.transform.position = new Vector3(-2.93f, -1.32f, hero.transform.position.z);
                break;
            case 1:
                hero.transform.position = new Vector3(-2.67f, -1.60f, hero.transform.position.z);
                break;
        }
        heroSR.flipX = false;
        playerMovements.anim.SetBool("isRunning", false);
        playerMovements.anim.SetBool("isJumping", false);
        moveBan = true;
        hero.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        for (int i = 0; i < 6; i++)
        {
            if (i % 2 == 0)
            {
                materialColor.a = 0.3f;
                playerMaterial.color = materialColor;
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                materialColor.a = 1;
                playerMaterial.color = materialColor;
                yield return new WaitForSeconds(0.1f);
            }
        }
        moveBan = false;
    }
}
