using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using JetBrains.Annotations;

public class gameManager : MonoBehaviour
{
    // 타이머, 텍스트
    public Text timeTxt;
    float time = 0.0f;
    float limit = 40f;
    public GameObject endTxt;
    public GameObject nameTxt;

    // 카드
    public GameObject card;
    public GameObject firstCard;
    public GameObject secondCard;

    // 소리
    public AudioSource matchSource;
    public AudioClip match;

    public static gameManager I;

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        int[] cardimage = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
        cardimage = cardimage.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 20; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;

            float x = (i / 5) * 1.1f - 1.66f;
            float y = (i % 5) * 1.5f - 3.5f;
            newCard.transform.position = new Vector3(x, y, 0);

            string iconName = "icon" + cardimage[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(iconName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        limit -= Time.deltaTime;
        if (limit <= 0)
        {
            Time.timeScale = 0f;
            endTxt.SetActive(true);
            limit = 0f;
        }
        else if (limit <= 10)
        {
            timeTxt.color = new Color(255f, 0f, 0f);
        }
        timeTxt.text = limit.ToString("N2");
    }
    public void ismatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            matchSource.PlayOneShot(match);

            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            nameTxt.SetActive(true);
            Text matchName = nameTxt.GetComponent<Text>();

            if (firstCardImage == "icon0" || firstCardImage == "cion0")
            {

                matchName.text = "크롬";
                Invoke("collname", 3f);
            }
            else if (firstCardImage == "icon1" || firstCardImage == "cion1")
            {
                matchName.text = "칠판";
                Invoke("collname", 3f);
            }
            else if (firstCardImage == "icon2" || firstCardImage == "cion2")
            {
                matchName.text = "파도";
                Invoke("collname", 3f);
            }
            else if (firstCardImage == "icon3" || firstCardImage == "cion3")
            {
                matchName.text = "LOL";
                Invoke("collname", 3f);
            }
            else if (firstCardImage == "icon4" || firstCardImage == "cion4")
            {
                matchName.text = "낙하";
                Invoke("collname", 3f);
            }
            else if (firstCardImage == "icon5" || firstCardImage == "cion5")
            {
                matchName.text = "맥주";
                Invoke("collname", 3f);
            }
            else if (firstCardImage == "icon6" || firstCardImage == "cion6")
            {
                matchName.text = "GIT";
                Invoke("collname", 3f);
            }
            else if (firstCardImage == "icon7" || firstCardImage == "cion7")
            {
                matchName.text = "여행";
                Invoke("collname", 3f);
            }
            else if (firstCardImage == "icon8" || firstCardImage == "cion8")
            {
                matchName.text = "스파르타";
                Invoke("collname", 3f);
            }
            else if (firstCardImage == "icon9" || firstCardImage == "cion9")
            {
                matchName.text = "Unity";
                Invoke("collname", 3f);
            }

            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                Invoke("EndTxtDleay", 1f);
            }
            matchName.color = new Color(0f, 0f, 0f);
        }
        else
        {
            nameTxt.SetActive(true);
            Text matchName = nameTxt.GetComponent<Text>();

            matchName.text = "틀렸다!";
            matchName.color = new Color(1f, 0f, 0f);

            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();

            Invoke("collname", 1.5f);

        }
        firstCard = null;
        secondCard = null;
    }
    void collname()
    {
        nameTxt.SetActive(false);
    }
    void EndTxtDleay()
    {
        endTxt.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
