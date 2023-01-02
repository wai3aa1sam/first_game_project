using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[CreateAssetMenu( fileName = "sceneDB" + "", menuName = "Scene Data/Database" )]
public class ScenesData : ScriptableObject
{
    public List<PartyGameScene> parties = new List<PartyGameScene>();
    //public List<Menu> menus = new List<Menu>();
    public int CurrentLevelIndex = 1;

    /*
     * Levels
     */

    //Load a scene with a given index
    public void LoadLevelWithIndex( int index )
    {
        if (  index <= parties.Count - 1 )
        {
            Debug.Log( parties[index].sceneName );
            SceneManager.LoadSceneAsync( parties[index].sceneName );
            //Load Gameplay scene for the level
            //SceneManager.LoadSceneAsync("Gameplay" + index.ToString());
            //Load first part of the level in additive mode
            //SceneManager.LoadSceneAsync("Level" + index.ToString() + "Part1", LoadSceneMode.Additive);
        }
        //reset the index if we have no more levels
        else CurrentLevelIndex = 1;
    }
    
    public IEnumerator LoadNextGame( Action loadSceneAwakeAction )
    {
        yield return null;

        int index = Random.Range( 1, parties.Count );
        while ( !IsAllGamePlayed() && parties[index].hasPlayed )
        {
            index = Random.Range( 1, parties.Count );
        }

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync( parties[index].sceneName );

        parties[ index ].hasPlayed = true;
        
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            //m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                // TODO: add key press
                //Activate the Scene
                asyncOperation.allowSceneActivation = true;

                //Change the Text to show the Scene is ready
                //m_Text.text = "Press the space bar to continue";
                
                //Wait to you press the space key to activate the Scene
                //if (Input.GetKeyDown(KeyCode.Space))
            }

            yield return null;
        }
        loadSceneAwakeAction();
    }

    public IEnumerator LoadBackToMainScene( Action loadSceneAwakeAction )
    {
        yield return null;
        
        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync( parties[0].sceneName );
        
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            //m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                // TODO: add key press
                //Activate the Scene
                asyncOperation.allowSceneActivation = true;

                //Change the Text to show the Scene is ready
                //m_Text.text = "Press the space bar to continue";
                
                //Wait to you press the space key to activate the Scene
                //if (Input.GetKeyDown(KeyCode.Space))
            }

            yield return null;
        }

        int fff = 5;
        loadSceneAwakeAction();
    }

    private bool IsAllGamePlayed()
    {
        var played = true;
        for ( int i = 1; i < parties.Count; i++ )
        {
            played &= parties[ i ].hasPlayed;
        }
        return played;
    }

    public void ResetAllGamesState()
    {
        for ( int i = 1; i < parties.Count; i++ )
        {
            parties[ i ].hasPlayed = false;
        }
    }

    //Start next level
    public void NextLevel()
    {
        CurrentLevelIndex++;
        LoadLevelWithIndex( CurrentLevelIndex );
    }

    //Restart current level
    public void RestartLevel()
    {
        LoadLevelWithIndex( CurrentLevelIndex );
    }

    //New game, load level 1
    public void NewGame()
    {
        LoadLevelWithIndex( 1 );
    }

    /*
     * Menus
     */

    //Load main Menu
    public void LoadMainMenu()
    {
        //SceneManager.LoadSceneAsync(menus[(int)Type.Main_Menu].sceneName);
    }

    //Load Pause Menu
    public void LoadPauseMenu()
    {
        //SceneManager.LoadSceneAsync(menus[(int)Type.Pause_Menu].sceneName);
    }
}
