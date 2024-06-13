using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EdgeType
{
    Bottom,
    Right,
    Left
}
public class LevelEdge : MonoBehaviour
{
    [SerializeField] private EdgeType type;

    public EdgeType Type => type;
}