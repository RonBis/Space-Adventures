using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlanetLand))]
public class PlanetEditor : Editor
{
    PlanetLand planet;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Generate Planet"))
        {
            planet.Initialise();
        }

        DrawSettingsEditor(planet.colorSettings, planet.OnColorSettingsUpdated);
    }

    void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated)
    {
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            Editor editor = CreateEditor(settings);
            editor.OnInspectorGUI();

            if (check.changed)
            {
                if(onSettingsUpdated != null)
                {
                    onSettingsUpdated();
                }
            }
        }
    }

    private void OnEnable()
    {
        planet = (PlanetLand)target;
    }
}
