namespace AWWW_lab2_gr1.Models
{
    public static class Repository
    {
        private static readonly ICollection<Category> categories = new List<Category>();
        public static ICollection<Category> Categories => categories;
        public static void AddCategory(Category category)
        {
            if (categories.Count > 0)
            {
                var id = categories.Last().Id;
                category.Id = ++id;
            }
            else
                category.Id = 0;
            categories.Add(category);
        }
    }
}
