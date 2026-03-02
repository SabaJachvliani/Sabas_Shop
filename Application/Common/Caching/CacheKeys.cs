namespace Application.Common.Caching
{
    public static class CacheKeys
    {
        public const string ProductCategoryList = "productCategories:list";
        public static string ProductCategoryById(int id) => $"productCategory:{id}";

        public const string ProductList = "products:list";
        public static string ProductById(int id) => $"product:{id}";      

    }
}
