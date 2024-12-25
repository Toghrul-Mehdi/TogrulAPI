namespace TogrulAPI.Extensions
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> Random<T>(this IQueryable<T> query,int randomnumber)
        {
            Random random = new Random();
            int num = random.Next(0,randomnumber);
            return query.Skip(num);
        }
    }
}
