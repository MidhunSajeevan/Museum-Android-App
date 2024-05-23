using UnityEngine;
using UnityEngine.Events;

public class GameObjectShower : MonoBehaviour
{
    
     public  ObjectDetails ObjectDetails;
 
        
    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player"))
        {
        
            GameEvents.untiyAction.Invoke(ObjectDetails);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameEvents.Exited.Invoke();
    }
}
