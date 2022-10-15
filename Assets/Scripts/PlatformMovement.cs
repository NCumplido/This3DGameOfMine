using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float velocity;
    public Vector3 moveDirection;
    public float moveDistance;
    private Vector3 startPosition;
    private bool movingToStart;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingToStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, velocity * Time.deltaTime);

            if (transform.position == startPosition)
            {
                movingToStart = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition + (moveDirection * moveDistance), velocity * Time.deltaTime);

            if (transform.position == startPosition + (moveDirection * moveDistance))
            {
                movingToStart = true;
            }
        }
    }
}
