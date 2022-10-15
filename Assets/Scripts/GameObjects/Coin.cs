using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeed;//degrees/second

    // Update is called once per frame
    void Update()
    {
        //Rotate vertically over time
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);//This now rotates degrees/second rather than degrees/frame
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().AddCoin(1);
            Destroy(gameObject);
        }
    }
}
