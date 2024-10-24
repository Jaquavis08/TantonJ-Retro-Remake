using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameObject Score;
    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        print(gameObject);
        if(gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            //Score.text = 
        }
       
        
    }

}