using UnityEngine;
using System.Collections;

/// <summary>
/// The character is on the ground
/// </summary>
public class GroundedCharacterState : CharacterStateBase
{
    public override void Update(Character character)
    {
        base.Update(character);

        character.ApplyGravity(true); // Apply extra gravity

        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    character.partent = false;
        //}
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    character.transform.parent = null;
        //}

        if (PlayerInput.GetToggleWalkInput())
        {
            character.ToggleWalk();
        }

        character.IsSprinting = PlayerInput.GetSprintInput();

        if (PlayerInput.GetJumpInput())
        {
            
            character.Jump();
            this.ToState(character, CharacterStateBase.JUMPING_STATE);
          
            
        }

        else if (!character.IsGrounded)
        {
           
            character.partent = false;
            character.transform.parent = null;
            this.ToState(character, CharacterStateBase.IN_AIR_STATE);
          

        }
        //another gound check
        RaycastHit hitchecker;
        if (Physics.Raycast(character.transform.position + (Vector3.up * 0.15f), Vector3.down, out hitchecker))
        {
            switch (hitchecker.collider.gameObject.tag)
            { case "Fplatform":
                    //print("plsF");
                    if (hitchecker.collider.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.fallPlatform>().Falling == false)
                    {
                        hitchecker.collider.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.fallPlatform>().playerON();

                    }
                    if (character.IsGrounded == true)
                    {
                        if (character.partent == false)
                        {
                            character.partent = true;

                            character.transform.parent = hitchecker.transform;
                        }
                    }
                    break;
                case "Mplatform":
                    Debug.Log("hope");
                    

                    if (character.IsGrounded == true)
                    {
                        if (character.partent == false)
                        {
                            character.partent = true;
                            
                            character.transform.parent = hitchecker.transform;
                        }
                    }
                    
                    break;
                case "Splatform":
                
                    break;
                case "Lplatform":
                    break;
                //case "Death":
                    //character.transform.position = character.savehome;
                    //break;
                default:
                    this.ToState(character, CharacterStateBase.IN_AIR_STATE);
                    break;
            }
            
        }
    }
}
