/*
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
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
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

        public async Task<List<ShowSetor>> GetPlaceSectorType()
        {
            var db = dbConnection();    
            var sql = @"SELECT setor, descricao, COUNT(l.estado) AS num 
                        FROM lugar l
                        INNER JOIN setor s 
                        ON l.setorid_setor = s.id_setor 
                        INNER JOIN tipo_lugar t
                        ON t.n_tipo = l.tipo_lugarn_tipo 
                        WHERE l.estado = 0
                        GROUP BY setor, descricao";

            IEnumerable<SetorType> result = await db.QueryAsync<SetorType>(sql, new { });

            var db1 = dbConnection();
            var sql1 = @"SELECT DISTINCT setor FROM setor ";

            IEnumerable<string> listasetores = await db1.QueryAsync<string>(sql1);

            List<ShowSetor> infosetores = new List<ShowSetor>();

            foreach(string ls in listasetores)
            {
                ShowSetor aux = new ShowSetor();

                aux.setor = "Setor: " + ls;

                foreach (SetorType val in result)
                {
                    if (ls == val.setor)
                    {
                        aux.addInfo(val.descricao, val.num);
                    }
                }

                infosetores.Add(aux);
            }
            /*
            StringBuilder sb = new StringBuilder();

            sb.Append(infosetores[0].ToString());

            for (int i = 1; i < infosetores.Count(); i++)
            {
                sb.Append(", ");
                sb.Append(infosetores[i].ToString());
            }
            */
            return infosetores;
        }

        public async Task<List<ShowSetorNormal>> GetPlaceSectorTypeNormal()
        {
            var db = dbConnection();
            var sql = @"SELECT setor, descricao, COUNT(l.estado) AS num 
                        FROM lugar l
                        INNER JOIN setor s 
                        ON l.setorid_setor = s.id_setor 
                        INNER JOIN tipo_lugar t
                        ON t.n_tipo = l.tipo_lugarn_tipo 
                        WHERE l.estado = 0
                        GROUP BY setor, descricao";

            IEnumerable<SetorType> result = await db.QueryAsync<SetorType>(sql, new { });

            var db1 = dbConnection();
            var sql1 = @"SELECT DISTINCT setor FROM setor ";

            IEnumerable<string> listasetores = await db1.QueryAsync<string>(sql1);

            List<ShowSetorNormal> infosetores = new List<ShowSetorNormal>();

            foreach (string ls in listasetores)
            {
                ShowSetorNormal aux = new ShowSetorNormal();

                aux.setor = "Setor: " + ls;

                foreach (SetorType val in result)
                {
                    if (ls == val.setor)
                    {
                        aux.addInfo(val.descricao, val.num);
                    }
                }

                infosetores.Add(aux);
            }

            return infosetores;
        }

        public async Task<List<ShowSetorMoto>> GetPlaceSectorTypeMoto()
        {
            var db = dbConnection();
            var sql = @"SELECT setor, descricao, COUNT(l.estado) AS num 
                        FROM lugar l
                        INNER JOIN setor s 
                        ON l.setorid_setor = s.id_setor 
                        INNER JOIN tipo_lugar t
                        ON t.n_tipo = l.tipo_lugarn_tipo 
                        WHERE l.estado = 0
                        GROUP BY setor, descricao";

            IEnumerable<SetorType> result = await db.QueryAsync<SetorType>(sql, new { });

            var db1 = dbConnection();
            var sql1 = @"SELECT DISTINCT setor FROM setor ";

            IEnumerable<string> listasetores = await db1.QueryAsync<string>(sql1);

            List<ShowSetorMoto> infosetores = new List<ShowSetorMoto>();

            foreach (string ls in listasetores)
            {
                ShowSetorMoto aux = new ShowSetorMoto();

                aux.setor = "Setor: " + ls;

                foreach (SetorType val in result)
                {
                    if (ls == val.setor)
                    {
                        aux.addInfo(val.descricao, val.num);
                    }
                }

                infosetores.Add(aux);
            }

            return infosetores;
        }

        public async Task<List<ShowSetorEletric>> GetPlaceSectorTypeEletric()
        {
            var db = dbConnection();
            var sql = @"SELECT setor, descricao, COUNT(l.estado) AS num 
                        FROM lugar l
                        INNER JOIN setor s 
                        ON l.setorid_setor = s.id_setor 
                        INNER JOIN tipo_lugar t
                        ON t.n_tipo = l.tipo_lugarn_tipo 
                        WHERE l.estado = 0
                        GROUP BY setor, descricao";

            IEnumerable<SetorType> result = await db.QueryAsync<SetorType>(sql, new { });

            var db1 = dbConnection();
            var sql1 = @"SELECT DISTINCT setor FROM setor ";

            IEnumerable<string> listasetores = await db1.QueryAsync<string>(sql1);

            List<ShowSetorEletric> infosetores = new List<ShowSetorEletric>();

            foreach (string ls in listasetores)
            {
                ShowSetorEletric aux = new ShowSetorEletric();

                aux.setor = "Setor: " + ls;

                foreach (SetorType val in result)
                {
                    if (ls == val.setor)
                    {
                        aux.addInfo(val.descricao, val.num);
                    }
                }

                infosetores.Add(aux);
            }

            return infosetores;
        }


        public async Task<List<ShowSetorReduceMob>> GetPlaceSectorTypeReduceMob()
        {
            var db = dbConnection();
            var sql = @"SELECT setor, descricao, COUNT(l.estado) AS num 
                        FROM lugar l
                        INNER JOIN setor s 
                        ON l.setorid_setor = s.id_setor 
                        INNER JOIN tipo_lugar t
                        ON t.n_tipo = l.tipo_lugarn_tipo 
                        WHERE l.estado = 0
                        GROUP BY setor, descricao";

            IEnumerable<SetorType> result = await db.QueryAsync<SetorType>(sql, new { });

            var db1 = dbConnection();
            var sql1 = @"SELECT DISTINCT setor FROM setor ";

            IEnumerable<string> listasetores = await db1.QueryAsync<string>(sql1);

            List<ShowSetorReduceMob> infosetores = new List<ShowSetorReduceMob>();

            foreach (string ls in listasetores)
            {
                ShowSetorReduceMob aux = new ShowSetorReduceMob();

                aux.setor = "Setor: " + ls;

                foreach (SetorType val in result)
                {
                    if (ls == val.setor)
                    {
                        aux.addInfo(val.descricao, val.num);
                    }
                }

                infosetores.Add(aux);
            }

            return infosetores;
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
