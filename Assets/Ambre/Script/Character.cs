using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    [SerializeField] PlayerControllerAmbre playerController;

    public GameObject character;
}
