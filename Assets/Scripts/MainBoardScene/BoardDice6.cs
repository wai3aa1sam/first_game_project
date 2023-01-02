using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardDice6 : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;
    public int diceNumber = -1;
    public bool isRolled = false;

    // Use this for initialization
    void Start () 
    {
        rb = GetComponent<Rigidbody> ();
    }
	
    // Update is called once per frame
    void Update () 
    {
        diceVelocity = rb.velocity;
    }

     public void RollDice()
    {
        Debug.Log( "Rolled" );
        float dirX = Random.Range (0, 25);
        float dirY = Random.Range (0, 12);
        float dirZ = Random.Range (0, 33);
        var pos = new Vector3( transform.position.x, transform.position.y * 2, transform.position.z );
        transform.position = pos;
        transform.rotation = Quaternion.identity;
        rb.AddForce (transform.up * 12);
        rb.AddTorque (dirX, dirY, dirZ);
    }
}
