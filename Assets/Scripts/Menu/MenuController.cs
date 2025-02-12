using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            if(EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
            }
        #endif

        Application.Quit();
    }
}
