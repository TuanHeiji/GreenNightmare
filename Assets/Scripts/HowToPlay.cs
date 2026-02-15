using UnityEngine;
using UnityEngine.SceneManagement;
public class HowToPlay : MonoBehaviour
{
   public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
