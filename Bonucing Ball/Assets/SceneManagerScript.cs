using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GoToGameScene()
    {
        SceneManager.LoadScene("StartScene");
    }

}
