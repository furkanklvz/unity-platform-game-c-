using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fruitsControl : MonoBehaviour
{
    public static int numOfFruits;
    private void Awake()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                numOfFruits = 4;
                break;
            default:
                break;
        }
    }
}
