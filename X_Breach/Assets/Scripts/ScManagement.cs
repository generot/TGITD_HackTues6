using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor.SceneManagement;

public class ScManagement : MonoBehaviour
{
    List<Scene> scenes;

    void Start()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
            scenes.Add(SceneManager.GetSceneAt(i));
    }

    public void GameOver()
    {
        Scene gameOverScene = SceneManager.GetSceneByName("GameOver");
        SceneManager.LoadScene(gameOverScene.buildIndex);
    }
}
