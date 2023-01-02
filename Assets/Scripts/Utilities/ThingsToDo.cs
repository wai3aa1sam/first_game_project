using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "ThingsToDo", menuName = "TODO/ThingsToDo" )]
public class ThingsToDo : ScriptableObject
{
    [TextArea(10, 100)]
    public string description;
}
