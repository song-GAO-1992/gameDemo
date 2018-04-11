using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public delegate void SceneHandler();


public class SceneManagers : MonoBehaviour
{
    public event SceneHandler SceneEvent;
    

    void MoveTo()
    {
        SceneManager.LoadScene("Level2");
    }
}
