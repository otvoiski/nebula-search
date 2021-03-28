using Assets.Script.Util;
using System.Collections.Generic;
using UnityEngine;

public class GasService : MonoBehaviour
{
    private const float DISTANCE_HIT_COLLIDER = 1.0f;
    private SpriteRenderer sprite;
    public GasModel type;

    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void SpriteColor(bool active)
    {
        sprite.color = active ? new Color(0, 1, 0, .200f) : new Color(1, 0, 0, .200f);
    }

    public GasService Next(List<string> last)
    {
        var gases = Utilities.GetItemsFromRayCast<GasService>(transform, DISTANCE_HIT_COLLIDER);
        foreach (var gas in gases)
        {
            if (last.Contains(gas.name)) continue;
            else
            {
                last.Add(gas.name);
                return gas;
            }
        }

        return null;
    }
}