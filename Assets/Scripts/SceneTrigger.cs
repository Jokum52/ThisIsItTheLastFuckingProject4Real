using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour{
public string loadName;
public string unloadName;
private void OnTriggerEnter(Collider col){

        if (loadName != "")
            GameSceneManager.Instance.Load(loadName);
        if (unloadName != "")
            StartCoroutine("UnloadScene");
    }

    IEnumerator UnloadScene(){

        yield return new WaitForSeconds(.10f);
        GameSceneManager.Instance.Unload(unloadName);
    }
}
