using UnityEngine;
using System.Collections;

public abstract class IInput
{
    public bool IsPressed;
    public bool WasPressed;
    public bool WasReleased;
    public bool HasChanged;

    public void Update() { }
}