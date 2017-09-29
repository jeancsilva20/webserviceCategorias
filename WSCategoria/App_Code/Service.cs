using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool GerenciarCategoria(String nome, String descricao, String foto, int opcao)
    {
        int o = opcao;
        Categoria c = new Categoria(nome, descricao, foto);
        Categorias categorias = new Categorias(c);
        switch (o)
        {
            case 1:
                categorias.Incluir();
                return true;
            case 2:
                categorias.Excluir();
                return true;
            case 3:
                categorias.mudarFoto();
                return true;
            case 4:
                categorias.mudarDescricao();
                return true;
            case 5:
                if (categorias.Procurar())
                    return true;
                else
                    return false;
            default:
                throw new Exception("Nenhuma opção selecionada");
        }
    }

    
}