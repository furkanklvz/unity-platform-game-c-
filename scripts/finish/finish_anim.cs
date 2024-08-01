using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish_anim : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collectFruits.fruitsCollected)
        {
            GetComponent<Animator>().SetBool("completed", true);
            StartCoroutine(GameManager.nextLevel(SceneManager.GetActiveScene().buildIndex));
            GetComponent<ParticleSystem>().Play();
        }
    }
}
