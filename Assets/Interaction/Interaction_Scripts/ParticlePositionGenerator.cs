using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ParticlePositionGenerator : MonoBehaviour
{
    public Texture2D sourceImage;
    public GameObject particlePrefab;
    public float spacing = 0.1f;
    public float particleSize = 0.05f;
    public float idleAmplitude = 0.03f;

    [Header("Bloom Control")]
    public Volume globalVolume;
    [Range(0f, 100f)]
    public float bloomIntensity = 20f;

    [Header("Interaction Camera")]
    public Camera interactionCamera; // Assign your particle camera here

    void Start()
    {
        ApplyBloomIntensity();
        GenerateParticles();
    }

    void ApplyBloomIntensity()
    {
        if (globalVolume != null && globalVolume.profile.TryGet<Bloom>(out var bloom))
        {
            bloom.intensity.value = bloomIntensity;
        }
        else
        {
            Debug.LogWarning("Bloom override not found on the assigned Volume.");
        }
    }

    void GenerateParticles()
    {
        for (int x = 0; x < sourceImage.width; x++)
        {
            for (int y = 0; y < sourceImage.height; y++)
            {
                Color pixel = sourceImage.GetPixel(x, y);
                if (pixel.grayscale < 0.95f)
                {
                    Vector3 pos = new Vector3(
                        (x - sourceImage.width / 2f) * spacing,
                        (y - sourceImage.height / 2f) * spacing,
                        0
                    );

                    GameObject p = Instantiate(particlePrefab, pos, Quaternion.identity, transform);
                    p.transform.localScale = Vector3.one * particleSize;

                    var pb = p.AddComponent<ParticleBehavior>();
                    pb.SetOriginal(pos);
                    pb.idleAmplitude = idleAmplitude;
                    pb.interactionCamera = interactionCamera; // assign correct camera
                }
            }
        }
    }
}
