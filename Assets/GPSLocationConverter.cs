using UnityEngine;

public class GPSLocationConverter : MonoBehaviour
{
    // Reference Point GPS (Latitude, Longitude) Årsta for now: https://gps-coordinates.org/coordinate-converter.php
    public float referenceLatitude = 59.298249999999996f;
    public float referenceLongitude = 18.038f;

    // Earth’s radius in meters
    private const float EarthRadius = 6378137f;

    // Method to convert a GPS coordinate to Unity world position
    public Vector3 ConvertGPStoUnityPosition(float targetLatitude, float targetLongitude)
    {
        // Convert latitude and longitude from degrees to radians
        float latRefRad = referenceLatitude * Mathf.Deg2Rad;
        float lonRefRad = referenceLongitude * Mathf.Deg2Rad;
        float latTargetRad = targetLatitude * Mathf.Deg2Rad;
        float lonTargetRad = targetLongitude * Mathf.Deg2Rad;

        // Calculate differences in meters
        float dLatitude = (latTargetRad - latRefRad) * EarthRadius;
        float dLongitude = (lonTargetRad - lonRefRad) * EarthRadius * Mathf.Cos(latRefRad);

        // Return the calculated position (y = 0 for flat ground)
        return new Vector3(dLongitude, 0, dLatitude);
    }
}
