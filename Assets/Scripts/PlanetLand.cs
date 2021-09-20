using UnityEngine;

public class PlanetLand : MonoBehaviour
{
    Mesh landMesh;
    ColorGenerator colorGenerator = new ColorGenerator();
    public ColorSettings colorSettings;
    public ElevationMinMax elevationMinMax;

    public void Initialise()
    {
        colorGenerator.UpdateSettings(colorSettings);

        colorGenerator.UpdateElevation(CalculateMinMaxElevation());
        colorGenerator.UpdateColors();
        gameObject.GetComponent<MeshRenderer>().sharedMaterial = colorSettings.planetMaterial;
    }

    public void OnColorSettingsUpdated() => Initialise();

    public ElevationMinMax CalculateMinMaxElevation()
    {
        elevationMinMax = new ElevationMinMax();
        landMesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
        Vector3[] vertices = landMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            float distance = Mathf.Sqrt(
                Mathf.Pow(transform.localPosition.x - vertices[i].x, 2) +
                Mathf.Pow(transform.localPosition.y - vertices[i].y, 2) +
                Mathf.Pow(transform.localPosition.z - vertices[i].z, 2)
            );
            elevationMinMax.AddValue(distance);
        }

        return elevationMinMax;
    }
}
