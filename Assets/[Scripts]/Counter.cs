using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
   public float counter = 0.0f;
    float timer =0.2f;
    public Transform spawnPoint;
    public GameObject star;
    private void FixedUpdate()
    {
       
        counter++;
        SpawnStar();
    }

     void SpawnStar()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Instantiate(star, spawnPoint.position, spawnPoint.rotation);
            timer = 0.2f;

        }



    }
}
