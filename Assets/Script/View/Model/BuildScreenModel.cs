using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.View.Model
{
    public class BuildScreenModel : MonoBehaviour
    {
        public Transform BuildMenu { get; set; }
        public Transform BuildList { get; set; }
        public Transform InfoScreen { get; set; }
        public GameObject SelectedItem { get; set; }
    }
}