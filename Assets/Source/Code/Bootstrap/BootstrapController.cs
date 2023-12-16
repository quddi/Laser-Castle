using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapController : MonoBehaviour
{
    [SerializeField, TabGroup("Parameters")] private string _gameSceneName;
    
    private void Start()
    {
        SceneManager.LoadScene(_gameSceneName);
    }
}
