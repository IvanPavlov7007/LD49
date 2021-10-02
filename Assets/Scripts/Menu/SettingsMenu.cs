using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Toggle thisToggle, thatToggle;
    public Slider thoseSlider;

    private void Start()
    {
        thisToggle.isOn = IntersceneData._this;
        thatToggle.isOn = IntersceneData._that;
        thoseSlider.value = IntersceneData._those;
    }

    public void ToggleThis(bool val)
    {
        IntersceneData._this = val;
    }

    public void ToggleThat(bool val)
    {
        IntersceneData._that = val;
    }

    public void ChangeThose(float val)
    {
        IntersceneData._those = val;
    }
}
