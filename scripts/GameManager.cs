using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int hp = 1;
    private static GameManager instance;
    public GameObject finishLine;
    private void Awake()
    {
        finishLine.GetComponent<Animator>().SetBool("completed", false);
        // Tekil örnek kontrolü yapalým
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Bu nesneyi sahneler arasý geçiþlerde yok etme
        }
        else
        {
            Destroy(gameObject); // Birden fazla GameManager olmasýný engelle
        }
    }
    public static IEnumerator nextLevel(int i)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(i+1);
    }
}
