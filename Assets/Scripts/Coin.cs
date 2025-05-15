using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HighScoreManager.Instance.AddCoin(); // เพิ่มเหรียญ + อัพ UI
            Destroy(gameObject); // ทำลายเหรียญเมื่อเก็บ
        }
    }
}