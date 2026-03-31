using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

[Serializable]
public class Scenarios
{
    public int ScenarioID;
    public string Scenario;
    public string Answer;
    public string Incorrect1;
    public string Incorrect2;
    public string Incorrect3;
    public string Reason;
    public string Summary;
}
[Serializable]
public class ScenarioWrapper
{
    public List<Scenarios> Scenarios;
}


public class ScenarioCall : MonoBehaviour
{
    public List<Scenarios> allScenarios = new List<Scenarios>();
    public TMP_Text questionpnlTxt;
    public TMP_Text answer1Txt;
    public TMP_Text answer2Txt;
    public TMP_Text answer3Txt;
    public TMP_Text answer4Txt;
    public GameObject Answer1Btn;
    public GameObject Answer2Btn;
    public GameObject Answer3Btn;
    public GameObject Answer4Btn;
    public int money;

    public Scenarios currentScenario;

    public int sceneIndex = 0;
    public string correctAnswer;



    private string scenarioAPI = "http://127.0.0.1:5000/Scenarios";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GetScenarios());
    }

    public IEnumerator GetScenarios()
    {
        UnityWebRequest www = UnityWebRequest.Get(scenarioAPI);

        yield return www.SendWebRequest();


        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string response = www.downloadHandler.text;
            Debug.Log(response);
            string fixedResponse = "{\"Scenarios\":" + response + "}";

            ScenarioWrapper wrapper = JsonUtility.FromJson<ScenarioWrapper>(fixedResponse);
            allScenarios = wrapper.Scenarios;

            LoadScenrario();
        }
    }

    public void LoadScenrario() {
        currentScenario = allScenarios[sceneIndex];
        correctAnswer = currentScenario.Answer;

        List<String> randomiseButtons = new List<String>() {
            currentScenario.Answer,
            currentScenario.Incorrect1,
            currentScenario.Incorrect2,
            currentScenario.Incorrect3,
        };

        System.Random rnd = new System.Random();

        for (int i = 0; i < randomiseButtons.Count; i++)
        {
            int random = rnd.Next(i, randomiseButtons.Count);

            string temp = randomiseButtons[i];
            randomiseButtons[i] = randomiseButtons[random];
            randomiseButtons[random] = temp;

            questionpnlTxt.text = currentScenario.Scenario;
            answer1Txt.text = randomiseButtons[0];
            answer2Txt.text = randomiseButtons[1];
            answer3Txt.text = randomiseButtons[2];
            answer4Txt.text = randomiseButtons[3];
        }

    }

    public void Button1Pressed()
    {
        StartCoroutine(answerCheck(answer1Txt.text));
    }
    public void Button2Pressed()
    {
        StartCoroutine(answerCheck(answer2Txt.text));
    }
    public void Button3Pressed()
    {
        StartCoroutine(answerCheck(answer3Txt.text));
    }
    public void Button4Pressed()
    {
        StartCoroutine(answerCheck(answer4Txt.text));
    }

    IEnumerator answerCheck(string selectedAnswer)
    {
        if (selectedAnswer == correctAnswer) {
            Debug.Log("correct");
            questionpnlTxt.text = currentScenario.Reason;
            questionpnlTxt.color = Color.green;
            LeaveCorrectButton();
            yield return new WaitForSeconds(6f);
            ReturnCorrectButton();
            questionpnlTxt.color = Color.white;
            money += 100;
            sceneIndex++;
            if (sceneIndex >= allScenarios.Count)
            {
                Debug.Log("thats all the questions");
                sceneIndex = 0;
                SceneManager.LoadSceneAsync("Shop");
            }
            LoadScenrario();
        }
        else
        {
            Debug.Log("incorrect");
            questionpnlTxt.text = currentScenario.Reason;
            questionpnlTxt.color = Color.red;
            LeaveCorrectButton();
            yield return new WaitForSeconds(6f);
            ReturnCorrectButton();
            questionpnlTxt.color = Color.white;
            sceneIndex++;
            if (sceneIndex >= allScenarios.Count)
            {
                SceneManager.LoadSceneAsync("Shop");
            }
            LoadScenrario();
        }
    }

    private void LeaveCorrectButton()
    {
        if(answer1Txt.text != correctAnswer)
        { 
            Answer1Btn.SetActive(false);
        }
        else
        {
            answer1Txt.color = Color.green;
        }

        if (answer2Txt.text != correctAnswer)
        {
            Answer2Btn.SetActive(false);
        }
        else
        {
            answer2Txt.color = Color.green;
        }

        if (answer3Txt.text != correctAnswer)
        {
            Answer3Btn.SetActive(false);
        }
        else
        {
            answer3Txt.color = Color.green;
        }

        if (answer4Txt.text != correctAnswer)
        {
            Answer4Btn.SetActive(false);
        }
        else
        {
            answer4Txt.color = Color.green;
        }
    }

    private void ReturnCorrectButton()
    {
        if (answer1Txt.text != correctAnswer)
        {
            Answer1Btn.SetActive(true);
        }
        else
        {
            answer1Txt.color = Color.white;
        }

        if (answer2Txt.text != correctAnswer)
        {
            Answer2Btn.SetActive(true);
        }
        else
        {
            answer2Txt.color = Color.white;
        }

        if (answer3Txt.text != correctAnswer)
        {
            Answer3Btn.SetActive(true);
        }
        else
        {
            answer3Txt.color = Color.white;
        }

        if (answer4Txt.text != correctAnswer)
        {
            Answer4Btn.SetActive(true);
        }
        else
        {
            answer4Txt.color = Color.white;
        }
    }



    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


};
