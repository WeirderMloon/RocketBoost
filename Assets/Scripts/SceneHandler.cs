using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandler : MonoBehaviour

{
   
    public void Menutolevelselect()
    {

        SceneManager.LoadScene(1);
    }

    public void tolevelonestarter()
    {

        SceneManager.LoadScene(2);
    }

     public void ChangeLVL2()
    {

        SceneManager.LoadScene(6);
    }

    public void Changetolvl1()
    {

        SceneManager.LoadScene(5);
    }

    public void Lvltwostarter()
    {

        SceneManager.LoadScene(3);
    }

    public void Lvlthreestarter()
    {

        SceneManager.LoadScene(4);
    }

    public void Lvlthree()
    {

        SceneManager.LoadScene(7);
    }

    public void Lvl1toexit()
    {

        SceneManager.LoadScene(1);
    }

    public void Lvl2toexit()
    {

        SceneManager.LoadScene(1);
    }

    public void Lvlthreetoexit()
    {

        SceneManager.LoadScene(1);
    }
}
