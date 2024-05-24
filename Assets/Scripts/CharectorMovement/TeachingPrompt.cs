using System.Collections;
using UnityEngine;

public class TeachingPrompt : MonoBehaviour
{
    [SerializeField] GameObject UiPannel;
    void Start()
    {
        StartCoroutine(TechngUi());
    }

    private IEnumerator TechngUi()
    {
        yield return new WaitForSeconds(1f);
        UiPannel.SetActive(true);

    }
   
    public void Quit()
    {
        Application.Quit();
    }
}
