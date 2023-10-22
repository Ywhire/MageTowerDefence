using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public static UIHandler Instance { get; private set; }

    
    
    [field: SerializeField,Header("Info UI")]
    public TMPro.TMP_Text TMPHealth { get; private set; }
    
    [field: SerializeField]
    public TMPro.TMP_Text Gold_TMP { get; private set; }
    
    [field: SerializeField]
    public TMPro.TMP_Text MagicDust_TMP { get; private set; }
    [field: SerializeField]
    public TMPro.TMP_Text TMPWave { get; private set; }



    [field: SerializeField, Header("Begin UI")]
    public Button BeginButton { get; private set; }

    [field: SerializeField]
    public RectTransform BeginPanel { get; private set; }

    
    
    [field: SerializeField, Header("Pause UI")]
    public Button PauseButton { get; private set; }

    [field: SerializeField]
    public RectTransform PausePanel { get; private set; }

    [field: SerializeField]
    public Button MainMenuButton { get; private set; }

    [field: SerializeField]
    public Button QuitButton { get; private set; }
    [field: SerializeField]
    public Button PauseCloseButton { get; private set; }
    
    
    
    [field: SerializeField, Header("GameOver UI")]
    public RectTransform GameOverPanel { get; private set; }

    [field: SerializeField]
    public Button RestartButton { get; private set; }

    [field:SerializeField]
    public Button FightButton { get; private set; }

    [field: SerializeField]
    public Button GMainMenuButton { get; private set; }

    [field: SerializeField]
    public Button GQuitButton { get; private set; }
    
    [field: SerializeField]
    public Button ShopButton { get; private set; }



    [field: SerializeField, Header("Victory UI")]
    public RectTransform VictoryPanel { get; private set; }

    [field: SerializeField]
    public Button VRestartButton { get; private set; }

    [field: SerializeField]
    public Button VMainMenuButton { get; private set; }

    [field: SerializeField]
    public Button VQuitButton { get; private set; }




    [field: SerializeField, Header("Shop UI")]

    public RectTransform ShopPanel { get; private set; }
    
    [field:SerializeField]
    public Button SpellDamageShopButton { get; private set; }

    [field: SerializeField]
    public TMPro.TMP_Text TMPSpellDamageShop { get; private set; }
    
    [field: SerializeField]
    public TMPro.TMP_Text TMPSpellDamageShopCost { get; private set; }

    [field:SerializeField]
    public Button RateOfFireShopButton { get; private set; }

    [field: SerializeField]
    public TMPro.TMP_Text TMPRateOfFireShop { get; private set; }

    [field: SerializeField]
    public TMPro.TMP_Text TMPRateOfFireShopCost { get; private set; }

    [field:SerializeField]
    public Button LuckShopButton { get; private set; }

    [field: SerializeField]
    public TMPro.TMP_Text TMPLuckShop { get; private set; }

    [field: SerializeField]
    public TMPro.TMP_Text TMPLuckShopCost { get; private set; }

    [field:SerializeField]
    public Button HealthShopButton { get; private set; }

    [field: SerializeField]
    public TMPro.TMP_Text TMPHealthShop { get; private set; }

    [field: SerializeField]
    public TMPro.TMP_Text TMPHealthShopCost { get; private set; }


    [field: SerializeField, Header("Upgrades UI")]
    public RectTransform UpgradePanel { get; private set; }
    [field: SerializeField, Header("Spell Damage")]
    public Button SpellDamageButton { get; private set; }

    [field: SerializeField]
    public TMPro.TMP_Text TMPSpellDamage { get; private set; }
    
    [field: SerializeField]
    public TMPro.TMP_Text TMPSpellDamageCost { get; private set; }

    


    [field: SerializeField, Header("Rate of Fire")]
    public Button RateOfFireButton { get; private set; }
    
    [field: SerializeField]
    public TMPro.TMP_Text TMPRateOfFire{ get; private set; }

    [field: SerializeField]
    public TMPro.TMP_Text TMPRateOfFireCost { get; private set; }



    [field: SerializeField, Header("Luck")]
    public Button LuckButton { get; private set; }
    
    [field: SerializeField]
    public TMPro.TMP_Text TMPLuck { get; private set; }

    [field: SerializeField]
    public TMPro.TMP_Text TMPLuckCost { get; private set; }
    
   

    [field: SerializeField, Header("Health")]
    public Button GainHealthButton { get; private set; }

    [field: SerializeField]
    public TMPro.TMP_Text TMPGainHealth { get; private set; }

    [field: SerializeField]
    public TMPro.TMP_Text TMPGainHealthCost { get; private set; }

    public Action<int> Buy;
    public Action<int> ShopBuy;

    private void Awake()
    {
        if (Instance != null && Instance != this )
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        
        PausePanel.gameObject.SetActive(false);
        GameOverPanel.gameObject.SetActive(false);
        ShopPanel.gameObject.SetActive(false);
        UpgradePanel.gameObject.SetActive(true);
        VictoryPanel.gameObject.SetActive(false);
    }
    private void OnEnable()
    {

        BeginButton.onClick.AddListener(Begin);
        PauseButton.onClick.AddListener(PauseOpen);
        PauseCloseButton.onClick.AddListener(PauseClose);
        MainMenuButton.onClick.AddListener(GoToMainMenu);
        QuitButton.onClick.AddListener(Exit);
        RestartButton.onClick.AddListener(Restart);
        GMainMenuButton.onClick.AddListener(GoToMainMenu);
        GQuitButton.onClick.AddListener(Exit);
        FightButton.onClick.AddListener(Fight);

        VRestartButton.onClick.AddListener(Restart);
        VMainMenuButton.onClick.AddListener(GoToMainMenu);
        VQuitButton.onClick.AddListener(Exit);

        SpellDamageButton.onClick.AddListener(UpgradeDamage);
        RateOfFireButton.onClick.AddListener(UpgradeRateOfFire);
        LuckButton.onClick.AddListener(UpgradeLuck);
        GainHealthButton.onClick.AddListener(GainHealth);

        //Shop Buttons
        ShopButton.onClick.AddListener(OpenShop);
        SpellDamageShopButton.onClick.AddListener(UpgradeDamagePermanently);
        RateOfFireShopButton.onClick.AddListener(UpgradeRateOfFirePermanently);
        LuckShopButton.onClick.AddListener(UpgradeLuckPermanently);
        HealthShopButton.onClick.AddListener(UpgradeMaxHealth);
    }

   

    private void OnDisable()
    {
        BeginButton.onClick.RemoveListener(Begin);
        PauseButton.onClick.RemoveListener(PauseOpen);
        PauseCloseButton.onClick.RemoveListener(PauseClose);
        MainMenuButton.onClick.RemoveListener(GoToMainMenu);
        QuitButton.onClick.RemoveListener(Exit);
        RestartButton.onClick.RemoveListener(Restart);
        GMainMenuButton.onClick.RemoveListener(GoToMainMenu);
        GQuitButton.onClick.RemoveListener(Exit);
        FightButton.onClick.RemoveListener(Fight);

        VRestartButton.onClick.RemoveListener(Restart);
        VMainMenuButton.onClick.RemoveListener(GoToMainMenu);
        VQuitButton.onClick.RemoveListener(Exit);

        SpellDamageButton.onClick.RemoveListener(UpgradeDamage);
        RateOfFireButton.onClick.RemoveListener(UpgradeRateOfFire);
        LuckButton.onClick.RemoveListener(UpgradeLuck);
        GainHealthButton.onClick.RemoveListener(GainHealth);

        //Shop Buttons
        ShopButton.onClick.RemoveListener(OpenShop);
        SpellDamageShopButton.onClick.RemoveListener(UpgradeDamagePermanently);
        RateOfFireShopButton.onClick.RemoveListener(UpgradeRateOfFirePermanently);
        LuckShopButton.onClick.RemoveListener(UpgradeLuckPermanently);
        HealthShopButton.onClick.RemoveListener(UpgradeMaxHealth);
    }

    private void Start()
    {

    }

    public void RepaintCosts(int damageCost, float rateOfFireCost, float luckCost, int gainHealthAmount, float healthGainCost)
    {
        TMPSpellDamageCost.text = damageCost.ToString();
        TMPRateOfFireCost.text = rateOfFireCost.ToString();
        TMPLuckCost.text = luckCost.ToString();
        TMPGainHealth.text = gainHealthAmount.ToString();
        TMPGainHealthCost.text = healthGainCost.ToString();
    }

    public void RepaintDamageCost(int damageCost)
    {
        TMPSpellDamageCost.text = damageCost.ToString();

    }

    public void RepaintRateOfFireCost(float rateOfFireCost)
    {
        TMPRateOfFireCost.text = rateOfFireCost.ToString();
    }

    public void RepaintLuckCost(float luckCost)
    {
        TMPLuckCost.text = luckCost.ToString();
    }

    public void RepaintGainHealthCost(float healthGainCost)
    {
        TMPGainHealthCost.text = healthGainCost.ToString();
    }

    public void RepaintMaxHealthCost(float maxHealthCost)
    {
        TMPHealthShopCost.text = maxHealthCost.ToString();
    }

    public void RepaintLuckShopCost(float luckShopCost)
    {
        TMPLuckShopCost.text = luckShopCost.ToString();
    }
    public void RepaintRateOfFireShopCost(float rateOfFireShopCost)
    {
        TMPRateOfFireShopCost.text = rateOfFireShopCost.ToString();
    }
    public void RepaintDamageShopCost(float damageShopCost)
    {
        TMPSpellDamageShopCost.text = damageShopCost.ToString();
    }
    
    public void RepaintHealth(float amount, int maxAmount)
    {
        TMPHealth.text = amount.ToString() + "/" + maxAmount.ToString();
        TMPHealthShop.text = maxAmount.ToString();
    }

    public void RepaintMaterial(float gold, float magicDust)
    {
        Gold_TMP.text = gold.ToString();
        MagicDust_TMP.text = magicDust.ToString();
    }

    public void RepaintBaseDamage(float damage)
    {
        TMPSpellDamageShop.text = damage.ToString();
    }
    public void RepaintDamage(float damage)
    {
        TMPSpellDamage.text = damage.ToString();
    } 
    public void RepaintBaseRateOfFire(float rof)
    {
        TMPRateOfFireShop.text = rof.ToString();
    }
    public void RepaintRateOfFire(float rof)
    {
        TMPRateOfFire.text = rof.ToString();
    }

    public void RepaintBaseLuck(float baseLuck)
    {
        TMPLuckShop.text = baseLuck.ToString();
    }
    public void RepaintLuck(float luck)
    {
        TMPLuck.text = luck.ToString();
    }

    public void RepaintWave(int wave)
    {
        TMPWave.text = "Wave: " + wave + "/10";
    }

    public void GameOver()
    {
        GameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;

        PauseButton.interactable = false;
    }

    public void Victory()
    {
        PauseButton.interactable = false;
        VictoryPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
        // Delete Everything
        DataManager.Instance.NewGame(true);
    }

    private void Fight()
    {
        ShopPanel.gameObject.SetActive(false);
        GameOverPanel.gameObject.SetActive(false);
        UpgradePanel.gameObject.SetActive(true);

        //Save Every Shop Upgrade Progress 
        DataManager.Instance.SaveGame();
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    private void Begin()
    {
        Time.timeScale = 1f;
        BeginPanel.gameObject.SetActive(false);
        UpgradePanel.gameObject.SetActive(true);
    }

    private void Exit()
    {
        Application.Quit();
    }
    private void GoToMainMenu()
    {
        DataManager.Instance.SaveGame();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        
    }
    private void Restart()
    {
        DataManager.Instance.NewGame(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    private void OpenShop()
    {
        // ShopUI panel
        ShopPanel.gameObject.SetActive(true);
        UpgradePanel.gameObject.SetActive(false);
    }
    private void PauseOpen()
    {
        Time.timeScale = 0f;
        PausePanel.gameObject.SetActive(true);
    }

    private void PauseClose()
    {
        Time.timeScale = 1f;
        PausePanel.gameObject.SetActive(false);
    }

    private void UpgradeDamage()
    {        
        Buy?.Invoke(0);
    }

    private void UpgradeRateOfFire()
    {
        Buy?.Invoke(1); 
    }
    private void UpgradeLuck()
    {        
        Buy?.Invoke(2);       
    }

    private void GainHealth()
    {
        Buy?.Invoke(3);
    }

    private void UpgradeMaxHealth()
    {
        ShopBuy?.Invoke(0);
    }

    private void UpgradeLuckPermanently()
    {
        ShopBuy?.Invoke(1);
    }

    private void UpgradeRateOfFirePermanently()
    {
        ShopBuy?.Invoke(2);
    }

    private void UpgradeDamagePermanently()
    {
        ShopBuy?.Invoke(3);
    }
}
