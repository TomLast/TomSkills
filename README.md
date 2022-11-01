# TomSkills
Skillsystem like in LoL or Guild Wars 2


README.txt

ScriptableObject based Ability System:

Relevant Classes:

1. StatType(ScriptableObject)
	- A Stat for a champion, e.g. Attack Damage
	- Subclasses: DamgageStat, ResistenceStat --> categorise Stats
	- used as a ScriptableObject enumh, no data

2. Effect(ScriptableObject)
	- base class for all Effects
	- declares Use Method
	- Change Value of a given StatType
	- SubClasses: DamageEffect, BuffEffect --> what Stattype and how it will be altered

3. Skill(ScriptableObject)
	- base class for all Skills
	- fields for Cooldown, Casttime and Icon(for UI)
	- SubClasses: PointAndClickSkill, MouseDirectionSkill, ProjectileSkill --> Define Skill Logic and Data


Skill Template Usage:
  - Create new Skill with context menu in Asset folder (choose Test Skill or Projectile Skill for the moment)
  - CastTime and Cooldown only effect the UI at the moment, have to implement a system for that, just wanted to check UI
  - Define a Effect
	--> Either Damage or Buff Effect
	--> For Damage: Chose what will reduce the Damage (Resistence), NONE possible
	--> For Buff: Choose which Stats will be changed
  - Choose Effects for the skill
	--> TestSkill applies the effects immediatly when clicked
	--> ProjectileSkill applies the effects when the Projectile hits an enemy
	--> foreach Effect which should be applied, create an List entry in "Effects"
	--> Choose a Effect(ScriptableObject)
	--> Choose a Value (I'm using something called Intreferences, guess what, they are ScriptableObjects. If you dont want that jsut tick Use Constant and define aValue in the field)
	--> Choose Action Wrapper --> how and when will the effect will be applied (instant => Duration == 0 & Tickintervall == 0, tick => Duration != 0 & tickIntervall != 0) in addidtion tick Reset At End if you want to reset the Value after the Time
  - Select Champion GameObject in Scene
  - In Champion Skills Script, choose Skills to Use (Dont change keys atm because the Input Manager doesnt check all keys)
  - Observe the Stats ScriptableObject of the Enemy Champion to see that the effects get applied

Additional Information:

	- I have created additional Systems therefore the skill system works:
	--> EventSystem
	--> InputSystem
	--> SelectSystem
	- Theses Systems are all ScriptableObjects of course. 

