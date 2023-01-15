using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuButton : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent();
    public GameObject button; 
    public float buttonDepressDepth;
    private bool clickedButton = false;

    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; 
        if ( Input.GetMouseButtonDown(0) )
        {
            if ( Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject )
            {
                // button.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                Debug.Log("Clicked play button");
                button.transform.localScale -= new Vector3(0, 0, buttonDepressDepth);
                clickedButton = true;
            }
        }
        
        if (clickedButton && Input.GetMouseButtonUp(0)) {
            if ( Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject )
            {
                // button.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                Debug.Log("Released on play button");
                unityEvent.Invoke();
            }
            button.transform.localScale += new Vector3(0, 0, buttonDepressDepth);
            clickedButton = false;
        }
    }
}
