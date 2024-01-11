using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompanyA : MonoBehaviour
{

    public int stockPrice;

    private int updateTime = 10;
    private int diceRoll;
    private float timeCounter = 0.0f;

    [SerializeField] private TextMeshProUGUI textDisplay;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Company A started");
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter > 10f)
        {
            Debug.Log("Update Started");
            StartCoroutine(UpdatePrice());
            timeCounter = 0.0f;
        }
    }

    private IEnumerator UpdatePrice()
    {
        yield return new WaitForSeconds(updateTime);
        diceRoll = Random.Range(0, 100);
        Debug.Log(diceRoll);
        if(diceRoll >= 50)
        {
            IncreasePrice();
        }
        if(diceRoll < 50)
        {
            DecreasePrice();
        }
        
    }

    private void IncreasePrice()
    {
        stockPrice += Random.Range(20, 50);
        Debug.Log(stockPrice);
        textDisplay.text = "$" + stockPrice.ToString();
    }

    private void DecreasePrice()
    {
        stockPrice -= Random.Range(20, 50);
        Debug.Log(stockPrice);
        textDisplay.text = "$" + stockPrice.ToString();
    }
}
