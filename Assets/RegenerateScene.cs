using UnityEngine;
using UnityEngine.SceneManagement;

public class RegenerateScene : MonoBehaviour
{
    public GameObject sunPrefab;
    public GameObject[] planetPrefabs;
    public float[] distances;
    public GameObject blackHolePrefab;

    public void Start()
    {
        GameObject solarSystem = new GameObject("Solar System");

        GameObject sun = Instantiate(sunPrefab, Vector3.zero, Quaternion.identity);
        Vector3 sunScale = Vector3.one * Random.Range(20f, 30f);
        sun.transform.localScale = sunScale;
        sun.transform.parent = solarSystem.transform;

        float lastPlanetRadius = sun.transform.localScale.x / 2f;

        for (int i = 0; i < planetPrefabs.Length; i++)
        {
            float angle = Random.Range(0f, 360f);
            float minDistance = lastPlanetRadius + (planetPrefabs[i].transform.localScale.x / 2f) + 1f;
            distances[i] = Mathf.Max(distances[i], minDistance);

            Vector3 position = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * distances[i];
            GameObject planet = Instantiate(planetPrefabs[i], position, Quaternion.identity);

            Vector3 planetScale = Vector3.one * Random.Range(1f, 10f);
            planet.transform.localScale = planetScale;

            planet.transform.parent = solarSystem.transform;

            RotateAround rotateAround = planet.AddComponent<RotateAround>();
            rotateAround.target = sun;
            rotateAround.speed = Random.Range(0f, 5f);

            planet.AddComponent<SelfRotate>();

            lastPlanetRadius = planet.transform.localScale.x / 2f;
        }

        Vector3 blackHolePosition = Random.onUnitSphere * 100f;
        GameObject blackHole = Instantiate(blackHolePrefab, blackHolePosition, Quaternion.identity);

        blackHole.transform.parent = solarSystem.transform;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
