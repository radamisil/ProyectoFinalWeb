﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;

namespace AdondeVamos.Services
{
    public class BaseService
    {
        protected DataTable InternalGetDataTable(string procedure, List<SqlParameter> parameters)
        {
            var dataTable = new DataTable();
            using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings["DBConn"].ToString()))
            using (var cmd = new SqlCommand(procedure, con))
            using (var sqlAdapter = new SqlDataAdapter(cmd))
            {
                con.Open();
                cmd.Parameters.AddRange(parameters.ToArray());
                cmd.CommandType = CommandType.StoredProcedure;
                sqlAdapter.Fill(dataTable);
                cmd.Parameters.Clear();
                con.Close();
            }
            return dataTable;
        }

        protected DataTable GetDataTable(string procedure, List<SqlParameter> parameters)
        {
            var result = InternalGetDataTable(procedure, parameters);

            return result;
        }

        protected List<SqlParameter> GetParametersUser(string filter)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@filter", filter.Replace("'", "''")));
            
            return parameters;
        }

        protected List<SqlParameter> GetParameters(string filterPlace, string filterUser)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@filterPlace", filterPlace.Replace("'", "''")));
            parameters.Add(new SqlParameter("@filterUser", filterUser.Replace("'", "''")));

            return parameters;
        }
    }       
}