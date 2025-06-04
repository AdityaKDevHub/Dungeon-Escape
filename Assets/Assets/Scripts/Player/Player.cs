using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable
{
    public int diamonds;
    public bool FireDagger = false;

    public bool hasKey = false;

    AudioManager audioManager;
    
	private Rigidbody2D _rigid;
	[SerializeField] //Mutable Property --> [SerializeField]
	public float JumpForce = 7.0f;
	[SerializeField]
	private bool _grounded = false;
	[SerializeField]
	private LayerMask _groundLayer;
	private bool resetJumpNeeded = false;
	[SerializeField]
	private float _speed = 2.5f;

    private PlayerAnimation _Playeranim;
    private SpriteRenderer _Playersprite;
    private SpriteRenderer _swordArcSprite;
    private SpriteRenderer _PlayerHitBox;

    public int Health { get; set; }

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _Playeranim = GetComponent<PlayerAnimation>();
        _Playersprite = GetComponentInChildren<SpriteRenderer>();
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        _PlayerHitBox = _Playersprite.GetComponentInChildren<SpriteRenderer>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        float move = CrossPlatformInputManager.GetAxis("Horizontal"); //Initialise Motion Positions

        if (move > 0) { //Flip the sprite left.
            _Playersprite.flipX = false;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;
            _PlayerHitBox.flipX = false;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        } else if (move < 0) { //Flip the sprite right.
            _Playersprite.flipX = true;
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;
            _PlayerHitBox.flipX = true;

            Vector3 newPos = _swordArcSprite.transform.localPosition; //Shord Virtual Effect
            newPos.x = -1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        }

        if ((CrossPlatformInputManager.GetButtonDown("B_Button")) && _grounded == true) { //Jump Function
        	_rigid.velocity = new Vector2(_rigid.velocity.x, JumpForce);
        	_grounded = false;
        	resetJumpNeeded = true;
        	StartCoroutine(resetJumpNeededRoutine());

            _Playeranim.Jump(true);
            audioManager.PlaySFX(audioManager.PlayerJumpSFX);
        }

        //RayCasting for detection of floor.
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down * 1.2f, Color.green);

        if (hitInfo.collider != null) {
        	if (resetJumpNeeded == false) {
        		_grounded = true;
                _Playeranim.Jump(false);
        	}
        }

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y); //Motion 
        _Playeranim.Move(move);

        if ((CrossPlatformInputManager.GetButtonDown("A_Button")) && _grounded == true) { //Attack when on ground (Left Mouse Click)
            _Playeranim.Attack();
            audioManager.PlaySFX(audioManager.PlayerAttackSFX);
        }

        if (transform.position.x >= 118 && hasKey == true) {
            StartCoroutine(Victory());
        }

        if (FireDagger == true && ((CrossPlatformInputManager.GetButtonDown("A_Button")) && _grounded == true)) { //Fire Dagger Attack
            _Playeranim.FireAttack();
            audioManager.PlaySFX(audioManager.PlayerAttackFireSFX);
        }
    }

    IEnumerator resetJumpNeededRoutine() { //Jump Cooldown
    	yield return new WaitForSeconds(0.1f);
    	resetJumpNeeded = false;
    }

    public void Damage() { //Function if hit by an enemy. Taken from IDamageable Interface contract.
        Health -= 1;
        UIManager.Instance.UpdateLives(Health);
        audioManager.PlaySFX(audioManager.PlayerHitSFX);

        if (Health > 0) {
            _Playeranim.Hit();
        }

        if (Health < 1) {
            _Playeranim.Death();
            audioManager.PlaySFX(audioManager.PlayerDeathSFX);
            StartCoroutine(GameOver());
        }
    }

    public void AddGems(int amt) { //Display Gem Count
        diamonds += amt;
        UIManager.Instance.UpdateGemCount(diamonds);
    }

    IEnumerator GameOver() { //Death Screen Timer.
        yield return new WaitForSeconds(1.05f);
        SceneManager.LoadScene("Death");
    }

    public void Fire() { //Attack + Fire Dagger
        _Playeranim.FireAttack();
        FireDagger = true;
    }

    public void BoF() { //Boots of Flight function.
        JumpForce =11.0f;
    }

    IEnumerator Victory() { //Victory Screen Timer.
        yield return new WaitForSeconds(1.05f);
        SceneManager.LoadScene("Victory");
    }
}
