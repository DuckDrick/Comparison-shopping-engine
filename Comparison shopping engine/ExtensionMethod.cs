namespace Comparison_shopping_engine
{
    public static class ExtensionMethod
    {
        public static string[] getListViewItemRow(this Product product)
        {
            return new[] {product.Name, product.Price, product.Source};
        }
    }
}