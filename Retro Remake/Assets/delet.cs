using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delet : MonoBehaviour
{

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delete());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
