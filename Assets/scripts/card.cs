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
        else
        {
            transform.Find("back").gameObject.SetActive(false);
        }
        
        if(gameManager.I.firstCard == null)
        {
            gameManager.I.firstCard = gameObject;
        }
        else
        {
            gameManager.I.secondCard = gameObject;
            gameManager.I.ismatched();
        }
    }

    public void openDelay()
    {
        transform.Find("front").gameObject.SetActive(true);
    }

    public void destroyCard()
    {
        Invoke("destoryCardInvoke", 1.3f);
    }
    void destoryCardInvoke()
    {
        Destroy(gameObject);
    }
    public void closeCard()
    {
        Invoke("closeCardInvoke", 1.5f);
    }

    void closeCardInvoke()
    {
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
    }
}
