using System;
using System.Collections;
using System.Collections.Generic;
using Game.General;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public ScenesData sceneDB;
    
    public int currentGameSceneIndex = 0;

    public ProbabilityHandler probabilityHandler;
    
    public Player[] players;
    public int currentPlayerInputIndex = 0;
    public PlayerInputHandler[] playerInputHandlers = new PlayerInputHandler[4];

    public GameController gameController;

    protected override void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Destroy(this.gameObject);
            return;
        } else {
            _Instance = this;
        }
        
        Debug.Log( "GameManager Awake" );
        Application.targetFrameRate = 30;

        FindAllPlayers();
        for ( int i = 0; i < players.Length; i++ )
        {
            players[i].gameObject.SetActive( false );
        }

        gameController = FindObjectOfType<GameController>();
        DontDestroyOnLoad( this );
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log( "GameManager Start" );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        sceneDB.ResetAllGamesState();
    }

    public bool CheckIsAllPlayerDead()
    {
        bool isAllDead = true;
        foreach ( var player in players )
        {
            isAllDead &= !player.healthSystem.IsAlive();
        }
        Debug.Log( "isAllDead "+ isAllDead );

        return isAllDead;
    }

    public void LoadNextGame()
    {
        MainBoardManager.Instance.SetIsOtherScene( true );
        MainBoardManager.Instance.PasueGame();
        
        DisReadyAllPlayerInput();
        
        //currentGameSceneIndex++;
        //sceneDB.LoadLevelWithIndex( currentGameSceneIndex );

        StartCoroutine( sceneDB.LoadNextGame( LoadSceneAwakeAction ) );
    }

    public void LoadBackToMainScene()
    {
        DisReadyAllPlayerInput();
        
        StartCoroutine( sceneDB.LoadBackToMainScene( LoadMainSceneAwakeAction ) );
    }

    private void ChangeAllGameController()
    {
        gameController = FindObjectOfType<GameController>();
        for ( int i = 0; i < currentPlayerInputIndex; i++ )
        {
            playerInputHandlers[i].SetupPlayer();
            playerInputHandlers[i].gameController = gameController;
        }
    }

    public void AddToPlayerInputHandlers( PlayerInputHandler playerInputHandler )
    {
        playerInputHandlers[ currentPlayerInputIndex ] = playerInputHandler;
        playerInputHandler.gameController = gameController;
        players[currentGameSceneIndex].gameObject.SetActive( true );
        currentPlayerInputIndex++;
    }

    public void ActivePlayer( int index )
    {
        players[index].gameObject.SetActive( true );
    }

    public void ActivePlayerInput( int index )
    {
        playerInputHandlers[index].EnablePlayerInputHandler();
    }
    
    public void ActiveAllPlayerInput()
    {
        for ( int i = 0; i < currentPlayerInputIndex; i++ )
        {
            playerInputHandlers[i].EnablePlayerInputHandler();
        }
    }
    
    
    

    public void DeactivatePlayerInputExcept( int index )
    {
        for ( int i = 0; i < currentPlayerInputIndex; i++ )
        {
            if (  playerInputHandlers[i].GetPlayerID() == index )
            {
                playerInputHandlers[i].EnablePlayerInputHandler();
                continue;
            }
            playerInputHandlers[i].DisablePlayerInputHandler();
        }
    }

    public int GetCurrentNumberOfPlayer()
    {
        return currentPlayerInputIndex;
    }

    private void LoadSceneAwakeAction()
    {
        //ReadyAllPlayerInput();
        FindAllPlayers();
        DeactivateMissingPlayer();
        ChangeAllGameController();
    }
    
    private void LoadMainSceneAwakeAction()
    {
        //ReadyAllPlayerInput();
        FindAllPlayers();
        DeactivateMissingPlayer();
        ChangeAllGameController();
        
        MainBoardManager.Instance.SetIsOtherScene( false );
        MainBoardManager.Instance.FindDice();
    }

    private void FindAllPlayers()
    {
        players = FindObjectsOfType<Player>();
        Array.Sort( players , delegate ( Player s1 , Player s2)
        {
            return s1.index.CompareTo( s2.index );
        });
        foreach ( var player in players )
        {
            player.gameObject.SetActive( true );
        }
        
    }

    private void DeactivateMissingPlayer()
    {
        for ( int i = currentPlayerInputIndex; i < players.Length; i++ )
        {
            players[i].gameObject.SetActive( false );
        }
    }

    private void DisReadyAllPlayerInput()
    {
        for ( int i = 0; i < currentPlayerInputIndex; i++ )
        {
            playerInputHandlers[i].isReady = false;
        }
    }

    private void ReadyAllPlayerInput()
    {
        for ( int i = 0; i < currentPlayerInputIndex; i++ )
        {
            playerInputHandlers[ i ].isReady = true;
        }
    }
}
