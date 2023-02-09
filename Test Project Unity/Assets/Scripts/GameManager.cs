using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI MessageText;
    public Coin.CoinManager[] Coins;
    public Coin.CoinManager[] RedCoins;
    public GameObject Coin;
    public GameObject RedCoin;
    public TextMeshProUGUI NumOfCoins;

    private WaitForSeconds EndWait;
    private WaitForSeconds StartWait;

    public float EndDelay = 5f;
    public float StartDelay = 1f;

    bool isAllRedCollected;

    private void Start()
    {
        StartWait = new WaitForSeconds(StartDelay);
        EndWait = new WaitForSeconds(EndDelay);

        SpawnCoins();
        StartCoroutine(GameLoop()); 
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());

        yield return StartCoroutine(RoundEnding());
        
        StartCoroutine(GameLoop());

    }
    private IEnumerator RoundStarting()
    {
        isAllRedCollected = false;
        Respawn();
        yield return null;
    }
    
    private IEnumerator RoundPlaying()
    {     
        while (!NoOneCoinLeft())
        {
            yield return null;
        }
    }


    private IEnumerator RoundEnding()
    {
        NumOfCoins.text = string.Empty;
        if (GetResults())
        {
            MessageText.text = "Вы выиграли";
            yield return EndWait;
        }
        else
        {
            yield return StartWait;
        }
    }

        public bool NoOneCoinLeft()
    {
        int numCoinsLeft = 0;
        int numRedCoinsLeft = 0;
        int numCoinsCollected = 0;
        for (int i = 0; i < Coins.Length; i++)
        {
            if (Coins[i].m_Instance.activeSelf)
            {
                numCoinsLeft++;

            }
            else
            {
                numCoinsCollected++;
                
                NumOfCoins.text = numCoinsCollected.ToString();
            }
        }
        for (int i = 0; i < RedCoins.Length; i++)
        {
            if (RedCoins[i].m_Instance.activeSelf)
            {
                numRedCoinsLeft++;
            }
        }
        return numCoinsLeft <= 0 || numRedCoinsLeft <= 0;
    }

    private bool GetResults()
    {
        for (int i = 0; i < RedCoins.Length; i++)
        {
            if (RedCoins[i].m_Instance.activeSelf)
            {
                isAllRedCollected = true;
            }
        }
        return isAllRedCollected;
    }


        private void SpawnCoins()
    {
        for (int i = 0; i < Coins.Length; i++)
        {
            Coins[i].m_Instance = Instantiate(Coin, Coins[i].m_SpawnPoint.position, Coins[i].m_SpawnPoint.rotation) as GameObject;
        }
        for (int i = 0; i < RedCoins.Length; i++)
        {
            RedCoins[i].m_Instance = Instantiate(RedCoin, RedCoins[i].m_SpawnPoint.position, RedCoins[i].m_SpawnPoint.rotation) as GameObject;
        }
    }


    public void Respawn()
    {
        for (int i = 0; i < Coins.Length; i++)
        {
            Coins[i].Reset();
        }
        for (int i = 0; i < RedCoins.Length; i++)
        {
            RedCoins[i].Reset();
        }
        MessageText.text = string.Empty;
        NumOfCoins.text = "0";
    }
}


