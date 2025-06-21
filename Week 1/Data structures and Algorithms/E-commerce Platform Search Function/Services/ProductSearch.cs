using E_commerce_Platform_Search_Function.Models;

namespace E_commerce_Platform_Search_Function.Services
{
    public static class ProductSearch
    {
        // Linear search by Product Name (case-insensitive)
        public static Product? LinearSearch(Product[] products, string productName)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (string.Equals(products[i].Name, productName, StringComparison.OrdinalIgnoreCase))
                {
                    return products[i];
                }
            }
            return null;
        }

        public static Product? BinarySearch(Product[] sortedProducts, string productName)
        {
            int left = 0;
            int right = sortedProducts.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int comparison = string.Compare(sortedProducts[mid].Name, productName, StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                    return sortedProducts[mid];

                if (comparison < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return null;
        }
    }
}
