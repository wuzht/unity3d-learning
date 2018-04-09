using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private bool isMove;
    private float speed = 30;
    Vector3 destination;

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            if (transform.position == destination)
                isMove = false;
        }
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        isMove = true;
    }

    public void Reset()
    {
        isMove = false;
    }
}
