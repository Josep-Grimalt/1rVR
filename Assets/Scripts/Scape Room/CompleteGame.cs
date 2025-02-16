using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
    }
}
