using UnityEngine;

public class FixedRotation : MonoBehaviour
{
    Quaternion _fixedRotation;

    // Start is called before the first frame update
    void Start()
    {
        _fixedRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = _fixedRotation;
    }
}
