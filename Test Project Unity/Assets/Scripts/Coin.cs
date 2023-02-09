using UnityEngine;

namespace Coin
{
    
    public class Coin : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            FindObjectOfType<CoinEffect>().PlayAudio();
            gameObject.SetActive(false);
        }
    }
}


