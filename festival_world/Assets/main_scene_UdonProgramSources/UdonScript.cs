
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

namespace childofthebeast.tutorial
{
    public class UdonScript : UdonSharpBehaviour
    {
        public GameObject GameObjectVar;
        public int intVar;
        public float floatVar;
        public bool boolVar;

        private Text TextVar;
        private InputField InputFieldVar;

        public GameObject Cube;
        private bool CubeActive;

        public override void Interact()
        {
            CubeActive = Cube.activeSelf;   // return true if cube is active

            // Cube.SetActive(!Cube.activeSelf);

            if (CubeActive == true)
            {
                Cube.SetActive(false);
            }
            else
            {
                Cube.SetActive(true);
            }
        }
    }

}
