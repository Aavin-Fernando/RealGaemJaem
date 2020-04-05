using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuStuff : MonoBehaviour
{
    public void Exit(){
        Application.Quit();
    }
    
    public void LoadLevel(int i){
        SceneManager.LoadScene(i);
    }
}
