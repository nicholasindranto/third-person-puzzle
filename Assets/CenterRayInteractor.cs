using UnityEngine;
using UnityEngine.UI;

namespace NavKeypad
{
    public class CenterRayInteractor : MonoBehaviour
    {
        [Header("References")]
        public Image crosshairImage;            // UI crosshair
        public Color defaultColor = Color.white;
        public Color enemyColor = Color.red;
        public Color friendlyColor = Color.green;

        [Header("Settings")]
        public float maxDistance = 10f;
        public LayerMask interactMask = ~0;     // Layer yang bisa di-raycast
        public float debugRaySeconds = 0f;      // biar kelihatan garis ray di scene

        [SerializeField] Camera cam;
        // reference ke spotlightnya
        public GameObject flashlight;
        // reference ke clue nya
        public GameObject clue;

        void Start()
        {
            cam = Camera.main; // Kamera utama yg render game
            if (cam == null)
                Debug.LogError("No Main Camera found! Tag your render camera as MainCamera.");
        }

        void Update()
        {
            DoRaycastFromCenter();
        }

        void DoRaycastFromCenter()
        {
            if (!cam) return;

            // Buat ray dari TENGAH layar
            Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            Ray ray = cam.ScreenPointToRay(screenCenter);

            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, interactMask, QueryTriggerInteraction.Ignore))
            {
                // Cek tag object (lebih aman dari pada cek nama)
                if (hit.transform.name == "Enemy")
                    SetCrosshair(enemyColor);
                else if (hit.transform.name == "Friendly")
                    SetCrosshair(friendlyColor);
                else
                    SetCrosshair(defaultColor);

                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow, debugRaySeconds);

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("ngehit 1 = " + hit.collider.name);
                    if (hit.collider.TryGetComponent(out KeypadButton keypadButton))
                    {
                        Debug.Log("ngehit 2 = " + hit.collider.name);
                        keypadButton.PressButton();
                    }

                    if (hit.collider.name == "Flashlight")
                    {
                        flashlight.SetActive(!flashlight.activeSelf);
                    }

                    if (hit.collider.name == "book")
                    {
                        clue.SetActive(!clue.activeSelf);
                    }
                }
            }
            else
            {
                SetCrosshair(defaultColor);
                Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.gray, debugRaySeconds);
            }
        }

        void SetCrosshair(Color c)
        {
            if (crosshairImage) crosshairImage.color = c;
        }
    }
}