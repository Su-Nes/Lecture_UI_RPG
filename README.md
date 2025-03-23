Šajai spēlei es izvēlējos pievienot līmeņu sistēmu spēlētājam.
Lai to sasniegtu, es implementēju XP vākšanu no nogalinātiem pretiniekiem. Kad spēlētājs sasniedz pietiekamu daudzumu XP, viņu līmenis paaugstinās un viņiem ir dota iespēja uzlabot viņu dzīvību, stiprumu (strength) vai vairoga izturību.
Vēl es izvēlējos implementēt cīņas sistēmu, iedvesmojoties no Dungeons and Dragons, kas balstās uz Armor class un metamo kauliņu mešanu, lai kalkulētu sitienus. Līdz ar to paliek vērtīgāka līmeņu sistēma - spēlētājs var uzlabot viņa iespēju aizsargāties no sitieniem vai pievienot vairāk spēku viņu uzbrukumiem.

OOP principu pielietojums:
  Mantošana - 
    Galvenā bāzes klase ir Character, no kuras manto gan Player, gan Enemy klases. No Enemy klases vēl tiek mantotas Berserker un Golem klases.
  Enkapsulācija - 
     Izmantota, lai saņemtu mainīgo vērtības no citiem skriptiem.
     Piemērs: 
      [SerializeField] private float requiredXP = 10f;
      public float RequiredXP { get => requiredXP; }
      public float currentXP { get; private set; }
  Polimorfisms - 
    Izmantots GetHit() funkcijā iekš Character klases. Var ievadīt vai nu string, vai citu Character klasi, nu kuras tiks ņemts objekta nosaukums.
  Abstrakcija - 
    Character klase ir abstrakta, lai to varētu papildināt Player un Enemy klases. Tai ir absytrakts void Die(), kuru katra mantotā klase izmanto citādi.
    Weapon klase arī ir abstrakta, bet šim projektam es to īpašības īpaši neizmantoju.
