using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScrene : MonoBehaviour
{
    public void Hira()
    {
        SceneManager.LoadScene(1);
    }
    public void Kata()
    {
        SceneManager.LoadScene(2);
    }
    public void Kanji()
    {
        SceneManager.LoadScene(3);
    }
}
