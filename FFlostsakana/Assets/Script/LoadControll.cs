using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadControll : MonoBehaviour
{
    public Slider loadBar;

    AsyncOperation async;

    public void LoadScreen(int LVL)
    {
        StartCoroutine(Loading(LVL));
    }

    IEnumerator Loading(int lvl)
    {
        async = SceneManager.LoadSceneAsync(lvl);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            loadBar.value = async.progress;
            if(async.progress == 0.9f)
            {
                loadBar.value = 1f;
                async.allowSceneActivation = true;
            }
        }
        yield return null;
    }
}
