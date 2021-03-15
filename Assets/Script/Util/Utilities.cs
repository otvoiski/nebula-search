using Assets.Script.Enumerator;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Util
{
    public class Utilities : MonoBehaviour
    {
        public static Vector3 GetPositionGridFromScreenPoint(int height)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 15f))
            {
                return new Vector3(
                    Mathf.CeilToInt(hit.point.x) - 0.5f,
                    height,
                    Mathf.CeilToInt(hit.point.z) - 0.5f);
            }
            else
            {
                return Vector3.zero;
            }
        }

        public static RaycastHit? GetRaycastHitFromScreenPoint(bool debug = false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 10f))
            {
                if (debug)
                    Debug.DrawRay(hit.point, Input.mousePosition, Color.red);

                return hit;
            }
            else
            {
                return null;
            }
        }

        public static int GetTransferenceRateFromTier(Tier tier)
        {
            switch (tier)
            {
                case Tier.Low:
                    return 12;

                case Tier.Normal:
                    return 12 * 2;

                case Tier.Hight:
                    return 12 * 3;

                case Tier.Ultra:
                    return 12 * 4;

                default:
                    return 0;
            }
        }

        public static List<Vector3> GetWindRoseDirection()
        {
            #region Position Raycast Start

            /*
                  +z

                 x x x
            -x   x x x   +x
                 x x x

                  -z
             */

            return new List<Vector3>
            {
                // North
                new Vector3(0, 0, +1),

                // North East
                new Vector3(+1,0,+1),

                // East
                new Vector3(+1,0,0),

                // South East
                new Vector3(+1,0,-1),

                // South
                new Vector3(0,0,-1),

                // South West
                new Vector3(-1,0,-1),

                // West
                new Vector3(-1,0,0),

                // North West
                new Vector3(-1,0,+1)
            };

            #endregion Position Raycast Start
        }

        public static List<Vector3> GetCrossDirection()
        {
            #region Position Raycast Start

            /*
                  +z

                   x
            -x   x x x   +x
                   x

                  -z
             */

            return new List<Vector3>
            {
                // North
                new Vector3(0, 0, +1),

                // East
                new Vector3(+1 , 0, 0),

                // South
                new Vector3(0, 0, -1),

                // West
                new Vector3(-1, 0, 0),
            };

            #endregion Position Raycast Start
        }

        public static List<T> GetItemsFromRayCast<T>(Transform transform, float distance = 1)
        {
            var list = new List<T>();

            foreach (var coord in GetCrossDirection())
            {
                if (Physics.Raycast(new Vector3(transform.position.x, 0.5f, transform.position.z), coord, out RaycastHit hit, distance))
                {
                    Debug.DrawRay(transform.position, coord, Color.white, distance);

                    var t = hit.transform.GetComponent<T>();
                    if (t != null)
                        list.Add(t);
                }
            }

            return list;
        }

        [Obsolete]
        public static List<T> GetListItemFromRayCast<T>(Transform transform, float distance = 1)
        {
            var hit = Physics.OverlapSphere(transform.position, distance);

            var itens = new List<T>();
            for (var i = 0; i < hit.Length; i++)
            {
                Debug.DrawRay(transform.position, transform.position, Color.white, distance);

                var item = hit[i].gameObject.GetComponent<T>();
                if (item != null)
                    itens.Add(item);
            }

            return itens;
        }
    }
}