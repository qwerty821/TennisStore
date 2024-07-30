using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Abstractions;
using OnlineStore.Contracts;
using OnlineStore.Models.DbModels;
using OnlineStore.Models.RacketsModels;
using Racket = OnlineStore.Models.RacketsModels.Racket;

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
                }
                else
                {
                    return new Brand() { BId = Guid.Empty, BName = "null" };
                }

            }
        }

        public static async Task<List<Racket>> getAll(FilterOptions filterOptions)
        {

            if (filterOptions != null)
            {

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
                sqlQuery += filterOptions.Sort switch
                {
                    SortOption.Ascending => " r_price ",
                    SortOption.Descending => "r_price DESC ",
                    SortOption.None => " r_id ",
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

        public static async Task<Racket?> get(Guid id)
        {
            string sqlQueryRacket = $@"Select * FROM Rackets 
                                    Where r_id = '{id}'";

            string sqlQueryImages = $@"Select * FROM Images
                                    Where ref_id = '{id}'";

            Racket? r;
            using (OnlineStoreContext db = new OnlineStoreContext())
            {
                var sqlRes = await db.Rackets.FromSqlRaw(sqlQueryRacket).ToListAsync();
                r = sqlRes?[0];

                var imagesRes = await db.Images.FromSqlRaw(sqlQueryImages).ToListAsync();

                if (r !=  null)
                {
                    r.images = imagesRes;
                }
            }
            return r;
        }

        public static async Task<Guid> addRacket(AddRacketModel r)
        {
            string SqlQueryBrnadID = $"SELECT * FROM BRANDS WHERE b_name LIKE '{r.Brand}';";
            Brand brand;

            await Console.Out.WriteLineAsync(SqlQueryBrnadID);

            using (OnlineStoreContext db = new OnlineStoreContext())
            {
                var sqlRes = await db.Brands.FromSqlRaw(SqlQueryBrnadID).ToListAsync();
                brand = sqlRes[0];
            }
            Guid rId = Guid.NewGuid();
            string sqlInsert = $@"INSERT INTO Rackets VALUES(
                            '{rId}', 
                            '{r.Name}',
                            '{brand.BId}', 
                            {r.Price}, 
                            '{r.ImageUrl}');";

            using (OnlineStoreContext db = new OnlineStoreContext())
            {
                var sqlRes = await db.Database.ExecuteSqlRawAsync(sqlInsert);
            }

            return rId;
        }

        public static bool ExistRacketId(Guid id)
        {
            using (OnlineStoreContext db = new OnlineStoreContext())
            {
                string sqlQuery = $"SELECT * FROM Rackets WHERE r_id = '{id}'";
                var x = db.Rackets.FromSqlRaw(sqlQuery).ToList();
                return (x.Count > 0);
            }
        }

        public static void RemoveImage(string id)
        {
            using (OnlineStoreContext db = new OnlineStoreContext())
            {
                string sqlQuery = $"DELETE FROM Images WHERE id = '{id}';";
                var res = db.Database.ExecuteSqlRaw(sqlQuery);
            }
        }

        public static void SaveImage(string imageUrl)
        {
            using (OnlineStoreContext db = new OnlineStoreContext())
            {
                string sqlQuery = $"DELETE FROM Images WHERE image_url = '{imageUrl}';";
                var res = db.Database.ExecuteSqlRaw(sqlQuery);
            }
        }

        public static void EditImage(ImageEdit imageEdit)
        {
            using (OnlineStoreContext db = new OnlineStoreContext())
            {
                string sqlQuery = $"UPDATE Images SET image_url = '{imageEdit.ImageUrl}' WHERE id = '{imageEdit.id}' ;";
                var res = db.Database.ExecuteSqlRaw(sqlQuery);
            }
        }

        public static async Task<string> GetImageUrl(string id)
        {
            using (OnlineStoreContext db = new OnlineStoreContext())
            {
                var list = await db.Images.FromSqlRaw($"SELECT * FROM Images WHERE id = '{id}'").ToListAsync();

                return list?[0].ImageUrl;

            }
        }

        public static void addImageToRacket(ImageAdd image)
        {
            using (OnlineStoreContext db = new OnlineStoreContext())
            {
                string sqlQuery = $"INSERT INTO images VALUES('{Guid.NewGuid()}','{image.racket_id}', '{image.ImageUrl}')";
                var res = db.Database.ExecuteSqlRaw(sqlQuery);
            }
        }


        //public static async Task<int> EditRacket()
        //{

        //}
    }
}
