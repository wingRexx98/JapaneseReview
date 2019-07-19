using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KatakanaCheck : MonoBehaviour
{
    private string[] character = { "ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ", "コ", "サ", "シ", "ス", "セ", "ソ", "タ", "チ", "ツ", "テ", "ト", "ナ", "ニ", "ヌ", "ネ", "ノ", "ハ", "ヒ", "フ", "へ", "ホ", "マ", "ミ", "ム", "メ", "モ", "ヤ", "ユ", "ヨ", "ラ", "リ", "ル", "レ", "ロ", "ワ", "ヲ", "ン" };
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
    void Start()
    {
        RandomWord(character);
        timeCounter = timer;
    }

    private void Update()
    {
        if (timeCounter > 0)
        {
            timeCounter -= Time.deltaTime;
            time.text = timeCounter.ToString("f");
        }
        else if (timeCounter <= 0)
        {
            timeUp.SetActive(true);
            rightText.text = correctText;
            time.text = "0";
            timeCounter = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckUserInput();
        }
    }

    public void CheckUserInput()
    {
        if (timeCounter > 0)
        {
            if (text.text == correctText)
            {
                correct.SetActive(true);
            }
            else if (text.text == "")
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
