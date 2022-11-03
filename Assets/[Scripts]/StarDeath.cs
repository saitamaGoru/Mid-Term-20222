using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name=="ForeGround")
        {
            Destroy(this.gameObject,4);
        }
    }
} 
