using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowObjectDetails : MonoBehaviour
{
  
    [SerializeField] GameObject pannel;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI Description;
    void Start()
    {
        GameEvents.untiyAction += showDetails;
        GameEvents.Exited += RemoveDetails;
    }

   
    void showDetails(ObjectDetails details)
    {
       
        pannel.SetActive(true);
        Name.text = details.Name;
        Description.text = details.Description;
        image.sprite = details.UiImage;
        
    }
    void RemoveDetails()
    {
        pannel.SetActive(false);
    }
}
