using System.Collections.Generic;
using UnityEngine;

namespace Assets.Data.Util
{
    public class Utilities : MonoBehaviour
    {
        public static Vector3 GetMousePositionToVector3(LayerMask mask, bool debug = false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, mask))
            {
                if (debug)
                    GameObject.Find("MousePointerInWorld").transform.position = hit.point;

                return hit.point;
            }
            else
            {
                return Vector3.zero;
            }
        }

        public static Vector3 GetMousePositionToVector3Grid(float height, LayerMask mask, bool debug = false)
        {
            var v3 = GetMousePositionToVector3(mask, debug);

            return new Vector3(
                Mathf.CeilToInt(v3.x - .5f),
                height,
                Mathf.CeilToInt(v3.z - .5f));
        }

        public static Vector3 GetMousePositionInGridPosition(float height, bool debug = false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue))
            {
                if (debug)
                    GameObject.Find("MousePointerInWorld").transform.position = hit.point;

                return new Vector3(
                    Mathf.CeilToInt(hit.point.x - .5f),
                    height,
                    Mathf.CeilToInt(hit.point.z - .5f));
            }
            else
            {
                return Vector3.zero;
            }
        }

        public static RaycastHit? GetMousePositionInRaycastHit(bool debug = false)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue))
            {
                if (debug)
                    GameObject.Find("MousePointerInWorld").transform.position = hit.point;

                return hit;
            }
            else
            {
                return null;
            }
        }

        private static List<Vector3> GetWindRoseDirection()
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

        public static List<T> GetItemsFromRayCast<T>(Transform transform, float distance = 1)
        {
            var list = new List<T>();

            foreach (var coord in GetCrossDirection())
            {
                if (Physics.Raycast(new Vector3(transform.position.x, 1, transform.position.z), coord, out RaycastHit hit, distance))
                {
                    Debug.DrawRay(transform.position, coord, Color.white, distance);

#pragma warning disable UNT0014 // Invalid type for call to GetComponent
                    var t = hit.transform.GetComponent<T>();
#pragma warning restore UNT0014 // Invalid type for call to GetComponent
                    if (t != null)
                        list.Add(t);
                }
            }

            return list;
        }

        private static List<Vector3> GetCrossDirection()
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
    }
}