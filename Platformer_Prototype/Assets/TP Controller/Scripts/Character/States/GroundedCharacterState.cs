using UnityEngine;
using System.Collections;

/// <summary>
/// The character is on the ground
/// </summary>
public class GroundedCharacterState : CharacterStateBase
{
    int delay=0;
    public override void Update(Character character)
    {

        if (delay <= 0)
        {
            delay = 0;
        }
        else
        {
            delay--;
        }
        //Debug.Log(delay);


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
            Debug.Log("jump");
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
                    if (delay <= 0)
                    {
                        

                        if (hitchecker.transform.GetComponent<buttonCaller>().stopped == true)
                        {

                            if (hitchecker.transform.GetComponent<buttonCaller>().GoTo == 0)
                            {
                                hitchecker.transform.GetComponent<buttonCaller>().GoTo = 1;
                            }
                            else
                            {
                                hitchecker.transform.GetComponent<buttonCaller>().GoTo = 0;
                            }
                            Debug.Log("ho");
                            //hitchecker.transform.GetComponent<buttonCaller>().wait();
                            hitchecker.transform.GetComponent<buttonCaller>().stopped = false;
                           
                            delay = 300;
                        }
                        if (character.IsGrounded == true)
                        {
                            if (character.partent == false)
                            {
                                character.partent = true;

                                character.transform.parent = hitchecker.transform;
                            }
                        }
                        Debug.Log(delay);
                    }
                    break;

                case "Eplatform":


                    if (delay <= 0)
                    {
                        if (hitchecker.transform.GetComponent<buttonCaller>().stopped == true)
                        {

                            if (hitchecker.transform.GetComponent<buttonCaller>().Forward == true)
                            {
                                hitchecker.transform.GetComponent<buttonCaller>().GoTo = hitchecker.transform.GetComponent<buttonCaller>().GoTo + 1;
                            }
                            else
                            {
                                hitchecker.transform.GetComponent<buttonCaller>().GoTo = hitchecker.transform.GetComponent<buttonCaller>().GoTo - 1;
                            }

                            if (hitchecker.transform.GetComponent<buttonCaller>().GoTo == hitchecker.transform.GetComponent<buttonCaller>().place.Length - 1)
                            {
                                hitchecker.transform.GetComponent<buttonCaller>().Forward = false;
                                delay = 300;
                            }
                            if (hitchecker.transform.GetComponent<buttonCaller>().GoTo == 0)
                            {
                                hitchecker.transform.GetComponent<buttonCaller>().Forward = true;
                                delay = 300;
                            }
                            //if (true)
                            //{
                            //    
                            // hitchecker.transform.GetComponent<buttonCaller>().GoTo = 0;
                            //hitchecker.transform.GetComponent<buttonCaller>().GoTo = hitchecker.transform.GetComponent<buttonCaller>().GoTo + 1;
                            //}
                            //else
                            //{
                            //    hitchecker.transform.GetComponent<buttonCaller>().GoTo = hitchecker.transform.GetComponent<buttonCaller>().GoTo-1;
                            //}

                        }

                        Debug.Log(hitchecker.transform.GetComponent<buttonCaller>().place.Length);
                        //hitchecker.transform.GetComponent<buttonCaller>().wait();
                        hitchecker.transform.GetComponent<buttonCaller>().stopped = false;
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
                default:
                    this.ToState(character, CharacterStateBase.IN_AIR_STATE);
                    break;
            }
            
        }
    }
}
