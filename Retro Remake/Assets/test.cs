using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public int coinCount;        // Ints represent WHOLE NUMBERS
    public float xPosition;      // Floats represents DECIMAL NUMBERS
    public string studentName;   // Strings represent WORDS OR PHRASES
    public bool enemyIsDead;     // Bools represent something TRUE OR FALSE
    public Vector2 ffCorpseLoc;  // Vectors2 represnt a 2-DIMENSIONAL NUMBER

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Derek's fav student is " + studentName);
        if (enemyIsDead) // Only run the below if enemyisdead is true rn
        {
            Debug.Log("You dead");
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
