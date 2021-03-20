using UnityEngine;
public class DontDestroyObject : MonoBehaviour
{
    //This can be applied to any object you dont want destoryed when switching scenes
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}