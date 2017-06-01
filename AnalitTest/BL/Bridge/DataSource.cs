using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Abstract;
using MySql.Data.MySqlClient;
using BL.Model;

namespace BL.Bridge
{
    internal class DataSource : AbstractDataSource
    {
        public List<ModelProduct> GetListProduct()
        {
            string sqlStr = "SELECT * FROM t_product WHERE stock_count > 0";
            var sqlCommand = new MySqlCommand(sqlStr, _connection);
            _connection.Open();
            MySqlDataReader MyDataReader;
            MyDataReader = sqlCommand.ExecuteReader();
            var result = new List<ModelProduct>();
            while (MyDataReader.Read())
            {
                result.Add(new ModelProduct {
                    Id = MyDataReader.GetString("product_id"),
                    Name = MyDataReader.GetString("product_name"),
                    Price = MyDataReader.GetDouble("price"),
                    Count = MyDataReader.GetInt32("stock_count")
                });
            }
            MyDataReader.Close();
            _connection.Close();

            return result;
        }

        public bool CloseCheck(string checkId, List<ModelCheckPosition> checkList)
        {
            bool result = false;
            if (CreateCheck(checkId) && CreateCheckList(checkId, checkList) && UpdateProductList(checkList))
            {
                result = true;
            }
            return result;
        }

        private bool CreateCheck(string checkId)
        {
            if (String.IsNullOrWhiteSpace(checkId))
                return false;
            string sqlStr = "INSERT INTO t_check(id,datetime) VALUES('" + checkId + "',CURRENT_TIMESTAMP)";
            var sqlCommand = new MySqlCommand(sqlStr, _connection);
            _connection.Open();
            int res = sqlCommand.ExecuteNonQuery();
            _connection.Close();
            return res > 0;
        }

        private bool CreateCheckList(string checkId,List<ModelCheckPosition> checkList)
        {
            if (String.IsNullOrWhiteSpace(checkId) || checkList.Count < 1)
                return false;
            string sqlStr = "INSERT INTO t_check_list(id_check,id_product,count) VALUES";
            int startSqlLength = sqlStr.Length;
            foreach(var i in checkList)
            {
                if (sqlStr.Length > startSqlLength)
                    sqlStr += ",";
                sqlStr += "('" + checkId + "','" + i.Product.Id + "'," + i.Count + ")";
            }
            var sqlCommand = new MySqlCommand(sqlStr, _connection);
            _connection.Open();
            int res = sqlCommand.ExecuteNonQuery();
            _connection.Close();
            return res > 0;
        }

        private bool UpdateProductList(List<ModelCheckPosition> checkList)
        {
            if (checkList.Count < 1)
                return false;
            var productListStart = GetListProduct();
            List<ModelProduct> productListToUpdate = new List<ModelProduct>();
            if (productListStart.Count < 1)
                return false;
            foreach(var i in checkList)
            {
                var product = productListStart.FirstOrDefault(obj => obj.Id == i.Product.Id);
                if(product != null)
                {
                    productListToUpdate.Add(new ModelProduct {
                        Id = product.Id,
                        Count = product.Count - i.Count
                    });
                }
            }
            return JustUpdateProductListQuery(productListToUpdate);
        }

        private bool JustUpdateProductListQuery(List<ModelProduct> productList)
        {
            if (productList.Count < 1)
                return false;
            string sqlStr = "";
            
            foreach(var i in productList)
            {
                sqlStr += "UPDATE t_product SET stock_count="+i.Count+" WHERE product_id="+i.Id+"; \n";
            }
            var sqlCommand = new MySqlCommand(sqlStr, _connection);
            _connection.Open();
            int res = sqlCommand.ExecuteNonQuery();
            _connection.Close();
            return res > 0;
        }
    }
}
