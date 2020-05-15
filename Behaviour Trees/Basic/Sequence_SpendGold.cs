public class Sequence_SpendGold : Sequence
{
    public Sequence_SpendGold()
    {

        // Selector to Buy Ammo
        Selector chooseAmmoToBuy = new Selector();
        chooseAmmoToBuy.AddTask(new Task_BuyAssaultAmmo());
        chooseAmmoToBuy.AddTask(new Task_BuySniperAmmo());
        chooseAmmoToBuy.AddTask(new Task_BuyShotgunAmmo());

        children.Add(chooseAmmoToBuy);

        // selector to purchase ammo
        Selector purchaseSurvivors = new Selector();
        purchaseSurvivors.AddTask(new Task_BuySurvivors());
        purchaseSurvivors.AddTask(new Task_CannotPurchase()); 

        children.Add(purchaseSurvivors);

        Selector purchaseTowers = new Selector();
        purchaseTowers.AddTask(new Task_BuyTowers());
        purchaseTowers.AddTask(new Task_CannotPurchase());

        children.Add(purchaseTowers);

    }

    public override TASK_RETURN_STATUS Run(Survivor_AI sAI)
    {
        base.Run(sAI);

        return TASK_RETURN_STATUS.SUCCESS;
    }
}
