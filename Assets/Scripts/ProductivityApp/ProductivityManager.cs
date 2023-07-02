using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ProductivityApp
{
    public class ProductivityManager : MonoBehaviour
    {
        public delegate void ActivateInputField(bool Activate);
        public static event ActivateInputField ActivateInputFieldEvent;

        public delegate void ProductivityAppActive();
        public static event ProductivityAppActive ProductivityAppActiveEvent;

        Ray ray;
        RaycastHit hitData;

        [SerializeField] TMP_InputField taskDesc;
        [SerializeField] Slider timeSlider;

        // TODO: this flag needs to be delt with before it gets ugly ngl
        private bool _ProductivityAppActive = false; // Bad practice.. oops too bad :P

        public static ProductivityManager Instance;

        void Awake()
        {
            if(Instance)
                Destroy(this);
            else
                Instance = this;
        }

        void Update()
        {
            if(_ProductivityAppActive)
                ProductivityAppActiveEvent?.Invoke();
                
            if (Physics.Raycast(PlayerMovement.Instance.playerCamera.ScreenPointToRay(Input.mousePosition), out hitData, 1000) && hitData.transform.tag == "ProductivityApp")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitData.distance, Color.yellow);
                if(Input.GetMouseButtonDown(0))
                {
                    ActivateInputFieldEvent?.Invoke(true);
                    _ProductivityAppActive = true;
                    SetPlayerInteractionMode(false);
                }

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    ActivateInputFieldEvent?.Invoke(false);
                    _ProductivityAppActive = false;
                    SetPlayerInteractionMode(true);
                }
            }
        }

        public static void SetPlayerInteractionMode(bool state)
        {
            PlayerMovement.Instance.canMove = state;
            Cursor.lockState = !state ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = !state;
        }

        public void ExitButton()
        {
            ActivateInputFieldEvent?.Invoke(false);
             _ProductivityAppActive = false;
            SetPlayerInteractionMode(true);
        }
    }
}