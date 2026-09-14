using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class XPButtonFill : MonoBehaviour, IPointerClickHandler
{
    public Image fillImage;
    public int xpRequired = 50;
    public AbilityType ability;
    public float shakeIntensity = 10f;
    public float shakeDuration = 0.2f;
    private RectTransform rect;
    private Vector2 originalPos;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        originalPos = rect.anchoredPosition;
    }

    private void Update()
    {
        float xp = XPManager.Instance.xp;

        float targetFill = Mathf.Clamp01(xp / xpRequired);
        fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, targetFill, Time.deltaTime * 8f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (XPManager.Instance.xp >= xpRequired)
        {
            TriggerAbility();
        }
        else
        {
            StartCoroutine(ShakeButton());
        }
    }

    IEnumerator ShakeButton()
    {
        float timer = 0f;

        while (timer < shakeDuration)
        {
            timer += Time.deltaTime;
            float strength = Mathf.Sin(timer * 50f) * shakeIntensity;
            rect.anchoredPosition = originalPos + new Vector2(strength, 0);
            yield return null;
        }

        rect.anchoredPosition = originalPos;
    }

    private void TriggerAbility()
    {
        switch (ability)
        {
            case AbilityType.Grenade:
                SuperAttaque.Instance.UseGrenade();
                break;

            case AbilityType.Sweep:
                SuperAttaque.Instance.UseSweep();
                break;

            case AbilityType.Laser:
                SuperAttaque.Instance.UseLaser();
                break;
        }
    }
}

public enum AbilityType
{
    Grenade,
    Sweep,
    Laser
}