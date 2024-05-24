using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject environment;
    public GameObject Prefab;
    void Start()
    {
        environment = GameObject.Find("EnvironMent(Clone)");

        if (environment == null)
        {
        
            //Load the Environment if failed to load from the server
            Instantiate(Prefab);
        }
    }

  
}
