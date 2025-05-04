using UnityEngine;

public class SpearTip : MonoBehaviour
{
    public GameObject playerBody;
    public GameObject playerLLeg;
    public GameObject playerLLLeg;
    public GameObject playerRLeg;
    public GameObject playerRLLeg;
    private float trigNumArm = 0;
    private float trigNumBody = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        trigNumArm = trigNumArm + 1;
        //Debug.Log(trigNumArm);
        if (trigNumArm > 14) { 
        if (collision.CompareTag("Arm"))
        {
            HingeJoint2D joint = collision.GetComponent<HingeJoint2D>();
            if (joint != null)
            {
                Destroy(joint);
                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.gravityScale = 1f;
                    rb.constraints = RigidbodyConstraints2D.None;
                    Vector2 forceDir = new Vector2(Random.Range(-1f, 1f), 1f).normalized;
                    rb.AddForce(forceDir * 300f);
                }
               
            }
        }
        }

        if (collision.CompareTag("Head") || collision.CompareTag("Body") || collision.CompareTag("Leg"))
        {
            HingeJoint2D joint = collision.GetComponent<HingeJoint2D>();
            trigNumBody = trigNumBody + 1;
            //Debug.Log(trigNumBody);
            if (trigNumBody > 7)

            {
                if (joint != null)
                {
                    Destroy(joint);
                    Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        rb.gravityScale = 1f;
                        rb.constraints = RigidbodyConstraints2D.None;
                        Vector2 forceDir = new Vector2(Random.Range(-1f, 1f), 1f).normalized;
                        rb.AddForce(forceDir * 300f);
                    }

                }
            
            Balance balanceScript = playerBody.GetComponent<Balance>();
            if (balanceScript != null)
            {
                balanceScript.enabled = false;
            }
            Balance balanceScriptRLeg = playerRLeg.GetComponent<Balance>();
            if (balanceScriptRLeg != null)
            {
                balanceScriptRLeg.enabled = false;
            }
            Balance balanceScriptLLeg = playerLLeg.GetComponent<Balance>();
            if (balanceScriptLLeg != null)
            {
                balanceScriptLLeg.enabled = false;
            }
            Balance balanceScriptLLLeg = playerLLLeg.GetComponent<Balance>();
            if (balanceScriptLLLeg != null)
            {
                balanceScriptLLLeg.enabled = false;
            }
            Balance balanceScriptRLLeg = playerRLLeg.GetComponent<Balance>();
            if (balanceScriptRLLeg != null)
            {
                balanceScriptRLLeg.enabled = false;
            }
            }
        }
    }

}
