using ApiImovel.Models;
using System.Data.SqlClient;

namespace ApiImovel.SQL
{
    public class Sql
    {
        private readonly SqlConnection _conexao;
        public Sql()
        {
            this._conexao = new SqlConnection(@"Data Source=D37G18818247761\SQLEXPRESS;Initial Catalog=CrudImovel;Persist Security Info=True;User ID=sa;Password=123456;");
        }

        public List<Imovel> ListarImovel()
        {
            List<Imovel> imovels = new List<Imovel>();
            try
            {
                _conexao.Open();
                string sql = @" SELECT [Id]
                                  ,[TipoImovel] ,[ValorV], [ValorL] ,[Endereco] ,[Numero]
                                  ,[Complemento] ,[Bairro] ,[Cidade] ,[Estado] ,[Cep]
                                FROM [dbo].[Imovel];";
                using var cmd = new SqlCommand(sql, _conexao);
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Imovel imovel = new Imovel();

                        imovel.Id = Convert.ToInt32(rdr["Id"]);
                        imovel.TipoImovel = "" + rdr["TipoImovel"];
                        imovel.ValorVenda = Convert.ToInt32(rdr["ValorV"]);
                        imovel.ValorLocacao = Convert.ToInt32(rdr["ValorL"]);
                        imovel.Endereco = "" + rdr["Endereco"];
                        imovel.Numero = Convert.ToInt32(rdr["Numero"]);
                        imovel.Complemento = "" + rdr["Complemento"];
                        imovel.Bairro = "" + rdr["Bairro"];
                        imovel.Cidade = "" + rdr["Cidade"];
                        imovel.Estado = "" + rdr["Estado"];
                        imovel.Cep = "" + rdr["Cep"];

                        imovels.Add(imovel);

                    }
                }
                return imovels;
            }
            finally
            {
                _conexao.Close();
            }
        }

        public void EditarImovel(int ID, Imovel imovel)
        {
            try
            {
                _conexao.Open();
                string sql = @"UPDATE Imovel SET
                                            TipoImovel=@tipoImovel,
                                            ValorV=@valorV,
                                            ValorL=@valorL,
                                            Endereco=@endereco,
                                            Numero=@numero,
                                            Complemento=@complemento,
                                            Bairro=@bairro,
                                            Cidade=@cidade,
                                            Estado=@estado,
                                            Cep=@cep
                                            WHERE Id = @id;";
                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("tipoImovel", imovel.TipoImovel);
                    cmd.Parameters.AddWithValue("valorV", imovel.ValorVenda);
                    cmd.Parameters.AddWithValue("valorL", imovel.ValorLocacao);
                    cmd.Parameters.AddWithValue("endereco", imovel.Endereco);
                    cmd.Parameters.AddWithValue("numero", imovel.Numero);
                    cmd.Parameters.AddWithValue("complemento", imovel.Complemento);
                    cmd.Parameters.AddWithValue("bairro", imovel.Bairro);
                    cmd.Parameters.AddWithValue("cidade", imovel.Cidade);
                    cmd.Parameters.AddWithValue("estado", imovel.Estado);
                    cmd.Parameters.AddWithValue("cep", imovel.Cep);
                    cmd.Parameters.AddWithValue("id", imovel.Id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _conexao.Close();
            }
        }

        public void RemoverImovel (int ID)
        {
            try
            {
                _conexao.Open();
                string sql = @"DELETE FROM Imovel
                                WHERE Id = @id;";
                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("id", ID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _conexao.Close();
            }
        }

        public List<Imovel> BuscarImovel(int[] ID)
        {
            List<Imovel> imovels = new List<Imovel>();
            try
            {
                _conexao.Open();
                foreach (int id in ID)
                {
                    string sql = @" SELECT [Id]
                                  ,[TipoImovel] ,[ValorV], [ValorL] ,[Endereco] ,[Numero]
                                  ,[Complemento] ,[Bairro] ,[Cidade] ,[Estado] ,[Cep]
                                FROM [dbo].[Imovel]
                                WHERE Id = @id ;";
                    using var cmd = new SqlCommand(sql, _conexao);
                    cmd.Parameters.AddWithValue("id", id);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Imovel imovel = new Imovel();

                            imovel.Id = Convert.ToInt32(rdr["Id"]);
                            imovel.TipoImovel = "" + rdr["TipoImovel"];
                            imovel.ValorVenda = Convert.ToInt32(rdr["ValorV"]);
                            imovel.ValorLocacao = Convert.ToInt32(rdr["ValorL"]);
                            imovel.Endereco = "" + rdr["Endereco"];
                            imovel.Numero = Convert.ToInt32(rdr["Numero"]);
                            imovel.Complemento = "" + rdr["Complemento"];
                            imovel.Bairro = "" + rdr["Bairro"];
                            imovel.Cidade = "" + rdr["Cidade"];
                            imovel.Estado = "" + rdr["Estado"];
                            imovel.Cep = "" + rdr["Cep"];

                            imovels.Add(imovel);

                        }
                    }
                }
                return imovels;
            }
            finally
            {
                _conexao.Close();
            }
        }

        public void InserirImovel(Imovel imovel)
        {
            try
            {
                _conexao.Open();
                string sql = @"INSERT INTO Imovel
                                    (TipoImovel,ValorV,ValorL,Endereco,Numero,Complemento,Bairro,Cidade,Estado,Cep)
                                VALUES
                                    (@tipoImovel,@valorV,@valorL,@endereco,@numero,@complemento,@bairro,@cidade,@estado,@cep);";
                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("tipoImovel", imovel.TipoImovel);
                    cmd.Parameters.AddWithValue("valorV", imovel.ValorVenda);
                    cmd.Parameters.AddWithValue("valorL", imovel.ValorLocacao);
                    cmd.Parameters.AddWithValue("endereco", imovel.Endereco);
                    cmd.Parameters.AddWithValue("numero", imovel.Numero);
                    cmd.Parameters.AddWithValue("complemento", imovel.Complemento);
                    cmd.Parameters.AddWithValue("bairro", imovel.Bairro);
                    cmd.Parameters.AddWithValue("cidade", imovel.Cidade);
                    cmd.Parameters.AddWithValue("estado", imovel.Estado);
                    cmd.Parameters.AddWithValue("cep", imovel.Cep);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }
        }

    }
}
