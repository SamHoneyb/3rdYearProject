using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

[Serializable]
public class Scenarios
{
    public int ScenarioID;
    public string Scenario;
    public string Answer;
    public string Incorrect1;
    public string Incorrect2;
    public string Incorrect3;
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
    public int money;

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
        var currentScenario = allScenarios[sceneIndex];
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
        answerCheck(answer1Txt.text);
    }
    public void Button2Pressed()
    {
        answerCheck(answer2Txt.text);
    }
    public void Button3Pressed()
    {
        answerCheck(answer3Txt.text);
    }
    public void Button4Pressed()
    {
        answerCheck(answer4Txt.text);
    }

    public void answerCheck(string selectedAnswer)
    {
        if (selectedAnswer == correctAnswer) {
            Debug.Log("correct");
            money += 100;
            sceneIndex++;
            if (sceneIndex > allScenarios.Count)
            {
                Debug.Log("thats all the questions");
                sceneIndex = 0;
            }
            LoadScenrario();
        }
        else
        {
            Debug.Log("incorrect");
            sceneIndex++;
            if (sceneIndex > allScenarios.Count)
            {
                SceneManager.LoadSceneAsync("Game");
            }
            LoadScenrario();
        }
    }


};
