using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Función para cargar una nueva escena
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

