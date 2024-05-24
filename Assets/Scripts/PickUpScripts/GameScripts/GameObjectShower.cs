using UnityEngine;

public class GameObjectShower : MonoBehaviour
{
    
     public  ObjectDetails ObjectDetails;
 
        
    private void OnTriggerEnter(Collider other)
    {
        //check the collided object is player
       if(other.CompareTag("Player"))
        {
        
            //Invoke when the player is collided with the zone
            GameEvents.untiyAction.Invoke(ObjectDetails);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Invoke when the player is exited from the zone
        GameEvents.Exited.Invoke();
    }
}
