﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoEventos.Models
{
    public class Login
    {
        public String Usuario { get; set; }

        public String Senha { get; set; }

        public bool RealizarLogin()
        {

            string strConn = "server = localhost; User Id = leticiaps; database = projetoeventos; password = larissa_7898";
            
            MySqlConnection cn = new MySqlConnection(strConn);
            MySqlCommand cmd = new MySqlCommand();
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LOGIN_S_FUNCIONARIO";
                cmd.Parameters.AddWithValue("@usuario", this.Usuario);
                cmd.Parameters.AddWithValue("@senha", this.Senha);
                cmd.Connection = cn;
                try
                {
                    cmd.Connection.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch
                {
                    return false;
                }
            }
        }
    }
}