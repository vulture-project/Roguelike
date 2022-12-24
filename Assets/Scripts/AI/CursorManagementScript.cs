using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class CursorManagementScript : MonoBehaviour
    {
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
    }
}
