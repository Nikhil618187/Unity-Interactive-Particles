using UnityEngine;

public class ParticleBehavior : MonoBehaviour
{
    private Vector3 originalPos;
    private Vector3 velocity;

    [Header("Repel Settings")]
    public float repelRadius = 8f;
    public float repelStrength = 20f;

    [Header("Idle Movement")]
    public float idleAmplitude = 0.03f;
    public float returnSpeed = 2f;
    public float damping = 0.9f;

    [HideInInspector] public Camera interactionCamera;

    public void SetOriginal(Vector3 originalPos)
    {
        this.originalPos = originalPos;
    }

    void Update()
    {
        if (interactionCamera == null) return;

        Vector3 mouse = interactionCamera.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;

        float dist = Vector3.Distance(mouse, transform.position);

        if (dist < repelRadius)
        {
            Vector3 dir = (transform.position - mouse).normalized;
            velocity += dir * (repelStrength / dist) * Time.deltaTime;
        }
        else
        {
            Vector3 returnDir = originalPos - transform.position;
            velocity += returnDir * returnSpeed * Time.deltaTime;
        }

        // Idle motion
        velocity += new Vector3(
            Mathf.PerlinNoise(Time.time + originalPos.x, 0f) - 0.5f,
            Mathf.PerlinNoise(0f, Time.time + originalPos.y) - 0.5f,
            0f
        ) * idleAmplitude;

        transform.position += velocity * Time.deltaTime;
        velocity *= damping;
    }
}
