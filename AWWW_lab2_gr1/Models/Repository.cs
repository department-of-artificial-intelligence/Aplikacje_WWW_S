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

        private static readonly ICollection<Tag> tags = new List<Tag>();
        public static ICollection<Tag> Tags => tags;
        public static void AddTag(Tag tag)
        {
            if (tags.Count > 0)
            {
                var id = tags.Last().Id;
                tag.Id = ++id;
            }
            else
                tag.Id = 0;
            tags.Add(tag);
        }

        
        private static readonly ICollection<Address> addresses = new List<Address>();
        public static ICollection<Address> Addresses => addresses;
        public static void AddAddress(Address address)
        {
            if (addresses.Count > 0)
            {
                var id = addresses.Last().Id;
                address.Id = ++id;
            }
            else
                address.Id = 0;
            addresses.Add(address);
        }
    }
}
