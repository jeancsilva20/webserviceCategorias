using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Categoria
{
    int id;
    private string nome, descricao, foto;

	public Categoria(string nome, string descricao, string foto)
	{
        this.Nome = nome;
        this.Descricao = descricao;
        this.Foto = foto;
	}

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Foto
    {
        get { return foto; }
        set { foto = value; }
    }

    public string Descricao
    {
        get { return descricao; }
        set { descricao = value; }
    }

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }
}