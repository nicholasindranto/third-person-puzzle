using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NavKeypad
{
    public class SlidingDoor : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        public bool IsOpoen => isOpen;
        private bool isOpen = false;
        public GameObject gamewinui;

        private void Start() {
            gamewinui.SetActive(false);
        }

        public void ToggleDoor()
        {
            isOpen = !isOpen;
            anim.SetBool("isOpen", isOpen);
        }

        public void OpenDoor()
        {
            isOpen = true;
            anim.SetBool("isOpen", isOpen);
            gamewinui.SetActive(true);
        }
        public void CloseDoor()
        {
            isOpen = false;
            anim.SetBool("isOpen", isOpen);
        }
    }
}