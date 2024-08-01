using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTrap : MonoBehaviour
{
    public Transform[] points;
    public int startPoint;
    [SerializeField] private int i;
    public float speed;
    void Start()
    {
        i = startPoint;
        transform.position = points[startPoint].position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            if (i == points.Length - 1) i = 0;
            else i++;
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
}
