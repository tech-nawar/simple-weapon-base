﻿using System.Linq;
using Deathmatch.Hud;
using Sandbox;
using SWB_Base;

public partial class ExamplePlayer : PlayerBase
{
    public bool SupressPickupNotices { get; set; }
    TimeSince timeSinceDropped;

    public ClothingContainer Clothing = new();

    public ExamplePlayer() : base()
    {
        Inventory = new ExampleInventory(this);
    }

    public ExamplePlayer(IClient client) : this()
    {
        // Load clothing from client data
        Clothing.LoadFromClient(client);
    }

    public override void Respawn()
    {
        base.Respawn();

        SetModel("models/citizen/citizen.vmdl");
        Clothing.DressEntity(this);

        Controller = new PlayerWalkController();
        Animator = new PlayerBaseAnimator();
        CameraMode = new FirstPersonCamera();

        EnableAllCollisions = true;
        EnableDrawing = true;
        EnableHideInFirstPerson = true;
        EnableShadowInFirstPerson = true;

        Health = 100;

        ClearAmmo();

        // Give weapons and ammo
        SupressPickupNotices = true;

        Inventory.Add(new SWB_WEAPONS.Bayonet());
        Inventory.Add(new SWB_WEAPONS.DEAGLE());
        Inventory.Add(new SWB_WEAPONS.SPAS12());
        Inventory.Add(new SWB_WEAPONS.UMP45());
        Inventory.Add(new SWB_WEAPONS.FAL());
        Inventory.Add(new SWB_WEAPONS.L96A1());

        Inventory.Add(new SWB_EXPLOSIVES.RPG7());

        GiveAmmo(AmmoTypes.SMG, 100);
        GiveAmmo(AmmoTypes.Pistol, 60);
        GiveAmmo(AmmoTypes.Revolver, 60);
        GiveAmmo(AmmoTypes.Rifle, 60);
        GiveAmmo(AmmoTypes.Shotgun, 60);
        GiveAmmo(AmmoTypes.Sniper, 60);
        GiveAmmo(AmmoTypes.Grenade, 60);
        GiveAmmo(AmmoTypes.RPG, 60);

        SupressPickupNotices = false;
    }

    public override void Simulate(IClient cl)
    {
        base.Simulate(cl);

        if (LifeState != LifeState.Alive)
        {
            if (CameraMode is not DeathCamera)
            {
                CameraMode = new DeathCamera();
            }

            return;
        }

        TickPlayerUse();

        if (Input.Pressed(InputButton.View))
        {
            if (CameraMode is ThirdPersonCamera)
            {
                CameraMode = new FirstPersonCamera();
            }
            else
            {
                CameraMode = new ThirdPersonCamera();
            }
        }

        if (Input.Pressed(InputButton.Drop))
        {
            var dropped = Inventory.DropActive();
            if (dropped != null)
            {
                if (dropped.PhysicsGroup != null)
                {
                    dropped.PhysicsGroup.Velocity = Velocity + (this.EyeRotation.Forward + this.EyeRotation.Up) * 300;
                }

                timeSinceDropped = 0;
                SwitchToBestWeapon();
            }
        }

        SimulateActiveChild(cl, ActiveChild);

        //
        // If the current weapon is out of ammo and we last fired it over half a second ago
        // lets try to switch to a better wepaon
        //
        if (ActiveChild is WeaponBase weapon && !weapon.IsUsable() && weapon.TimeSincePrimaryAttack > 0.5f && weapon.TimeSinceSecondaryAttack > 0.5f)
        {
            SwitchToBestWeapon();
        }
    }

    public override void StartTouch(Entity other)
    {
        if (timeSinceDropped < 1) return;

        base.StartTouch(other);
    }

    public override void OnKilled()
    {
        base.OnKilled();

        var attacker = LastAttacker as PlayerBase;

        if (attacker != null && LastDamage.Weapon is WeaponBase weapon && GameManager.Current is ExampleGame game)
        {
            game.UI.AddKillfeedEntry(To.Everyone, attacker.Client.SteamId, attacker.Client.Name, Client.SteamId, Client.Name, weapon.Icon);
        }

        if (ActiveChild is WeaponBase activeWep && activeWep.DropWeaponOnDeath)
            Inventory.DropActive();

        Inventory.DeleteContents();

        BecomeRagdollOnClient(LastDamage.Force, LastDamage.BoneIndex);

        Controller = null;
        //CameraMode = new SpectateRagdollCamera();

        EnableAllCollisions = false;
        EnableDrawing = false;
    }

    public void SwitchToBestWeapon()
    {
        var best = Children.Select(x => x as WeaponBase)
            .Where(x => x.IsValid() && x.IsUsable())
            .OrderByDescending(x => x.BucketWeight)
            .FirstOrDefault();

        if (best == null) return;

        ActiveChild = best;
    }

    public override void TakeDamage(DamageInfo info)
    {
        base.TakeDamage(info);

        if (info.Attacker is PlayerBase attacker && attacker != this)
        {
            TookDamage(To.Single(this), info.Weapon.IsValid() ? info.Weapon.Position : info.Attacker.Position);
        }
    }

    [ClientRpc]
    public virtual void TookDamage(Vector3 pos)
    {
        DamageIndicator.Current?.OnHit(pos);
    }
}
