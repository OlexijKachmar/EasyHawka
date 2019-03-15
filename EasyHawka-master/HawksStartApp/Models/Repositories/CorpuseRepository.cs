using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HawksStartApp.Models.Repositories
{
    public class CorpuseRepository : BaseRepository<Corpuse>
    {
        public CorpuseRepository(HawkaContext hawkaContext) : base(hawkaContext)
        {
        }       

    }
}