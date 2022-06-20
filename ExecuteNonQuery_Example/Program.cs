using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ExecuteNonQuery_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Test1();

            string constr = $"server = .;database=xxx;uid=sa;pwd=Teknosol2008;"; ;

            STKKOD_DEGISTIR();
        }
        

        public static void STKKOD_DEGISTIR()
        {


            string constr = $"server = .;database=xxx;uid=sa;pwd=***;"; ;

         

            
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("VSTKLIB.dbo.STKKOD_DEGISTIR", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SirketKodu", SqlDbType.Int).Value = 8;
                    cmd.Parameters.Add("@MevcutStokTipi", SqlDbType.VarChar).Value = "00400";
                    cmd.Parameters.Add("@MevcutStokKodu", SqlDbType.VarChar).Value = "STK00400";
                    cmd.Parameters.Add("@YeniStokTipi", SqlDbType.VarChar).Value = "00400";
                    cmd.Parameters.Add("@YeniStokKodu", SqlDbType.VarChar).Value = "STK00400x";
                    cmd.Parameters.Add("@UserKodu", SqlDbType.VarChar).Value = "QSECOFR";
                    cmd.Parameters.Add("@Attempt", SqlDbType.Int).Value = -1;


                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValue);
                    con.Open();
                    object o = cmd.ExecuteNonQuery();

                    Console.Write("Geri dönüş değeri: {0}, Dönen Paremetre: {1}", o?.ToString(), returnValue?.ToString());
                    
                    con.Close();
                }
            }
        }
    }
}
