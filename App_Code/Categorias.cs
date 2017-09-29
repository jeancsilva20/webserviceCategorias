using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class Categorias
{
    private SqlConnection _conexaoBD;
   private String _cadeiaConexao = "Data Source = 62502c39-1d34-4767-a69d-a760000a0335.sqlserver.sequelizer.com;" +
                            "Initial Catalog = db62502c391d344767a69da760000a0335;" +
                            "Persist Security Info=True;" +
                            "User ID = gaytizpdwtcqpwkc;" +
                            "Password=utDgMnAiLkJL8QRwJrowpSLJBTHzxTdwr742zSPbFYjiuaincRerNbZJQ3M3MbTZ;";

    private Categoria categoria;

	public Categorias(Categoria c)
	{
        this.categoria = c;
	}

    public void Post()
    {
        try
        {
            String sql = "INSERT INTO categoria (nome_categoria, descricao_categoria, foto_categoria)" +
                             " VALUES (@nome, @descricao, @foto)";
            _conexaoBD = new SqlConnection(_cadeiaConexao);

            SqlCommand cmdSql = new SqlCommand(sql, _conexaoBD);

            cmdSql.Parameters.AddWithValue("@nome", categoria.Nome);
            cmdSql.Parameters.AddWithValue("@descricao", categoria.Descricao);
            cmdSql.Parameters.AddWithValue("@foto", categoria.Foto);
            _conexaoBD.Open();
            cmdSql.ExecuteNonQuery();
        }
        catch (Exception ex) 
        {
            throw ex;
        }
        finally 
        {
            _conexaoBD.Close();
        }
    }

    public void Delete()
    {
        try
        {
            String sql = "DELETE FROM categoria WHERE nome_categoria = @nome";
            _conexaoBD = new SqlConnection(_cadeiaConexao);

            SqlCommand cmd = new SqlCommand(sql, _conexaoBD);

            cmd.Parameters.AddWithValue("@nome", categoria.Nome);
            _conexaoBD.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            _conexaoBD.Close();
        }
    }

    public bool Get()
    {
        try
        {
            String sql;
            sql = "IF EXISTS( SELECT  nome_categoria " +
                    "FROM categoria " +
                    "WHERE nome_categoria = @nome) SELECT 1 AS returnValue";

            _conexaoBD = new SqlConnection(_cadeiaConexao);
            SqlCommand cmd = new SqlCommand(sql, _conexaoBD);
            cmd.Parameters.AddWithValue("@nome", categoria.Nome);
            _conexaoBD.Open();
            SqlDataReader dr;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.Read())
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            _conexaoBD.Close();
        }

    }

    public void mudarDescricao()
    {
        try
        {
            String sql = "UPDATE categoria" +
                         " SET descricao_categoria = @descricao" +
                         " WHERE nome_categoria = @nome ";

            _conexaoBD = new SqlConnection(_cadeiaConexao);
            SqlCommand cmd = new SqlCommand(sql, _conexaoBD);
            cmd.Parameters.AddWithValue("@descricao", categoria.Descricao);
            cmd.Parameters.AddWithValue("@nome", categoria.Nome);
            _conexaoBD.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            _conexaoBD.Close();
        }
    }

    public void mudarFoto()
    {
        try
        {
            String sql = "UPDATE categoria" +
                         " SET foto_categoria = @foto" +
                         " WHERE nome_categoria = @nome";

            _conexaoBD = new SqlConnection(_cadeiaConexao);
            SqlCommand cmd = new SqlCommand(sql, _conexaoBD);
            cmd.Parameters.AddWithValue("@foto", categoria.Foto);
            cmd.Parameters.AddWithValue("@nome", categoria.Nome);
            _conexaoBD.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            _conexaoBD.Close();
        }
    }
}