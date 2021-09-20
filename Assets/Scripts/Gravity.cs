using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject parent;
    public bool isGravityOn = true;

    float parentMass, satelliteMass, distanceSqr, force;

    private void Start()
    {
        parentMass = parent.GetComponent<Rigidbody>().mass;
        satelliteMass = gameObject.GetComponent<Rigidbody>().mass;
        distanceSqr = (parent.transform.position - transform.position).sqrMagnitude;
        force = 6.7f * (parentMass * satelliteMass) / distanceSqr;
        float velocity = Mathf.Sqrt(force * Mathf.Sqrt(distanceSqr) / satelliteMass);

        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -velocity);
    }

    private void FixedUpdate()
    {
        Vector3 direction = (parent.transform.position - transform.position).normalized;
        if (isGravityOn)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(force * direction);
        }
    }
}
