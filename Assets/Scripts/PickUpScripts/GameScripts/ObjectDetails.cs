
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectDetails")]
public class ObjectDetails : ScriptableObject
{
    public new string Name;
    public int Id;
    [TextArea] public string Description;
    public Sprite UiImage;
}
