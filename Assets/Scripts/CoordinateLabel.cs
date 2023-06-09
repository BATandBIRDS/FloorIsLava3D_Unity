using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
    TextMeshPro lbl;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        lbl = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjNames();
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x =
            Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);

        coordinates.y =
            Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        lbl.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjNames()
    {
        transform.parent.name = coordinates.ToString();
    }
}
