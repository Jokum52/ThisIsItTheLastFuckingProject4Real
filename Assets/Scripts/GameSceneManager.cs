using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour{
public static GameSceneManager Instance {set;get;}

private void Awake (){
        Instance = this;
        Load("Player");
        Load("01");
   }

public void Load (string sceneName){
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
public void Unload(string sceneName){
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
            SceneManager.UnloadScene(sceneName);
    }
}
