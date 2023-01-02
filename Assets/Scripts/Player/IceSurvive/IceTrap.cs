using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTrap : MonoBehaviour
{
    private float damage = 20.0f;
    public float speed = 3.0f;
    public Vector3 finalPosition;
    public Vector3 basePosition;

    public enum State
    {
        Idle,
        OnTraping,
        OffTraping
    }

    public State state = State.Idle;
    public bool waitForTrap = false;
    public float waitTrapTime = 2.0f;

    private void Awake()
    {
        basePosition = transform.position;
        finalPosition = new Vector3( basePosition.x, 0.0f, basePosition.z );
    }

    private void Start()
    {
        //OnTrap();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if ( waitForTrap )
        {
            waitForTrap = false;
            StartCoroutine( WaitForOnTrap() );
        }
        switch ( state )
        {
            case State.Idle:
                break;
            case State.OnTraping:
                OnTrap();
                break;
            case State.OffTraping:
                OffTrap();
                break;
            default:
                break;
        }
    }

    public void SetOnTrap()
    {
        state = State.OnTraping;
    }

    private void OnTrap()
    {
        transform.position = Vector3.Lerp( transform.position, finalPosition, speed * Time.deltaTime );
        state = State.OnTraping;
        waitForTrap = true;
    }

    private void OffTrap()
    {
        var pos = Vector3.Lerp( transform.position, basePosition, speed * Time.deltaTime );
        if ( transform.position == pos )
        {
            state = State.Idle;
        }
        else
        {
            transform.position = pos;
        }
    }

    private IEnumerator WaitForOnTrap()
    {
        yield return new WaitForSeconds( waitTrapTime );
        state = State.OffTraping;
    }

    private void OnTriggerEnter( Collider other )
    {
        if ( other.CompareTag( "Player" ) )
        {
            var player = other.GetComponent<Player>();
            player.healthSystem.TakeDamage( damage );
        }
    }
}
