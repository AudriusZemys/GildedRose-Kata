namespace GildedRose.Helpers
{
    public static class ItemQualityHelper
    {
        // Could use uint for quality :)
        public static void EnsureQualityIsNotNegative(Item item)
        {
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
