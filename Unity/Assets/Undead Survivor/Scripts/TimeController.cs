using UnityEngine;

public class TimeController
{
    private static bool _isRun = true;
    public static void StopTime() {
        Time.timeScale = 0;
    }

    public static void RestartTime() {
        Time.timeScale = 1;
    }

    public static void Switch() {
        if(_isRun)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        _isRun = !_isRun;
    }
}
