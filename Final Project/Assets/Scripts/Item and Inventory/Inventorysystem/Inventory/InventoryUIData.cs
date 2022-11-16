namespace PInventory
{
    public struct InventoryUIData
    {
        public InventoryItemData itemData;
        public bool IsStacked;

        public InventoryUIData(InventoryItemData itemData, bool isStacked)
        {
            this.itemData = itemData;
            IsStacked = isStacked;
        }
    }
}