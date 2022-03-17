using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    
    float time;
    bool finished;
    [SerializeField] TextMeshProUGUI coinstextRef;
    [SerializeField] TextMeshProUGUI timerUIRef;
    [SerializeField] GameObject timeOverText;

    [HideInInspector] public int coins; 
    
    

    public IEnumerator Timer(float timeInput) //timer counts down from a set time from each task. It is public so it can be started and stopped from other scripts.
    {
        time = timeInput;
        while (time > 0)
        {
            time -= Time.deltaTime;
            timerUIRef.text = Mathf.Round(time).ToString();
            yield return new WaitForEndOfFrame();
        }

        yield return null;
        timeOverText.SetActive(true);
    }

    public void AddCoins(int additionalCoins)
    {
        coins += additionalCoins;
        coinstextRef.text = "Coins: " + coins;
    }


 
}
