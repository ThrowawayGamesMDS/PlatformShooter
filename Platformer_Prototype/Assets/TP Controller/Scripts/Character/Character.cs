﻿using UnityEngine;

public class Character : MonoBehaviour
{
    // Serialized fields
    [SerializeField] private new Camera camera = null;

    [SerializeField] private MovementSettings movementSettings = null;

    [SerializeField] private GravitySettings gravitySettings = null;

    [SerializeField]
    [HideInInspector]
    private RotationSettings rotationSettings = null;

    // Private fields
    private Vector3 moveVector;
    private Quaternion controlRotation;
    private CharacterController controller;
    private bool isWalking;
    private bool isJogging;
    private bool isSprinting;
    private float maxHorizontalSpeed; // In meters/second
    private float targetHorizontalSpeed; // In meters/second
    private float currentHorizontalSpeed; // In meters/second
    private float currentVerticalSpeed; // In meters/second
    public float mass = 3.0f;
    public Vector3 impact = Vector3.forward;
    public int ExtraJump;
    public int maxJump;
    public bool partent = false;
    public Vector3 savehome;
    public Animator anim;
    public static bool m_bPlayerShooting; // for disabling player rotational updates and random shit
    #region Unity Methods

    protected virtual void Awake()
    {
        this.controller = this.GetComponent<CharacterController>();

        this.CurrentState = CharacterStateBase.GROUNDED_STATE;
       
        this.IsJogging = true;
        

        maxJump = ExtraJump;
    }

    protected virtual void Update()
    {
        this.CurrentState.Update(this);

        this.UpdateHorizontalSpeed();
        this.ApplyMotion();
        if (impact.magnitude > 0.2) controller.Move(impact * Time.deltaTime);
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }

    #endregion Unity Methods

    public ICharacterState CurrentState { get; set; }

    void Start()
    {
        m_bPlayerShooting = false;
    }

    public Vector3 MoveVector
    {
        get
        {
            return this.moveVector;
        }
        set
        {
            float moveSpeed = value.magnitude * this.maxHorizontalSpeed;
            if (moveSpeed < Mathf.Epsilon)
            {
                this.targetHorizontalSpeed = 0f;
                return;
            }
            else if (moveSpeed > 0.01f && moveSpeed <= this.MovementSettings.WalkSpeed)
            {
                this.targetHorizontalSpeed = this.MovementSettings.WalkSpeed;
            }
            else if (moveSpeed > this.MovementSettings.WalkSpeed && moveSpeed <= this.MovementSettings.JogSpeed)
            {
                this.targetHorizontalSpeed = this.MovementSettings.JogSpeed;
            }
            else if (moveSpeed > this.MovementSettings.JogSpeed)
            {
                this.targetHorizontalSpeed = this.MovementSettings.SprintSpeed;
            }

            this.moveVector = value;
            if (moveSpeed > 0.01f)
            {
                this.moveVector.Normalize();
            }
        }
    }

    public Camera Camera
    {
        get
        {
            return this.camera;
        }
    }

    public CharacterController Controller
    {
        get
        {
            return this.controller;
        }
    }

    public MovementSettings MovementSettings
    {
        get
        {
            return this.movementSettings;
        }
        set
        {
            this.movementSettings = value;
        }
    }

    public GravitySettings GravitySettings
    {
        get
        {
            return this.gravitySettings;
        }
        set
        {
            this.gravitySettings = value;
        }
    }

    public RotationSettings RotationSettings
    {
        get
        {
            return this.rotationSettings;
        }
        set
        {
            this.rotationSettings = value;
        }
    }

    public Quaternion ControlRotation
    {
        get
        {
            return this.controlRotation;
        }
        set
        {
            this.controlRotation = value;
           // if (!m_bPlayerShooting)
           // {
                this.AlignRotationWithControlRotationY();
          //  }
        }
    }

    public bool IsWalking
    {
        get
        {
            return this.isWalking;
        }
        set
        {
            this.isWalking = value;
            if (this.isWalking)
            {
                this.maxHorizontalSpeed = this.MovementSettings.WalkSpeed;
                this.IsJogging = false;
                this.IsSprinting = false;
            }
        }
    }

    public bool IsJogging
    {
        get
        {
            return this.isJogging;
        }
        set
        {
            this.isJogging = value;
            if (this.isJogging)
            {
                this.maxHorizontalSpeed = this.MovementSettings.JogSpeed;
                this.IsWalking = false;
                this.IsSprinting = false;
            }
        }
    }

