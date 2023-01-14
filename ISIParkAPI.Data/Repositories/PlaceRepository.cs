﻿/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 *  
 */
using Dapper;
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories
{
    /// <summary>
    /// This class contains all the functions that perform actions of the parking spaces
    /// </summary>
    public class PlaceRepository : IPlaceRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public PlaceRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Connects to database
        /// </summary>
        /// <returns></returns>
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        /// <summary>
        /// This method gets all parking spaces from database using a query
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Place>> GetAllPlace()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM lugar";
            return await db.QueryAsync<Place>(sql, new { });
        }

        /// <summary>
        /// This method get one place from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Place> GetPlaceById(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT numero_lugar, setorid_setor, tipo_lugarn_tipo, estado, utilizador_Tipo_veiculosmatricula
                        FROM lugar
                        WHERE numero_lugar = @ID";

            return await db.QueryFirstOrDefaultAsync<Place>(sql, new { ID = id });
        }

        /// <summary>
        /// This method insert a new place on database
        /// </summary>
        /// <param name="place"></param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertPlace(Place place)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO lugar (setorid_setor, tipo_lugarn_tipo, estado, utilizador_Tipo_veiculosmatricula)
                        VALUES (@setorid_setor, @tipo_lugarn_tipo, @estado, @utilizador_Tipo_veiculosmatricula)";

            var result = await db.ExecuteAsync(sql, new
            {
                place.Setorid_setor,
                place.Tipo_lugarn_tipo,
                place.Estado,
                place.Utilizador_Tipo_veiculosmatricula
            });

            return result > 0;
        }

        /// <summary>
        /// This method changes data of an place
        /// </summary>
        /// <param name="place"></param>
        /// <returns>True Updated or false</returns>
        public async Task<bool> UpdatePlace(Place place)
        {
            var db = dbConnection();
            var sql = @"UPDATE lugar
                        SET setorid_setor = @Setorid_setor, tipo_lugarn_tipo = @Tipo_lugarn_tipo, 
                            estado = @Estado, 
                            utilizador_Tipo_veiculosmatricula = @Utilizador_Tipo_veiculosmatricula
                        WHERE @numero_lugar = Numero_lugar";

            var result = await db.ExecuteAsync(sql, new
            {
                place.Setorid_setor,
                place.Tipo_lugarn_tipo,
                place.Estado,
                place.Utilizador_Tipo_veiculosmatricula,
                place.Numero_lugar

            });

            return result > 0;
        }

        /// <summary>
        /// This method delete an place of database 
        /// </summary>
        /// <param name="place"></param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeletePlace(Place place)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM lugar
                        WHERE numero_lugar = @Numero_lugar";
            var result = await db.ExecuteAsync(sql, new { Numero_lugar = place.Numero_lugar });
            return result > 0;
        }

        public async Task<int> GetPlaceSectorType(string Setor, string TipoLugar)
        {
            var db = dbConnection();    
            var sql = @"SELECT COUNT(l.estado) as num
                        FROM lugar l
                        INNER JOIN setor s 
                            ON l.setorid_setor = s.id_setor 
                        INNER JOIN tipo_lugar t
                            ON t.n_tipo = l.tipo_lugarn_tipo 
                        WHERE l.estado = 0
                            AND s.setor = @Setor
                            AND t.descricao = @TipoLugar";
            int result = await db.QueryFirstOrDefaultAsync<int>(sql, new { Setor = Setor, TipoLugar = TipoLugar });


            return result;
        }

        public async Task<string> GetSetorUser(int Userid)
        {
            var db = dbConnection();
            var sql = @"SELECT a.setor 
                        FROM (
                            SELECT aux.setor, max(RD) as numax
                            FROM (
                                SELECT s.setor, COUNT(s.setor) AS RD
                                FROM utilizador_Historico uh
                                INNER JOIN Historico h 
                                ON h.ID = uh.Historicoid
                                INNER JOIN lugar l
                                ON l.numero_lugar = h.lugarnumero_lugar 
                                INNER JOIN setor s
                                ON s.id_setor = l.setorid_setor 
                                WHERE uh.utilizadorid = @Userid
                                GROUP BY s.setor 
                                ) aux
                            ) a";
            string result = await db.QueryFirstOrDefaultAsync<string>(sql, new { Userid = Userid});


            return result;
        }

    }
}
