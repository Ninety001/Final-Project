using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HighScoreManager.Instance.AddCoin(); // ��������­ + �Ѿ UI
            Destroy(gameObject); // ���������­�������
        }
    }
}