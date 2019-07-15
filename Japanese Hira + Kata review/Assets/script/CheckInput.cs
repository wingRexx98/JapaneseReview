using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckInput : MonoBehaviour
{
    private string[] character = { "あ" , "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と", "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", "む", "め", "も", "や", "ゆ", "よ", "ら", "り", "る", "れ", "ろ", "わ", "を", "ん" };
    private string[] cha = { "a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko", "sa", "shi", "su", "se", "so", "ta", "chi", "tsu", "te", "to", "na", "ni", "nu", "ne", "no", "ha", "hi", "fu", "he", "ho", "ma", "mi", "mu", "me", "mo", "ya", "yu", "yo", "ra", "ri", "ru", "re", "ro", "wa", "wo", "n" };
    public Text randomText;
    public Text rightText;
    public Text time;

    public InputField text;
    public GameObject correct;
    public GameObject incorrect;
    public GameObject timeUp;
    public GameObject note;

    public float timer = 2f;
    private float timeCounter;

    private string correctText;
    // Start is called before the first frame update
    void Start()
    {
        RandomWord(character);
        timeCounter = timer;
    }

    private void Update()
    {
        if(timeCounter > 0)
        {
            timeCounter -= Time.deltaTime;
            time.text = timeCounter.ToString("f");
        }
        else if(timeCounter <= 0)
        {
            timeUp.SetActive(true);
            rightText.text = correctText;
            time.text = "0";
            timeCounter = 0f;
        }
    }

    public void CheckUserInput()
    {
        /*long way
         * //a
        if (randomText.text == "あ")
        {
            if (text.text == "a" || text.text == "A") correct.SetActive(true);
            else incorrect.SetActive(true);
        }*/
        //fast way
        if (timeCounter > 0)
        {
            if (text.text == correctText)
            {
                correct.SetActive(true);
            }
            else if(text.text == "")
            {
                note.SetActive(true);
                time.text = "0";
                timeCounter = 0f;
            }
            else
            {
                incorrect.SetActive(true);
                rightText.text = correctText;
            }
        }

        Invoke("NextWord", 0.6f);
    }

    void RandomWord(string[] word)
    {
        int textNumber = Random.Range(0, word.Length);
        randomText.text = word[textNumber];
        correctText = cha[textNumber];
    }

    void NextWord()
    {
        RandomWord(character);
        text.text = "";
        rightText.text = "";
        timeCounter = timer;
        correct.SetActive(false);
        incorrect.SetActive(false);
        timeUp.SetActive(false);
        note.SetActive(false);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
