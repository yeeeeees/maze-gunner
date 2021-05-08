using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyObject : MonoBehaviour
{
    //This can be applied to any object you dont want destoryed when switching scenes
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Debug.Log("Spasio sam te misu mali - Edo Maajka, kao Sid");
        Debug.Log(SceneManager.GetActiveScene().buildIndex + " is curent build index");
    }
}