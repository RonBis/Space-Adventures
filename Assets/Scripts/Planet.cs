using UnityEngine;

public class Planet : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0.05f, 0), Space.World);
    }
}
