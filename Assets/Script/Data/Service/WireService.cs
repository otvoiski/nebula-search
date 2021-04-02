using Assets.Script.Util;
using System.Collections.Generic;
using UnityEngine;

public class WireService : MonoBehaviour
{
    private const float DistanceHitCollider = 2f;
    private SpriteRenderer _sprite;
    public WireModel type;

    private void Start()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void SpriteColor(bool active)
    {
        if (_sprite != null)
            _sprite.color = active ? new Color(0, 1, 0, .200f) : new Color(1, 0, 0, .200f);
    }

    public WireService Next(List<string> last)
    {
        var wires = Utilities.GetItemsFromRayCast<WireService>(transform, DistanceHitCollider);
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