using UnityEngine;
using Google.XR.ARCoreExtensions;
using UnityEngine.XR.ARSubsystems;

public class Location : MonoBehaviour
{
    public AREarthManager earthManager;

    [Header("Anchor 1")]
    public string anchor1Name = "Anchor 1";
    public double anchor1Latitude = -33.499725;
    public double anchor1Longitude = -70.611554;
    public double anchor1Altitude = 621.0;

    [Header("Anchor 2")]
    public string anchor2Name = "Anchor 2";
    public double anchor2Latitude = -33.499780;
    public double anchor2Longitude = -70.611857;
    public double anchor2Altitude = 621.0;

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 28;
        style.normal.textColor = Color.white;

        int x = 20;
        int y = 20;
        int line = 48;

        if (earthManager == null)
        {
            GUI.Label(new Rect(x, y, 1600, line), "Earth Manager: NULL", style);
            return;
        }

        if (earthManager.EarthTrackingState != TrackingState.Tracking)
        {
            GUI.Label(new Rect(x, y, 1600, line),
                "Earth: " + earthManager.EarthTrackingState, style);
            return;
        }

        GeospatialPose pose = earthManager.CameraGeospatialPose;
        float heading = pose.EunRotation.eulerAngles.y;

        DrawLine(ref y, x, line, "Earth: Tracking | HAcc: " + pose.HorizontalAccuracy.ToString("F2") + " m", style);
        DrawLine(ref y, x, line, "Tu ubicacion: " + pose.Latitude.ToString("F6") + ", " + pose.Longitude.ToString("F6"), style);
        DrawLine(ref y, x, line, "Altitud actual: " + pose.Altitude.ToString("F2") + " m", style);
        DrawLine(ref y, x, line, "Heading: " + heading.ToString("F1") + " grados", style);

        y += 12;

        DrawAnchorInfo(ref y, x, line, style, pose, heading, anchor1Name, anchor1Latitude, anchor1Longitude, anchor1Altitude);
        y += 12;
        DrawAnchorInfo(ref y, x, line, style, pose, heading, anchor2Name, anchor2Latitude, anchor2Longitude, anchor2Altitude);
    }

    void DrawAnchorInfo(
        ref int y,
        int x,
        int line,
        GUIStyle style,
        GeospatialPose pose,
        float heading,
        string name,
        double lat,
        double lon,
        double alt)
    {
        double distance = DistanceMeters(pose.Latitude, pose.Longitude, lat, lon);
        double bearing = BearingDegrees(pose.Latitude, pose.Longitude, lat, lon);
        double relativeBearing = NormalizeAngle(bearing - heading);

        double altitudeDiff = pose.Altitude - alt;
        string verticalText = VerticalText(altitudeDiff);

        DrawLine(ref y, x, line, name + ": " + distance.ToString("F1") + " m | " + DirectionText(relativeBearing), style);
        DrawLine(ref y, x, line, "Altura vs " + name + ": " + verticalText + " (" + altitudeDiff.ToString("F1") + " m)", style);

        if (distance < 5)
        {
            DrawLine(ref y, x, line, "ESTAS SOBRE " + name, style);
        }
    }

    void DrawLine(ref int y, int x, int line, string text, GUIStyle style)
    {
        GUI.Label(new Rect(x, y, 1700, line), text, style);
        y += line;
    }

    string VerticalText(double altitudeDiff)
    {
        if (altitudeDiff > 2.0) return "ESTAS ARRIBA";
        if (altitudeDiff < -2.0) return "ESTAS ABAJO";
        return "ALTURA SIMILAR";
    }

    double DistanceMeters(double lat1, double lon1, double lat2, double lon2)
    {
        double R = 6371000.0;
        double dLat = Deg2Rad(lat2 - lat1);
        double dLon = Deg2Rad(lon2 - lon1);

        double a =
            Mathf.Sin((float)dLat / 2f) * Mathf.Sin((float)dLat / 2f) +
            Mathf.Cos((float)Deg2Rad(lat1)) *
            Mathf.Cos((float)Deg2Rad(lat2)) *
            Mathf.Sin((float)dLon / 2f) *
            Mathf.Sin((float)dLon / 2f);

        double c = 2.0 * Mathf.Atan2(
            Mathf.Sqrt((float)a),
            Mathf.Sqrt((float)(1.0 - a))
        );

        return R * c;
    }

    double BearingDegrees(double lat1, double lon1, double lat2, double lon2)
    {
        double phi1 = Deg2Rad(lat1);
        double phi2 = Deg2Rad(lat2);
        double dLon = Deg2Rad(lon2 - lon1);

        double y = Mathf.Sin((float)dLon) * Mathf.Cos((float)phi2);

        double x =
            Mathf.Cos((float)phi1) * Mathf.Sin((float)phi2) -
            Mathf.Sin((float)phi1) *
            Mathf.Cos((float)phi2) *
            Mathf.Cos((float)dLon);

        return NormalizeAngle(Rad2Deg(Mathf.Atan2((float)y, (float)x)));
    }

    double NormalizeAngle(double angle)
    {
        angle %= 360.0;
        if (angle < 0) angle += 360.0;
        return angle;
    }

    string DirectionText(double relativeBearing)
    {
        if (relativeBearing < 20 || relativeBearing > 340) return "AL FRENTE";
        if (relativeBearing >= 20 && relativeBearing < 70) return "ADELANTE DERECHA";
        if (relativeBearing >= 70 && relativeBearing < 110) return "DERECHA";
        if (relativeBearing >= 110 && relativeBearing < 160) return "ATRAS DERECHA";
        if (relativeBearing >= 160 && relativeBearing < 200) return "ATRAS";
        if (relativeBearing >= 200 && relativeBearing < 250) return "ATRAS IZQUIERDA";
        if (relativeBearing >= 250 && relativeBearing < 290) return "IZQUIERDA";
        return "ADELANTE IZQUIERDA";
    }

    double Deg2Rad(double degrees) => degrees * Mathf.PI / 180.0;
    double Rad2Deg(double radians) => radians * 180.0 / Mathf.PI;
}