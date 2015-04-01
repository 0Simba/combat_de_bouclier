using UnityEngine;
using System.Collections;

public abstract class Mapping : MonoBehaviour {

    [HideInInspector]
    public IInput shoot;
    [HideInInspector]
    public IInput jump;
    [HideInInspector]
    public IInput dash;
    [HideInInspector]
    public Vector2 moveAxis = Vector2.zero;
    [HideInInspector]
    public Vector2 aimAxis = Vector2.zero;

    public uint deviceID = 0;
}
