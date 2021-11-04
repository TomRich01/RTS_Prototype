using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScenes : MonoBehaviour
{
    public int loadlevel;
    
    public void LoadLevel()
    {
       
        SceneManager.LoadScene(loadlevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
