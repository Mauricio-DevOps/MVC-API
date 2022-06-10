using ApiImovel.Models;
using Microsoft.AspNetCore.Mvc;
using ApiImovel.SQL;

namespace ApiImovel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Imoveis : ControllerBase
    {
        [HttpGet("ListarImovel")]
        public List<Imovel> ListarImovel()
        {
            Sql sql = new Sql();
            return sql.ListarImovel();
        }
        [HttpPost("EditarImovel/{id}")]
        public void EditarImovel(int id, Imovel imovel)
        {
            Sql sql = new Sql();
            sql.EditarImovel(id,imovel);
        }
        [HttpGet("RemoverImovel")]
        public void RemoverImovel(int id)
        {
            Sql sql = new Sql();
            sql.RemoverImovel(id);
        }
        [HttpPost("BuscarImovel")]
        public List<Imovel> BuscarImovel(int[] id)
        {
            Sql sql = new Sql();
            return sql.BuscarImovel(id);
        }
        [HttpPost("AdicionarImovel")]
        public void AdicionarImovel(Imovel imovel)
        {
            Sql sql = new Sql();
            sql.InserirImovel(imovel);
        }
    }
}