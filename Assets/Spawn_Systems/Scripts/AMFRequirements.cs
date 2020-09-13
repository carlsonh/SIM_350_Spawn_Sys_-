using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMFRequirements
{
    public int wingCount = 0;
    public AMFType amfType;

    public bool bMoving = false;

}

public enum AMFType
{
    Animal,
    Mechanical,
    Failure
}
