using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooperateTDManager : Singleton<CooperateTDManager>
{

    public Grid<TDNode> grid;

    public int lives = 20;

    public int money = 100;

    public Transform enemySpawnPoint;
    public Transform enemyParent;
    public TDWave[] waves;
    public int currentEnemyCount = 0;
    public int currentRound = 0;
    public bool isRoundStarted = false;
    public bool isRoundEnd = false;
    public float waitTimeForNextRound = 30.0f;
    
    public bool isGameStarted = false;


    public bool testLoadScene = false;

    protected override void Awake()
    {
        grid = new Grid<TDNode>( 11, 21, 1f, new Vector3( 0, 1f, 0f ), (Grid<TDNode> g, int x, int y) => new TDNode(g, x, y) );
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if ( testLoadScene )
        {
            GameManager.Instance.LoadBackToMainScene();
            testLoadScene = false;

        }
        
        if ( isGameStarted )
        {
            isGameStarted = false;

            StartCoroutine( SpawnRoundEnemies() );
        }

        if ( isRoundStarted )
        {
            CheckEndRound();
        }

        if ( isRoundEnd )
        {
            StartCoroutine( WaitAndStartNextRound() );
        }
    }

    private IEnumerator WaitAndStartNextRound()
    {
        isRoundEnd = false;
        money += waves[ currentRound ].money;
        yield return new WaitForSeconds( waitTimeForNextRound );
        currentRound++;
        StartCoroutine( SpawnRoundEnemies() );
    }

    public IEnumerator SpawnRoundEnemies()
    {
        isRoundStarted = true;
        for ( int i = 0; i < waves[currentRound].enemyNumber; i++ )
        {
            var enemy = Instantiate( waves[ currentRound ].enemyPrefab, enemySpawnPoint.position, Quaternion.identity );
            enemy.transform.parent = enemyParent;
            currentEnemyCount++;
            yield return new WaitForSeconds( 1.0f );
        }
    }

    public bool CheckEndRound()
    {
        isRoundEnd = currentEnemyCount <= 0;
        if ( isRoundEnd )
        {
            isRoundStarted = false;
        }
        return isRoundEnd;
    }

    public bool CheckLost()
    {
        return lives <= 0;
    }

    public void DecreaseLive( int damage )
    {
        lives -= damage;
        Debug.Log( "DecreaseLive" );
    }
}
