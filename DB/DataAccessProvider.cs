using DoktorSelector.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoktorSelector.DB
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly DoktorContext _context;

        public DataAccessProvider(DoktorContext context)
        {
            _context = context;
        }

        public void AddDoktorItemRecord(DoktorItem doktor)
        {
            _context.doctors.Add(doktor);
            _context.SaveChanges();
        }

        public void UpdateDoktorItemRecord(DoktorItem doktor)
        {
            _context.doctors.Update(doktor);
            _context.SaveChanges();
        }

        public void DeleteDoktorItemRecord(int id)
        {
            var entity = _context.doctors.FirstOrDefault(t => t.id == id);
            _context.doctors.Remove(entity);
            _context.SaveChanges();
        }

        public List<DoktorItem> GetDoktorItemRecords(string specialty)
        {

            int myid = -1;
            string myphonenumber;
            string myname;
            string mysurname;
            string myspecialty;
            string myhospital;
            DoktorItem mydoc;
            var connString = "Server=127.0.0.1;Port=5432;Database=doktordb;User Id=doktorlar;Password=bora99bora;";

            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT * FROM doctors WHERE specialty = (@p)", conn);

            cmd.Parameters.AddWithValue("p", specialty);
            cmd.ExecuteNonQuery();




            NpgsqlDataReader dr = cmd.ExecuteReader();

                List<DoktorItem> temp = new List<DoktorItem>();

                while (dr.Read() && dr.IsOnRow)
                {
                    myid = dr.GetInt32(0);
                    myphonenumber = dr.GetString(1);
                    myname = dr.GetString(2);
                    mysurname = dr.GetString(3);
                    myspecialty = dr.GetString(4);
                    myhospital = dr.GetString(5);

                  /*  mydoc = new DoktorItem
                    {
                        id = myid,
                        phonenumber = myphonenumber,
                        name = myname,
                        surname = mysurname,
                        specialty = myspecialty,
                        hospital = myhospital
                    }; */

                    

                    mydoc = new DoktorItem(myid, myphonenumber, myname, mysurname, myspecialty, myhospital);



                    temp.Add(mydoc);

                    return temp;
                }


            return null;
                
            
        }

        public DoktorItem GetDoktorItemSingleRecord(int id)
        {
            return _context.doctors.FirstOrDefault(t => t.id == id);
        }

       /* public async Task<List<DoktorItem>> GetDoktorItemRecordsAsync(string specialty, string hospital)
        {
            var connString = "Server=127.0.0.1;Port=5432;Database=doktordb;User Id=doktorlar;Password=bora99bora;";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            // Retrieve
            await using (var cmd = new NpgsqlCommand("SELECT * FROM doctors WHERE specialty = '" + specialty + "' AND hospital = '" + hospital + "';", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                    Console.WriteLine(reader.GetString(0));

            return _context.doctors.ToList();
        } */
    }
}
