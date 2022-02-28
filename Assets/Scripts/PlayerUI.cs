using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    // Start is called before the first frame update
    float time;
    bool finished;
    [SerializeField] TextMeshProUGUI coinstextRef;
    [SerializeField] TextMeshProUGUI timerUIRef;
    [SerializeField] GameObject timeOverText;

    [HideInInspector] public int coins;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public IEnumerator Timer(float timeInput) //timer counts down from a set time from each task.
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
