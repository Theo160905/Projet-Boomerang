using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isRecup = true;

    [SerializeField]
    private UseBoomerang useBoomerang;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isRecup == true)
        {
            useBoomerang.ThrowBoommerang();
        }
    }

}
