using System;
using System.Collections.Generic;
using Npgsql;

class CostumerRespository : IRepository<Costumer>
{
    private string connectionString = "Host=dpg-crcb7cjqf0us738ikg5g-a.oregon-postgres.render.com;Port=5432;Username=moutsmaster;Password=HLnW2jj3GqvAlyo2HLnmtdCdo4uL1TJ7;Database=mouts_padaria";

    public CostumerRespository() { }

    public override Costumer Alter(Costumer t)
    {
        try
        {
            string updateQuery = "UPDATE customers SET name = @name, document = @document WHERE id = @id";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", t.Name);
                    command.Parameters.AddWithValue("@document", t.Document);
                    command.Parameters.AddWithValue("@id", t.Id);
                    command.ExecuteNonQuery();
                }
            }
            return t;
        }
        catch (Exception)
        {
            // Rethrow the caught exception
            throw;
        }
    }

    public override Costumer Create(Costumer t)
    {
        try
        {
            string insertQuery = "INSERT INTO customers (name, document, points) VALUES (@name, @document, @points) RETURNING id";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", t.Name);
                    command.Parameters.AddWithValue("@document", t.Document);
                    command.Parameters.AddWithValue("@points", 0);
                    t.Id = (int)command.ExecuteScalar();
                }
            }
            return t;
        }
        catch (Exception)
        {
            // Rethrow the caught exception
            throw;
        }
    }

    public override void Delete(int id)
    {
        try
        {
            string deleteQuery = "DELETE FROM customers WHERE id = @id";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception)
        {
            // Rethrow the caught exception
            throw;
        }
    }

    public override List<Costumer> FindAll()
    {
        var customers = new List<Costumer>();
        try
        {
            string findAllQuery = "SELECT id, name, document, points FROM customers";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(findAllQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Costumer
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Document = reader.GetString(2),
                                Points = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
            // Rethrow the caught exception
            throw;
        }
        return customers;
    }

    public override Costumer FindById(int id)
    {
        Costumer customer = null;
        try
        {
            string findByIdQuery = "SELECT id, name, document, points FROM customers WHERE id = @id";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(findByIdQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Costumer
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Document = reader.GetString(2),
                                Points = reader.GetInt32(3)
                            };
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
            // Rethrow the caught exception
            throw;
        }
        return customer;
    }
}
