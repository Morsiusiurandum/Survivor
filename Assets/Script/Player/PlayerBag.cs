using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBag : MonoBehaviour
{
    public ArrayList BagList = new ArrayList();
    internal Text item_name;
    void Start()
    {
        item_name = GameObject.Find("UI/Main UI/Text").GetComponent<Text>();
    }
    void Update()
    {
        Click(PublicVariables.ray,Input.GetKeyUp(KeyCode.Mouse1));

        ShowBag(Input.GetKey(KeyCode.B));
    }
    void Click(Ray ray,bool click_button)
    { 
        if (!click_button) return;
        bool isCollider = Physics.Raycast(ray, out RaycastHit hit, 10, 1 << 8);
        if (!isCollider) return;

        if (!BagList.Contains(hit.collider.gameObject.name))
        {
            BagList.Add(hit.collider.gameObject.name);
            Debug.Log(hit.collider.gameObject.name);
        }    
    }
    void ShowBag(bool press_key)
    {
        if (press_key)
        {
            item_name.text = BagList[0].ToString();
        }
        else
        {
            item_name.text = null;
        }
    }
}
struct item
     {
        string name;
        int num;
    };