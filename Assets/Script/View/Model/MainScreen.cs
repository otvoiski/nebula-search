using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.View.Model
{
    public class MainScreen : MonoBehaviour
    {
        public Transform BottomBar { get; set; }
        public Transform Toast { get; set; }
        public InterfaceMenu InterfaceMenu { get; set; }
        public BuildScreen BuildScreen { get; set; }
    }
}