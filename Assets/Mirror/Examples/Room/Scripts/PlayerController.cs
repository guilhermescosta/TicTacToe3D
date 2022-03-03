using UnityEngine;
using System;
using Unity;
using UnityEngine.UI;

namespace Mirror.Examples.NetworkRoom
{
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(NetworkTransform))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField] Transform playerCamera = null;
        public float mouseSensitivity = 3.5f;
        [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
        float cameraPitch = 0.0f;
        Vector2 currentMouseDelta = Vector2.zero;
        Vector2 currentMouseDeltaVelocity = Vector2.zero;

        public GameObject _controller;
        



        public CharacterController characterController;

        public bool _inObject;
        public GameObject rayObject;
        public float rayMaxDistance = 10;

      //  public NetworkRoomManager _roomManager;

        public Material circleMaterial;
        public Material crossMaterial;

      //  public GameController _gameController;

        public NetworkIdentity _netId;  //identificador do player na rede
        
        [SyncVar]
        public uint myPlayer;  //player 1 ou 2

        public GameObject crosshair;
        public GameObject ball;

        private void Start()
        {
            myPlayer = netId;
            playerCamera = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
           // _controller = GameObject.Find("GameControl");

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;

            //   _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

            if (this.CompareTag("Player") && GameObject.Find("Jogador 1")==null)
            {
                gameObject.name = "Jogador 1";
            }
            else if (this.CompareTag("Player") && GameObject.Find("Jogador 1")) 
            {
                gameObject.name = "Jogador 2";
            } 



        }

        void OnValidate()
        {
            if (characterController == null)
                characterController = GetComponent<CharacterController>();

            characterController.enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<NetworkTransform>().clientAuthority = true;
        }

        public override void OnStartLocalPlayer()
        {
            characterController.enabled = true;
        }

        [Header("Movement Settings")]
        public float moveSpeed = 8f;
        public float turnSensitivity = 5f;
        public float maxTurnSpeed = 100f;

        

        [Header("Diagnostics")]
        public float horizontal;
        public float vertical;
        public float turn;
        public float jumpSpeed;
        public bool isGrounded = true;
        public bool isFalling;
        public Vector3 velocity;

        void UpdateMouseLook()
        {
            Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

            cameraPitch -= currentMouseDelta.y * mouseSensitivity;
            cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

            playerCamera.localEulerAngles = Vector3.right * cameraPitch;
            transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
        }



        void PlayerVision()
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 2))
            {

                if (hit.collider.CompareTag("Ball") && rayObject == null)
                {
                    // ball = hit.collider.gameObject;
                    rayObject = hit.collider.gameObject;
                    _inObject = true;

                }
                if (hit.collider.tag != "Ball")
                {
                    rayObject = null;
                    _inObject = false;
                }



                if (_inObject && hit.collider.CompareTag("Ball"))
                {
                    crosshair.GetComponent<Image>().color = Color.red;
                }
                else
                {
                    crosshair.GetComponent<Image>().color = Color.white;
                }

                if (Input.GetMouseButtonDown(0) && _inObject == true)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        hit.rigidbody.AddForce(400 * transform.forward);
                        _inObject = false;
                    }
                }

                /*
                                 if (Physics.Raycast(ray, out hit, rayMaxDistance))
                             {
                                 Debug.DrawLine(ray.origin, hit.point);
                                 if (hit.collider.CompareTag("Grid") && rayObject == null)
                                 {
                                     rayObject = hit.collider.gameObject;
                                     hit.collider.GetComponent<MeshRenderer>().material.color = Color.blue;
                                     _inObject = true;
                                 }

                                 if (hit.collider.tag != "Grid")
                                 {
                                     if (rayObject)
                                     {
                                         rayObject.GetComponent<MeshRenderer>().material.color = Color.white;
                                     }
                                     rayObject = null;
                                     _inObject = false;
                                 }



                                 if (Input.GetMouseButtonDown(0) && _inObject == true)
                                 {
                                     if (Input.GetMouseButtonDown(0))
                                     {
                                         hit.collider.tag = "UsedGrid";
                                         _inObject = false;


                                         if (myPlayer == 1)
                                         {

                                              hit.collider.GetComponent<Renderer>().material = circleMaterial;
                                             //_gameController.gridArray[Convert.ToInt32(hit.collider.name)] = 1;
                                             //_gameController.ChangePlayer();
                                         }
                                         else if (myPlayer == 2)
                                         {

                                             hit.collider.GetComponent<Renderer>().material = crossMaterial;
                                             //_gameController.gridArray[Convert.ToInt32(hit.collider.name)] = 1;
                                             //_gameController.ChangePlayer();
                                         }
                                     }
                                 }
              }
              */

            }
        }
       
        void ChangeGrid(GameObject grid)
        {
            //NetworkServer.Destroy(grid);
            grid.GetComponent<Renderer>().material = circleMaterial;
        }



        void Update()
        {

            PlayerVision();
           
            UpdateMouseLook();

            if (!isLocalPlayer || characterController == null || !characterController.enabled)
                return;

            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            if (isGrounded)
                isFalling = false;

            if ((isGrounded || !isFalling) && jumpSpeed < 1f && Input.GetKey(KeyCode.Space))
            {
                jumpSpeed = Mathf.Lerp(jumpSpeed, 1f, 0.5f);
            }
            else if (!isGrounded)
            {
                isFalling = true;
                jumpSpeed = 0;
            }

        }

        void FixedUpdate()
        {
            if (!isLocalPlayer || characterController == null || !characterController.enabled)
                return;

            transform.Rotate(0f, turn * Time.fixedDeltaTime, 0f);

            Vector3 direction = new Vector3(horizontal, jumpSpeed, vertical);
            direction = Vector3.ClampMagnitude(direction, 1f);
            direction = transform.TransformDirection(direction);
            direction *= moveSpeed;

            if (jumpSpeed > 0)
                characterController.Move(direction * Time.fixedDeltaTime);
            else
                characterController.SimpleMove(direction);

            isGrounded = characterController.isGrounded;
            velocity = characterController.velocity;
        }

       
    }
}
