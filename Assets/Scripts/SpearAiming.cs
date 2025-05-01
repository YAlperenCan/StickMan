using UnityEngine;

public class SpearAiming : MonoBehaviour
{
    [Header("Dönüş Açısı Sınırları")]
    public float minAngle = -40f; // En fazla aşağı bakabileceği açı
    public float maxAngle = 80f;  // En fazla yukarı kaldırabileceği açı

    [Header("Yumuşak Dönüş Ayarı")]
    public float rotationSpeed = 8f; // Dönüşün ne kadar hızlı olacağı

    [Header("Y Ekseninde Hassasiyet")]
    public float maxVerticalRange = 1f; // Mouse ile mızrak arasındaki fark en fazla bu kadar etkilesin

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // 1️⃣ Mouse pozisyonunu dünya koordinatlarında al
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // 2️⃣ Mızrak ile mouse arasındaki Y farkını bul
        float verticalDiff = transform.position.y - mousePos.y;

        // 3️⃣ Bu farkı -1 ile 1 arasına sıkıştır (normalize et)
        float t = Mathf.Clamp(verticalDiff / maxVerticalRange, -1f, 1f);

        // 4️⃣ -1 -> minAngle, 0 -> orta, 1 -> maxAngle olacak şekilde hedef açı belirle
        float targetAngle = Mathf.Lerp(minAngle, maxAngle, (t + 1f) / 2f);

        // 5️⃣ Hedef açıyı daha yumuşak yapmak için LerpAngle kullan
        float smoothAngle = Mathf.LerpAngle(rb.rotation, targetAngle, rotationSpeed * Time.fixedDeltaTime);

        // 6️⃣ Rigidbody'yi döndür
        rb.MoveRotation(smoothAngle);
    }
}
