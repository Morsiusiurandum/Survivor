using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{

    void Update()
    {
        Click(PublicVariables.ray, Input.GetKeyUp(KeyCode.Mouse2));
    }

    void Click(Ray ray, bool click_button)
    {
        if (!click_button) return;
        bool isCollider = Physics.Raycast(ray, out RaycastHit hit, 10, 1 << 8);
        if (!isCollider) return;

       /* if (!BagList.Contains(hit.collider.gameObject.name))
        {
            BagList.Add(hit.collider.gameObject.name);
            Debug.Log(hit.collider.gameObject.name);
        }*/
    }
}
