using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTraget : MonoBehaviour
{
    public void LoadSceneNum(int num)
    {
        LoadingScreenManager.LoadScene(num);
    }
}
