using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour,ActionBase
{
    [SerializeField] string sceneName;
    public  void Action()
    {
        SceneManager.LoadScene(sceneName);
    }
}
