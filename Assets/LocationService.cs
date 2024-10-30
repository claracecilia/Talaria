using UnityEngine;
using System.Collections;

public class LocationService : MonoBehaviour
{
    public Vector2 currentGPSPosition;

    void Start()
    {
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        // Check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Location services not enabled by user");
            yield break;
        }

        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access the location and store it in currentGPSPosition
            currentGPSPosition = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
            Debug.Log("Current Location: " + currentGPSPosition);
        }
    }

    public Vector2 GetCurrentGPSLocation()
    {
        return currentGPSPosition;
    }
}

