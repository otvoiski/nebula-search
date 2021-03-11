using Assets.Script.Enumerator;
using Assets.Script.Util;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    private const float DISTANCE_HIT_COLLIDER = 1.0f;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void SpriteColor(bool active)
    {
        sprite.color = active ? new Color(0, 1, 0, .200f) : new Color(1, 0, 0, .200f);
    }

    public Wire Next(List<string> last)
    {
        var wires = Utilities.GetItemsFromRayCast<Wire>(transform, DISTANCE_HIT_COLLIDER);
        foreach (var wire in wires)
        {
            if (last.Contains(wire.name)) continue;
            else
            {
                last.Add(wire.name);
                return wire;
            }
        }

        return null;
    }
}