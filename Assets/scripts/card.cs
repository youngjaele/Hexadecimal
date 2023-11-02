using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openCard()
    {
        bool isOpen = true;

        anim.SetBool("isOpen", true);
        if (isOpen == true)
        {
            Invoke("openDelay", 0.2f);
        }
        transform.Find("back").gameObject.SetActive(false);
    }
    public void openDelay()
    {
        transform.Find("front").gameObject.SetActive(true);
    }
}
