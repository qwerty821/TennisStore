using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Abstractions;
using OnlineStore.Models.DbModels;
using OnlineStore.Models.RacketModels;
using OnlineStore.Models.RacketsModels;

namespace OnlineStore.SQL
{
    public static class SQLQueries
    {
        
        static SQLQueries()
        {
              
        }
        public static async Task<Brand> getBrand(Guid id)
        {
            using (OnlineStoreContext db = new OnlineStoreContext())
            {
                var list = await db.Brands.FromSqlRaw($"SELECT * FROM Brands WHERE b_id = '{id}'").ToListAsync();
                
                if (list != null && list.Count > 0)
                {
                    return list[0];
                } else
                {
                    return new Brand() { BId = Guid.Empty, BName = "null" };
                }
               
            }
        }

        public static async Task<List<Racket>> getAll(FilterOptions filterOptions)
        {
            
            if (filterOptions != null) {
               
                string sqlQuery = $@"Select * FROM Rackets 
                                    WHERE r_brand in (
                                        SELECT b_id from Brands ";
                
                if (!filterOptions.Brands.IsNullOrEmpty())
                {
                    string brands = "";
                    foreach (string brand in filterOptions.Brands)
                    {
                        brands += $"'{brand}',";
                    }
                    brands = brands.Remove(brands.Length - 1);

                    sqlQuery += $@" WHERE b_name in ({brands}) ";
                }
                sqlQuery += " ) ";
                sqlQuery += " ORDER BY ";
                sqlQuery += filterOptions.Sort switch { 
                    SortOption.Ascending => " r_price ",
                    SortOption.Descending => "r_price DESC ",
                    SortOption.None  => " r_id ",
                    _ => " r_id "
                };
                  
                sqlQuery += ";";

                using (OnlineStoreContext db = new OnlineStoreContext())
                {
                    var list = await db.Rackets.FromSqlRaw(sqlQuery).ToListAsync();
                    return list;
                }
                
            }
            return new List<Racket>() { };
        }

        public static async Task<Racket> get(Guid id)
        {
            string sqlQueryRacket = $@"Select * FROM Rackets 
                                    Where r_id = '{id}'";

            string sqlQueryImages = $@"Select * FROM Images
                                    Where id = '{id}'";

            Racket r;
            using (OnlineStoreContext db = new OnlineStoreContext())
            {
                var sqlRes = await db.Rackets.FromSqlRaw(sqlQueryRacket).ToListAsync();
                r = sqlRes[0];

                var imagesRes = await db.Images.FromSqlRaw(sqlQueryImages).ToListAsync(); 
                
                r.images = imagesRes;
            }

            return r;
        }
    }
}
