using System;
using System.Collections.Generic;
using Npgsql;

class ProductsRespository : IRepository<Product>
{
    private string connectionString = "Host=dpg-crcb7cjqf0us738ikg5g-a.oregon-postgres.render.com;Port=5432;Username=moutsmaster;Password=HLnW2jj3GqvAlyo2HLnmtdCdo4uL1TJ7;Database=mouts_padaria";

    public ProductsRespository(){}

    public override Product Alter(Product t)
    {
        try{
            string updateQuery = "UPDATE products SET description = @description, price = @price WHERE id = @id";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            using (NpgsqlCommand command = new NpgsqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@id", t.Id);
                command.Parameters.AddWithValue("@description", t.Description);
                command.Parameters.AddWithValue("@price", t.Price);
                connection.Open();
                command.ExecuteNonQuery();
                
            }
            return t;
        }
        catch (Exception ex){ 
            throw new Exception(ex.Message);
        }
    }

    public override Product Create(Product t)
    {
        try{
            string insertQuery = "INSERT INTO products (description, price) VALUES (@description, @price) RETURNING id";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            using (NpgsqlCommand command = new NpgsqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@description", t.Description);
                command.Parameters.AddWithValue("@price", t.Price);
                connection.Open();
                t.Id = Convert.ToInt32(command.ExecuteScalar());
            }
            return t;
        }
        catch (Exception ex){ 
            throw new Exception(ex.Message);
        }
    }

    public override void Delete(int id)
    {
        try{
            string deleteQuery = "DELETE FROM products WHERE id = @id";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            using (NpgsqlCommand command = new NpgsqlCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                onnection.Open();
                command.ExecuteNonQuery();
            }
                
        }
        catch (Exception ex){ 
            throw new Exception(ex.Message);
        }
    }

    public override List<Product> FindAll()
    {
        List<Product> products = new List<Product>();
        try{
            string selectQuery = "SELECT id, description, price FROM products";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
            {
                connection.Open();
                using (NpgsqlDataReader reader = command.ExecuteReader()){
                    while (reader.Read()){
                        products.Add(new Product
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Description = reader.GetString(reader.GetOrdinal("description")),
                            Price = reader.GetString(reader.GetOrdinal("price")),
                        });
                    }
                }
            }
        }
        catch (Exception ex){
            throw new Exception(ex.Message);
        }    
        return products;
    }

    public override Product FindById(int id)
    {
        try{
            Product product = null;
            string selectQuery = "SELECT id, description, price FROM products WHERE id = @id";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = new Product{
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Description = reader.GetString(reader.GetOrdinal("description")),
                        Price = reader.GetString(reader.GetOrdinal("price")),
                        };
                    }
                }

            }
                
        }
        catch (Exception ex){
            throw new Exception(ex.Message);
        }
        return pessoa;
    }
    
}