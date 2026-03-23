using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandler : MonoBehaviour

{
   
    public void StartGame()
    {

        SceneManager.LoadScene(1);
    }

    public void ChangeScene()
    {

        SceneManager.LoadScene(2);
    }
}
