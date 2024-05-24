

using UnityEngine.Events;

internal static class GameEvents 
{
    //Unity action for calling when the player is collided with the game object to show the details 
    public static UnityAction<ObjectDetails> untiyAction;
    //Unity action for calling when the player exited from the objects zone
    public static UnityAction Exited;
}
