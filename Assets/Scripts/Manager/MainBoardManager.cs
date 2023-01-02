using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBoardManager : Singleton<MainBoardManager>
{
    public enum State
    {
        GameStart,
        GameRunning,
        PlayerState,
        GamePasue,
    }

    public BoardDice6 dice6;

    public State state;

    public bool isGameStarted = false;

    public int roundToGame = 7;
    public int currentRound = 0;

    public int currentPlayerIndex = 0;

    private int currentNumberOfPlayers = 0;

    public bool isOtherScene = false;

    protected override void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Destroy(this.gameObject);
            return;
        } else {
            _Instance = this;
        }
        DontDestroyOnLoad( this );
        state = State.GamePasue;
    }

    private void Update()
    {
        if ( isOtherScene )
        {
            return;
        }

        if ( isGameStarted )
        {
            StartCoroutine( GameLoop() );
            state = State.GameRunning;
            isGameStarted = false;
        }
        
        switch ( state )
        {
            case State.GameStart:
                StartCoroutine( GameLoop() );
                state = State.GameRunning;
                break;
            case State.GameRunning:
                break;
            case State.PlayerState:
                break;
            case State.GamePasue:
                state = State.GamePasue;
                StopAllCoroutines();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private IEnumerator GameLoop()
    {
        while ( currentPlayerIndex < GameManager.Instance.GetCurrentNumberOfPlayer() )
        {
            // Disable all player input except the actual one
            GameManager.Instance.DeactivatePlayerInputExcept( currentPlayerIndex );
            var playerBoardController =
                GameManager.Instance.playerInputHandlers[ currentPlayerIndex ].gameController as MainBoardController;
            while ( WaitForPlayerRoll( playerBoardController ) )
            {
                Debug.Log( "Waiting Player" + currentPlayerIndex + " to roll..." );
                if ( isOtherScene )
                {
                    yield break;
                }
                yield return null;
            }
            yield return new WaitForSeconds( 0.5f );

            playerBoardController.hasRolled = false;
            ++currentPlayerIndex;
            currentPlayerIndex %= GameManager.Instance.GetCurrentNumberOfPlayer();
            
            // Next Round if all players has rolled
            if ( currentPlayerIndex == 0 )
            {
                Debug.Log( "Round " + currentRound + " is end..." );
                currentRound++;
                
                // Check if is party game time
                if ( currentRound % roundToGame == 0 )
                {
                    GameManager.Instance.LoadNextGame();
                }
            }
        }
    }

    private bool WaitForPlayerRoll( MainBoardController mainBoardController )
    {
        return !mainBoardController.hasRolled;
    }

    public void SetIsOtherScene( bool isOtherScene )
    {
        this.isOtherScene = isOtherScene;
    }

    public void PasueGame()
    {
        state = State.GamePasue;
    }

    public void StartGame()
    {
        state = State.GameStart;
    }

    public void FindDice()
    {
        dice6 = FindObjectOfType<BoardDice6>();
    }
}