    public bool IsSprinting
    {
        get
        {
            return this.isSprinting;
        }
        set
        {
            this.isSprinting = value;
            if (this.isSprinting)
            {
                this.maxHorizontalSpeed = this.MovementSettings.SprintSpeed;
                this.IsWalking = false;
                this.IsJogging = false;
            }
            else
            {
                if (!(this.IsWalking || this.IsJogging))
                {
                    this.IsJogging = true;
                }
            }
        }
    }

    public bool IsGrounded
    {
        get
        {
            return this.controller.isGrounded;
        }
    }

    public Vector3 Velocity
    {
        get
        {
            return this.controller.velocity;
        }
    }

    public Vector3 HorizontalVelocity
    {
        get
        {
            return new Vector3(this.Velocity.x, 0f, this.Velocity.z);
        }
    }

    public Vector3 VerticalVelocity
    {
        get
        {
            return new Vector3(0f, this.Velocity.y, 0f);
        }
    }

    public float HorizontalSpeed
    {
        get
        {
            return new Vector3(this.Velocity.x, 0f, this.Velocity.z).magnitude;
        }
    }

    public float VerticalSpeed
    {
        get
        {
            return this.Velocity.y;
        }
    }


    public void AddImpact(Vector3 dir, float pushForce)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; 
        impact += dir.normalized * pushForce / mass;
    }


    public void Jump()
    {
        this.currentVerticalSpeed = this.MovementSettings.JumpForce;
        if(this.currentHorizontalSpeed > 0.1)
        {
            anim.Play("hipjump");
        }
        else
        {
            anim.Play("jumpdefault");
        }
        
    }
    public void DoubleJump()
    {
        this.currentVerticalSpeed = this.MovementSettings.DoublejumpForce;
    }
    public void ToggleWalk()
    {
        this.IsWalking = !this.IsWalking;

        if (!(this.IsWalking || this.IsJogging))
        {
            this.IsJogging = true;
        }
    }

    public void ApplyGravity(bool isGrounded = false)
    {
        if (!isGrounded)
        {
            this.currentVerticalSpeed =
                MathfExtensions.ApplyGravity(this.VerticalSpeed, this.GravitySettings.GravityStrength, this.GravitySettings.MaxFallSpeed);
        }
        else
        {
            this.currentVerticalSpeed = -this.GravitySettings.GroundedGravityForce;
        }
    }

    public void ResetVerticalSpeed()
    {
        this.currentVerticalSpeed = 0f;
    }

    private void UpdateHorizontalSpeed()
    {
        float deltaSpeed = Mathf.Abs(this.currentHorizontalSpeed - this.targetHorizontalSpeed);
        if (deltaSpeed < 0.1f)
        {
            this.currentHorizontalSpeed = this.targetHorizontalSpeed;
            return;
        }

        bool shouldAccelerate = (this.currentHorizontalSpeed < this.targetHorizontalSpeed);

        this.currentHorizontalSpeed +=
            this.MovementSettings.Acceleration * Mathf.Sign(this.targetHorizontalSpeed - this.currentHorizontalSpeed) * Time.deltaTime;

        if (shouldAccelerate)
        {
            this.currentHorizontalSpeed = Mathf.Min(this.currentHorizontalSpeed, this.targetHorizontalSpeed);
        }
        else
        {
            this.currentHorizontalSpeed = Mathf.Max(this.currentHorizontalSpeed, this.targetHorizontalSpeed);
        }
    }

    private void ApplyMotion()
    {
       // if (!m_bPlayerShooting)
            this.OrientRotationToMoveVector(this.MoveVector);
       // else
      //  {
        //    this.OrientRotationToMoveVector(this.MoveVector);
      //  }

        Vector3 motion = this.MoveVector * this.currentHorizontalSpeed + Vector3.up * this.currentVerticalSpeed;
        this.controller.Move(motion * Time.deltaTime);
    }

    private bool AlignRotationWithControlRotationY()
    {
        if (this.RotationSettings.UseControlRotation)
         {
             this.transform.rotation = Quaternion.Euler(0f, this.ControlRotation.eulerAngles.y, 0f);
             return true;
         }
         

        return false;
    }

    private bool OrientRotationToMoveVector(Vector3 moveVector)
    {
         if (this.RotationSettings.OrientRotationToMovement && moveVector.magnitude > 0f)
         {
             Quaternion rotation = Quaternion.LookRotation(moveVector, Vector3.up);
             if (this.RotationSettings.RotationSmoothing > 0f)
             {
                 gameObject.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, this.RotationSettings.RotationSmoothing * Time.deltaTime);
             }
             else
             {
                 gameObject.transform.rotation = rotation;
             }

             return true;
         }
         

        return false;
    }
}
